using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CheckBeforCommit
{
    class Cmd
    {
        public static String run(String exe,String cmd)
        {
            ProcessStartInfo start = new ProcessStartInfo(exe);//设置运行的命令行文件问ping.exe文件，这个文件系统会自己找到
            //如果是其它exe文件，则有可能需要指定详细路径，如运行winRar.exe
            start.Arguments = cmd;
            start.CreateNoWindow = true;//不显示dos命令行窗口
            start.RedirectStandardOutput = true;//
            start.RedirectStandardError = true;//
            start.RedirectStandardInput = true;//
            start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序
            Process p = Process.Start(start);
            StreamReader reader = p.StandardOutput;//截取输出流

            StringBuilder sb = new StringBuilder();
            while (!reader.EndOfStream)
            { 
                   String line = reader.ReadLine();//每次读取一行
                   sb.AppendLine(line);

            }

            if (sb.ToString().Trim().Length == 0)
            {
                while (!p.StandardError.EndOfStream)
                {
                    String line = p.StandardError.ReadLine();//每次读取一行
                    sb.AppendLine(line);

                }
                throw new Exception(sb.ToString());
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();//关闭进程
            reader.Close();//关闭流

            return sb.ToString();
        }

        public static String  ExecuteCmd(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine(command);

            p.StandardInput.WriteLine("exit");
            //p.WaitForExit();
            return p.StandardOutput.ReadToEnd(); 
        }
    }
}
