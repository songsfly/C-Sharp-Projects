using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Web;

namespace SVNSearch
{
    public partial class ManageDbForm : Form
    {
        bool isExit = false;
        public ManageDbForm()
        {
            InitializeComponent();
        }

        public delegate void MsgDelegate(String str);
        public delegate void VoidDelegate();
        String newSVNName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(getData));
            while ("" == newSVNName)
            {
                newSVNName = InputBox("为该地址取个别名吧", "", "");
                if (newSVNName.Contains("=="))
                {
                    MessageBox.Show("不能包含“==”");
                    newSVNName = "";
                }
            }
            t.Start();
            this.richTextBoxDebug.Focus();
        }

        private String getVersion(String path)
        {
            ProcessStartInfo start = new ProcessStartInfo("svn");//设置运行的命令行文件问ping.exe文件，这个文件系统会自己找到
            //如果是其它exe文件，则有可能需要指定详细路径，如运行winRar.exe
            start.Arguments = " info "+path;//设置命令参数
            start.CreateNoWindow = true;//不显示dos命令行窗口
            start.RedirectStandardOutput = true;//
            start.RedirectStandardInput = true;//
            start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序
            Process p = Process.Start(start);
            StreamReader reader = p.StandardOutput;//截取输出流


            List<String> results = new List<string>();

            string line = reader.ReadLine();//每次读取一行
            while (!reader.EndOfStream && !isExit)
            {
                if (line.Contains("版本:") || line.Contains("Revision:"))
                {
                    return line.Split(':')[1].Trim();
                }
                line = reader.ReadLine();
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();//关闭进程
            reader.Close();//关闭流

            return null;
        }
        private bool isInteger(String num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void getData()
        {
            this.Invoke(new VoidDelegate(disbleButton), new object[] { });
            String path = textBoxSVNAddr.Text.Trim();
           
            
            ProcessStartInfo start = new ProcessStartInfo("svn");//设置运行的命令行文件问ping.exe文件，这个文件系统会自己找到
            //如果是其它exe文件，则有可能需要指定详细路径，如运行winRar.exe
            start.Arguments = " ls -R "+path;//设置命令参数
            start.CreateNoWindow = true;//不显示dos命令行窗口
            start.RedirectStandardOutput = true;//
            start.RedirectStandardInput = true;//
            start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序
            Process p = Process.Start(start);
            StreamReader reader = p.StandardOutput;//截取输出流


            List<String> results = new List<string>();

            string line = reader.ReadLine();//每次读取一行
            while (!reader.EndOfStream&&!isExit)
            {
                try
                {
                    if(!path.EndsWith("/"))
                    {
                        path+="/";
                    }
                    line=path+line;
                    line = changeHttpcodeToHANZI(line);
                    results.Add(line);
                    this.Invoke(new MsgDelegate(this.richTextBoxDebug.AppendText), new object[] { "\n"+ line  });
                }
                catch (Exception e)
                {
                    break;
                }
                line = reader.ReadLine();
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();//关闭进程
            reader.Close();//关闭流
            
            if (line != null && line.Trim() != "" && results.Count == 0)
            {
                results.Add(line);
                this.Invoke(new MsgDelegate(this.richTextBoxDebug.AppendText), new object[] { "\n" + line });
            }
            //this.Invoke(new MsgDelegate(showMsg), new object[] { "写文件前"+System.DateTime.Now });
            addTodoDb(path,results);
            //this.Invoke(new MsgDelegate(showMsg), new object[] { "写文件后" + System.DateTime.Now });
            this.Invoke(new VoidDelegate(enableButton), new object[] { });
            this.Invoke(new VoidDelegate(setTxbAddrText), new object[] { });
            this.Invoke(new MsgDelegate(showMsg), new object[] { "初始化完毕" });
        }

        private void addTodoDb(string path, List<string> results)
        {
            String itemName = newSVNName + "==" + path;
            newSVNName = "";
            if (results.Count == 0)
            {
                this.Invoke(new MsgDelegate(showMsg), new object[] {"结果为空，请检查SVN地址是否正确" });
                return;
            }
            String version = getVersion(path);
            if (version == null || !isInteger(version))
            {
                this.Invoke(new MsgDelegate(showMsg), new object[] { "获取版本号失败，可能是程序bug！" });
                return;
            }
            this.Invoke(new MsgDelegate(addItem2CheckBox), new object[] { itemName });
            StringBuilder sb=new StringBuilder();
            sb.Append(itemName + "\n" + version + "\n");
            foreach(String result in results)
            {
                sb.Append(result + "\n");

            }
            ManageDb.writeFile(itemName.GetHashCode()+".db",sb.ToString());
        }

        private void updateTodoDb(string path, List<string> results)
        {
            String itemName = newSVNName + "==" + path;
            newSVNName = "";
           
            String version = getVersion(path);
            if (version == null || !isInteger(version))
            {
                this.Invoke(new MsgDelegate(showMsg), new object[] { "获取版本号失败，可能是程序bug！" });
                return;
            }
             
            
            StringBuilder sb = new StringBuilder();
            sb.Append(itemName + "\n" + version + "\n");
            List<String> oldList = getSvnData("db/"+itemName.GetHashCode() + ".db");
            List<String> addList = new List<string>();
            List<String> rmList = new List<string>();
            foreach (String result in results)
            {
                 
                    if (result.StartsWith("A"))
                    {
                        String newLine = result.Substring(1).Trim();
                         
                        addList.Add(newLine);
                        
                    }
                    else if (result.StartsWith("D"))
                    {
                        String newLine = result.Substring(1).Trim();
                       if(oldList.Contains(newLine))
                       {
                            rmList.Add(newLine);
                             
                       }
                    }
 
            }

            oldList.AddRange(addList.ToArray());
            foreach (String rm in rmList)
            {
                oldList.Remove(rm);
            } 
            foreach (String ln in oldList)
            {
                if (rmList.Contains(ln)) continue;
                sb.Append(ln + "\n");
            }
            ManageDb.writeFile(itemName.GetHashCode() + ".db", sb.ToString());
 
        }

        private String changeHttpcodeToHANZI(String src)
        { 
            string result = HttpUtility.UrlDecode(src, Encoding.GetEncoding("UTF-8"));
            return result;

        }

        private void addItem2CheckBox(String itemName)
        {
            this.checkedListBoxItemss.Items.Add(itemName, false);
        }
        private void showMsg(String msg)
        {
            MessageBox.Show(msg);
        }

        public void enableButton()
        {
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
        }
        public void disbleButton()
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
        }

        public void setTxbAddrText()
        {
            textBoxSVNAddr.Text = "";
        }
        private void ManageDb_FormClosing(object sender, FormClosingEventArgs e)
        {
            isExit = true;
        }

        private string InputBox(string Caption, string Hint, string Default)
        {
             
            Form InputForm = new Form();
            InputForm.MinimizeBox = false;
            InputForm.MaximizeBox = false;
            InputForm.StartPosition = FormStartPosition.CenterScreen;
            InputForm.Width = 220;
            InputForm.Height = 150; 

            InputForm.Text = Caption;
            Label lbl = new Label();
            lbl.Text = Hint;
            lbl.Left = 10;
            lbl.Top = 20;
            lbl.Parent = InputForm;
            lbl.AutoSize = true;
            TextBox tb = new TextBox();
            tb.Left = 30;
            tb.Top = 45;
            tb.Width = 160;
            tb.Parent = InputForm;
            tb.Text = Default;
            tb.SelectAll();
            Button btnok = new Button();
            btnok.Left = 30;
            btnok.Top = 80;
            btnok.Parent = InputForm;
            btnok.Text = "确定";
            InputForm.AcceptButton = btnok;//回车响应

            btnok.DialogResult = DialogResult.OK;
            Button btncancal = new Button();
            btncancal.Left = 120;
            btncancal.Top = 80;
            btncancal.Parent = InputForm;
            btncancal.Text = "取消";
            btncancal.DialogResult = DialogResult.Cancel;
            try
            {
                if (InputForm.ShowDialog() == DialogResult.OK)
                {
                    return tb.Text;
                }
                else
                {
                    return "";
                }
            }
            finally
            {
                InputForm.Dispose();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("确定要删除所选？", "请选择", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                List<String> list = new List<string>();
                for (int i = 0; i < checkedListBoxItemss.Items.Count; i++)
                {
                    if (checkedListBoxItemss.GetItemChecked(i))
                    {
                        String allStr = checkedListBoxItemss.GetItemText(checkedListBoxItemss.Items[i]);
                        list.Add(allStr);
                        
                    }
                }

                foreach (String allStr in list)
                {
                    String addr = allStr.Substring(allStr.Split("==".ToCharArray())[0].Length + 2);
                    checkedListBoxItemss.Items.Remove(allStr);
                    ManageDb.rmFile(allStr.GetHashCode() + ".db");
                }
            }
            else if (d == DialogResult.No)
            {
            }
            
        }

        private void ManageDbForm_Load(object sender, EventArgs e)
        {
            List<String> fileNames = ManageDb.getFileNames();
            if (fileNames.Count != 0)
            {
                foreach (String fileName in fileNames)
                {
                    if (fileName.EndsWith(".db"))
                    {
                        String data = ManageDb.readFile(fileName);
                        if (data.Length != 0)
                        {
                            String[] lns = data.Split('\n');
                            String itemName = lns[0];
                            this.checkedListBoxItemss.Items.Add(itemName);
                        }
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(updateData);
            List<String> list = new List<string>();
             
            for (int i = 0; i < checkedListBoxItemss.Items.Count; i++)
            {
                if (checkedListBoxItemss.GetItemChecked(i))
                {
                    String allStr = checkedListBoxItemss.GetItemText(checkedListBoxItemss.Items[i]);
                    list.Add(allStr);

                }
            }
            t.Start(  list);
            richTextBoxDebug.Focus();
        }

        private void updateData(Object items)
        {
            
            this.Invoke(new VoidDelegate(disbleButton), new object[] { });
            List<String> itemss = (List<String>)items;
            for (int i = 0; i < itemss.Count; i++)
            {
                String allStr = itemss[i].ToString();
                String currVersion = getLocalVersion(allStr);
               // this.Invoke(new MsgDelegate(showMsg), new object[] { currVersion });

                String path = allStr.Substring(allStr.Split("==".ToCharArray())[0].Length + 2);
                newSVNName = allStr.Split("==".ToCharArray())[0];

                ProcessStartInfo start = new ProcessStartInfo("svn");//设置运行的命令行文件问ping.exe文件，这个文件系统会自己找到
                //如果是其它exe文件，则有可能需要指定详细路径，如运行winRar.exe
                start.Arguments = " diff " + path + "  -r "+currVersion+" --summarize";//设置命令参数
                start.CreateNoWindow = true;//不显示dos命令行窗口
                start.RedirectStandardOutput = true;//
                start.RedirectStandardInput = true;//
                start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序
                Process p = Process.Start(start);
                StreamReader reader = p.StandardOutput;//截取输出流


                List<String> results = new List<string>();

                string line = "";
                while (!reader.EndOfStream && !isExit)
                {
                    try
                    {
                        line = reader.ReadLine();//每次读取一行
                        if (!path.EndsWith("/"))
                        {
                            path += "/";
                        }
                        line = changeHttpcodeToHANZI(line);
                        results.Add(line);
                        this.Invoke(new MsgDelegate(this.richTextBoxDebug.AppendText), new object[] { "\n" + line });
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                    
                }
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();//关闭进程
                reader.Close();//关闭流
                if (line != null && line.Trim() != "" && results.Count == 0)
                {
                    results.Add(line);
                    this.Invoke(new MsgDelegate(this.richTextBoxDebug.AppendText), new object[] { "\n" + line });
                }
                
               updateTodoDb(path, results);
            }
            this.Invoke(new VoidDelegate(enableButton), new object[] { });
            this.Invoke(new VoidDelegate(setTxbAddrText), new object[] { });
            this.Invoke(new MsgDelegate(showMsg), new object[] { "更新完毕" });
        }

        private string getLocalVersion(string allStr)
        {
            String []lns= ManageDb.readFile("db/"+allStr.GetHashCode() + ".db").Split('\n');
            if(lns.Length>=2)
            {
                 return lns[1];
            }
            return "0";
        }

        private List<String> getSvnData(String fileName)
        {
            List<String> list = new List<string>();
            if (fileName.EndsWith(".db"))
            {
                String data = ManageDb.readFile(fileName);
                if (data.Length != 0)
                {
                    String[] lns = data.Split('\n');
                    for (int i = 2; i < lns.Length; i++)
                    {
                        list.Add(lns[i]);
                    }
                }
            }

            return list;
        }
    }
}
