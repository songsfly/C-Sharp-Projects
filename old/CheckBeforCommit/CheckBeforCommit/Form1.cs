using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace CheckBeforCommit
{
    public partial class Form1 : Form
    {
        public delegate void MsgDelegate(String str);
        public delegate void VoidDelegate();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkDirExist(textBoxDir.Text))
            {
                MessageBox.Show("文件夹不存在");
                return;
            }
            listBoxResults.Items.Clear();
            btnAll.Enabled = false;
            btnChange.Enabled = false;
            beginAllCheckThread();
        }

        

        

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (!checkDirExist(textBoxDir.Text))
            {
                MessageBox.Show("文件夹不存在");
                return;
            }

            listBoxResults.Items.Clear();
            btnAll.Enabled = false;
            btnChange.Enabled = false;
            beginChangeCheckThread();
        }

        private bool checkDirExist(String path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void beginChangeCheckThread()
        {
            Thread t = new Thread(CheckChange);
            t.Start();
        }

        private void beginAllCheckThread()
        {
            Thread t = new Thread(CheckAll);
            t.Start();
        }
        private void CheckChange()
        {
            List<String> lns = getFilterFiles(getChangeFilesName(textBoxDir.Text));
            
            foreach (String ln in lns)
            {
                List<CheckResult> checkResults = judgeResult(ln);
                foreach (CheckResult result in checkResults)
                {
                    this.Invoke(new MsgDelegate(addToUIList), new object[] { result.fileName+":line "+result.LineNum+"="+result.lnInfo});
                }
            }

            this.Invoke(new VoidDelegate(enableBtns), new object[] { });
        }

        
        private void CheckAll()
        {

            List<String> lns = getFilterFiles(getAllFilesName(textBoxDir.Text));

            foreach (String ln in lns)
            {
                List<CheckResult> checkResults = judgeResult(ln);
                foreach (CheckResult result in checkResults)
                {
                    this.Invoke(new MsgDelegate(addToUIList), new object[] { result.fileName + ":line(" + result.LineNum + ")====>>" + result.lnInfo });
                }
            }

            this.Invoke(new VoidDelegate(enableBtns), new object[] { });
            
        }

        private void addToUIList(String ln)
        {
            listBoxResults.Items.Add(ln);
        }

        private List<string> getChangeFilesName(string p)
        {
            String result;
            List<String> results = new List<string>();
            try
            {
                result = Cmd.run("svn", "st " + p);
            }
            catch
            {
                MessageBox.Show("所选的文件夹不是一个svn库，增量检查只检查svn库文件夹\n请重新选择目录或者全部检查");
                return results;
            }
            //TODO结果为空怎么处理
            String[] lns = result.Split('\n');
            
            foreach (String ln in lns)
            { 
                if (ln.StartsWith("A") || ln.StartsWith("?")||ln.StartsWith("M"))
                {
                    String newln = ln.Substring(1).Trim();
                    if (File.Exists(newln))
                    {
                        results.Add(newln);
                    }
                    else if (Directory.Exists(newln))
                    {
                        results.AddRange(getAllFilesName(newln));
                    }
                }
            }

            return results;
        }

        private List<String> getAllFilesName(String path)
        {
            try
            {
                DirectoryInfo mydir = new DirectoryInfo(path);
                List<String> result = new List<string>();
                foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())
                {
                    if (fsi is FileInfo)
                    {
                        FileInfo fi = (FileInfo)fsi;
                        result.Add(fi.FullName);
                    }
                    else if (fsi is DirectoryInfo)
                    {
                        DirectoryInfo fi = (DirectoryInfo)fsi;
                        if (fi.Name.Contains(".svn")) continue;
                        result.AddRange(getAllFilesName(fi.FullName));
                    }
                }

                return result;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                this.Close();
                return new List<string>();
            }
        }

        private List<String> getFilters()
        {
            List<String> filters = new List<string>();
            String[] tags = textBoxFileType.Text.Split(',');
            foreach (String tag in tags)
            {
                filters.Add(tag.Trim());
            }
            return filters;
        }

        private List<String> getFilterFiles(List<String> oldFiles)
        {
            List<String> results = new List<string>();
            List<String> filters = getFilters();
            foreach (String fileName in oldFiles)
            {
                foreach (String filter in filters)
                {
                    if (fileName.EndsWith(filter))
                    {
                        results.Add(fileName);
                    }
                }
            }

            return results;
        }

        private void enableBtns()
        {
            btnAll.Enabled = true;
            btnChange.Enabled = true;
            MessageBox.Show("检查完毕");
        }
        private List<CheckResult> judgeResult(String fileName)
        {
            String[] lns = readFile(fileName).Split('\n');
            int lnum = 0;
            List<CheckResult> results = new List<CheckResult>();
            
            foreach (String line in lns)
            {
                lnum++;
                String ln = line.Trim();
                if (ln.StartsWith("/*")
                        && !(ln.StartsWith("/**") || ln.StartsWith("/* ")) && ln.Length != 2)
                {
                    //errString += "\n" + typeFile.fileName + "(行号:" + lnum + ")";
                    CheckResult result = new CheckResult();
                    result.fileName = fileName;
                    result.LineNum = lnum+"";
                    result.lnInfo ="不规范的注释"+ ln;
                    results.Add(result);
                    continue;
                }
                if (ln.EndsWith("*/")
                        && !(ln.EndsWith("**/") || ln.EndsWith(" */")) && ln.Length != 2)
                {
                    CheckResult result = new CheckResult();
                    result.fileName = fileName;
                    result.LineNum = lnum+"";
                    result.lnInfo = "不规范的注释" + ln;
                    results.Add(result);
                }
            }

            return results;
        }

        public  String readFile(String fileName)
        {
            if (radioButtongb232.Checked)
            {
                return readAsciiFile(fileName);
            }
            return readUTF8File(fileName);
        }

        private String readUTF8File(String fileName)
        {
            String result = "";
            try
            {
                FileStream aFile = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                result = sr.ReadToEnd();//一次性读入不会导致界面卡太久
                //result += strLine + "\n";
                //while (strLine != null)
                //{
                // strLine = sr.ReadLine();
                // result += strLine + "\n";
                //}
                sr.Close();
            }
            catch (IOException ex)
            {
                return "";
            }
            return result;
        }

        private String readAsciiFile(String fileName)
        {
            StringBuilder sb = new StringBuilder();
            String result = Cmd.ExecuteCmd("type "+fileName);
            String[] lns = result.Split('\n');
            for (int i = 4; i < lns.Length; i++)
            {
                sb.AppendLine(lns[i]);
            }
            return sb.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtongb232.Checked = true;
               Cmd.run("svn", "help");

               //Match m = Regex.Match("/*AB \n */", "^/\\*.*?\\*/$");
               //MessageBox.Show(m.Success+"");
            }
            catch (Exception ee)
            {
                MessageBox.Show("未安装svn客户端，请先安装svn客户端并确保已配置svn到环境变量PATH，即保证cmd中可以执行svn命令");
            }
        }
    }
}
