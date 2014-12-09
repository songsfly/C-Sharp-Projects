using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace SVNSearch
{
    public partial class MainForm : Form
    {
        public delegate void MsgDelegate(String str);
        public delegate void ListDelegate(List<String> str);
        public delegate void VoidDelegate();

        Hashtable map = new Hashtable();
        String currentFileName = "";
        List<String> allFileNames = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        bool finishLoad = false;
        private void Form1_Load(object sender, EventArgs e)
        { 
            Thread t = new Thread(new ThreadStart(initBorder));
            t.Start();
            textBoxCondition.Text = DEFAULT_CONDITION;
            radioButtonCurrent.Checked = true;
            loadData(); 
        }

        private void loadData()
        { 
            map.Clear();
            listBoxSearchResult.Items.Clear();
            allFileNames.Clear();
            currentFileName = "";

            new Thread(new ThreadStart(loadDataThread)).Start();

             
        }

        private void initUIData()
        {
            comboBoxSVNItems.Items.Clear();
            foreach (Object key in allFileNames)
            {
                comboBoxSVNItems.Items.Add(key.ToString());
            }
            if (comboBoxSVNItems.Items.Count != 0)
            {
                comboBoxSVNItems.SelectedIndex = 0;
                currentFileName = comboBoxSVNItems.SelectedItem.ToString();
                
            }

            finishLoad = true;
        }

        private void loadDataThread()
        {
            List<String> fileNames = ManageDb.getFileNames();
            foreach (String fileName in fileNames)
            {
                String itemName = getSvnName(fileName);
                if (null == itemName)
                {
                    continue;
                }

                allFileNames.Add(itemName);
                
                List<String> data = getSvnData(fileName);
                data.Sort();
                map.Add(itemName.GetHashCode(), data);
            }

            this.Invoke(new VoidDelegate(initUIData),new object[]{});
        }

        private String getSvnName(String fileName)
        {
            if (fileName.EndsWith(".db"))
            {
                String data = ManageDb.readFile(fileName);
                if (data.Length != 0)
                {
                    String[] lns = data.Split('\n');
                    String itemName = lns[0];
                    return itemName;
                }
            }
            return null;
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

        private void initBorder()
        {
            Thread.Sleep(2000);
            while (!finishLoad)
            {
                Thread.Sleep(100);
            }
            this.Invoke(new VoidDelegate(showBorder), new object[] { });
        }
        private void showBorder()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.pictureBox1.Visible = false;
            Panel_background.Visible = true;
        }

        private void btnMngDb_Click(object sender, EventArgs e)
        {
            ManageDbForm md = new ManageDbForm();
            md.ShowDialog(this);
            loadData();
        }

        System.DateTime lastTime = System.DateTime.Now;
        String baseTime = "00:00:00";
        String DEFAULT_CONDITION = "请输入查询条件";
        private void showResultThread()
        {
            if (textBoxCondition.Text.Equals(DEFAULT_CONDITION))
            {
                return;
            }
            progressBarSearch.Visible = true;
            //progressBarSearch.PerformStep();
            Thread t = new Thread(new ThreadStart(showResult));
            t.Start();
        }

        String CLEAR_FLAG = "&&**^^@";
        String SEARCH_FINISH_FLAG = "&&**^^@ffish";
        private void updateCheckListBoxItem(List<String> msg)
        {
            if (msg.Count == 0)
            {
                listBoxSearchResult.Items.Clear();
                return;
            }
            listBoxSearchResult.Items.AddRange(msg.ToArray());
        }

        List<String> searchResultTmp = new List<string>();
        private void addItemToSerchResult(String item)
        {
            if (item.Equals(CLEAR_FLAG))
            {
                searchResultTmp.Clear();
                this.Invoke(new ListDelegate(updateCheckListBoxItem), new object[] { searchResultTmp });
                return;
            }
            if (item.Equals(SEARCH_FINISH_FLAG))
            {
                if (searchResultTmp.Count!=0)//如果是空的化会清空之前的查询的
                {
                    this.Invoke(new ListDelegate(updateCheckListBoxItem), new object[] { searchResultTmp });
                }
                return;
            }
            searchResultTmp.Add(item);
            if ((System.DateTime.Now - lastTime).ToString().Split('.')[0].CompareTo(baseTime) > 0)
            {
                lastTime = System.DateTime.Now;
                this.Invoke(new ListDelegate(updateCheckListBoxItem), new object[] { searchResultTmp });
                searchResultTmp.Clear();
                Thread.Sleep(100);
            }
        }

        private void showResult()
        {
            int resultCount = 0;
            lastTime = System.DateTime.Now;
           addItemToSerchResult( CLEAR_FLAG);
            List<String> searchResults = new List<string>();
            if (radioButtonCurrent.Checked == true)
            {
                if (comboBoxSVNItems.Items.Count != 0)
                {
                    String itemName = currentFileName;
                    List<String> data = (List<String>)map[itemName.GetHashCode()];
                    foreach (String ln in data)
                    {
                        if (ln.Contains(textBoxCondition.Text))
                        {
                            if (ln.Trim().Length != 0)
                            {
                                resultCount++;
                                addItemToSerchResult(ln);
                            }
                              
                        }
                    }

                }
            }
            else if (radioButtonAll.Checked == true)
            {
                if (comboBoxSVNItems.Items.Count != 0)
                {
                    foreach (Object item in allFileNames)
                    {
                        String itemName = item.ToString();
                        List<String> data = (List<String>)map[itemName.GetHashCode()];
                        foreach (String ln in data)
                        {
                            if (ln.Contains(textBoxCondition.Text))
                            {
                                if (ln.Trim().Length != 0)
                                {
                                    resultCount++;
                                    addItemToSerchResult(ln);
                                }
                            }
                        }
                    }

                }
            }

            addItemToSerchResult(SEARCH_FINISH_FLAG);
            this.Invoke(new VoidDelegate(hideProgress), new object[] { });
            if (0 == resultCount)
            {
                this.Invoke(new MsgDelegate(showMsg), new object[] { "没有匹配项" });
            }
        }

        private void hideProgress()
        {
             progressBarSearch.Visible = false;
        }

        private void showMsg(String msg)
        {
            MessageBox.Show(msg);
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                showResultThread();
            }
        }

        private void radioButtonCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonCurrent.Checked==true)
            {
                showResultThread();
            }
        }



        //TODO单个文件无法检出
        private void listBoxSearchResult_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxSearchResult.SelectedItems.Count != 0)
            {
                Clipboard.SetData(DataFormats.Text, listBoxSearchResult.SelectedItem.ToString());
                MessageBox.Show("路径已复制，选择目标目录可检出");
                this.folderBrowserDialog1.ShowDialog();
                String path = this.folderBrowserDialog1.SelectedPath;
                if (path == "") return;

                DirectoryInfo dirInfo = new DirectoryInfo(path + "\\.svn");
                if (dirInfo.Exists)
                {
                    Directory.Delete(path + "\\.svn", true);
                }


                ProcessStartInfo start = new ProcessStartInfo("svn");

                if (listBoxSearchResult.SelectedItem.ToString().EndsWith("/"))
                {
                    start.Arguments = "checkout " + listBoxSearchResult.SelectedItem.ToString() + " " + path;//设置命令参数
                }
                else
                {
                    start.Arguments = "export " + listBoxSearchResult.SelectedItem.ToString() + " " + path;//设置命令参数
                }
                start.CreateNoWindow = true;//不显示dos命令行窗口
                start.RedirectStandardOutput = true;//
                start.RedirectStandardInput = true;//
                start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序

                new Thread(exportPath).Start(start);
                progressBarSearch.Visible = true;
                 
            }
        }

        private void exportPath(Object start)
        {
            Process p = Process.Start((ProcessStartInfo)start);
            StreamReader reader = p.StandardOutput;//截取输出流

            string line = reader.ReadLine();//每次读取一行
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();//关闭进程
            reader.Close();//关闭流

            this.Invoke(new MsgDelegate(showMsg), new object[] { "检出完毕" });
            this.Invoke(new VoidDelegate(hideProgress), new object[] {  });
        }
         
        private void textBoxCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13)
            {
                return;
            }
            else
            {
                if(radioButtonAll.Checked==false&&radioButtonCurrent.Checked==false)
                {
                    showMsg("请先选择搜索单个SVN还是全部SVN");
                    return;
                }
                showResultThread();

            }
        }

        private void comboBoxSVNItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFileName = comboBoxSVNItems.SelectedItem.ToString();
        }
    }
}
