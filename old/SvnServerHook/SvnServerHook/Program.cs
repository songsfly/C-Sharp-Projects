using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace SvnServerHook
{
    class Program
    {
        static void Main(string[] args)
        {

            String basecmd = "\"D:\\Program Files\\Subversion\\bin\\svnlook.exe\"";
            String changeCmd = " changed -t " + args[1] + " " + args[0];

            String result = runCmd(basecmd, changeCmd);
            //outputln(result);
            String[] files = result.Split("\n".ToCharArray());
            List<TypeFile> typeFiles = new List<TypeFile>();
            foreach (String file in files)
            {
                String name = file.Split(" ".ToCharArray())[file.Split(" ".ToCharArray()).Length - 1].Trim();
                if (name.EndsWith(".c") || name.EndsWith(".cpp")
                        || name.EndsWith(".h") || name.EndsWith(".inc"))
                {
                    TypeFile typeFile = new TypeFile();
                    typeFile.type = file.Split(" ".ToCharArray())[0];
                    // System.err.println(typeFile.type);
                    typeFile.fileName = name;
                    if (typeFile.type.Equals("U") || typeFile.type.Equals("A"))
                    {
                        String changeInfocmd = " cat -t " + args[1] + " "
                                + args[0] + name;

                        typeFile.change = runCmd(basecmd, changeInfocmd);
                        // outputln(getEcoding(typeFile.change).ToString());
                        //outputln(typeFile.change);
                        typeFiles.Add(typeFile);
                    }
                }

            }


            Environment.Exit(judgeResult(typeFiles));

        }

        private static Encoding getEcoding(String src)
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");//通过bodyname
            Encoding utf8 = Encoding.GetEncoding("utf-8");//通过bodyname

            byte[] buffer = Encoding.ASCII.GetBytes(src);
            string newString = Encoding.ASCII.GetString(buffer);
            if (src.Equals(newString))
            {
                return Encoding.ASCII;
            }

            buffer = Encoding.UTF8.GetBytes(src);
            newString = Encoding.UTF8.GetString(buffer);

            if (src.Equals(newString))
            {
                return utf8;
            }



            return null;

        }
        private static void outputln(String msg)
        {
            Console.Error.Write(msg + "\n");
        }
        private static int judgeResult(List<TypeFile> typeFiles)
        {
            String errString = "以下文件存在注释不规范";
            int ret = 0;
            foreach (TypeFile typeFile in typeFiles)
            {
                String[] lns = typeFile.change.Split("\n".ToCharArray());
                int lnum = 0;
                foreach (String line in lns)
                {
                    lnum++;



                    String ln = line.Trim();
                    if (ln.StartsWith("/*")
                            && !(ln.StartsWith("/**") || ln.StartsWith("/* "))&&ln.Length!=2)
                    {
                        errString += "\n" + typeFile.fileName + "(行号:" + lnum + ")";
                        ret = 1;
                       
                        continue;
                    }
                    if (ln.EndsWith("*/")
                            && !(ln.EndsWith("**/") || ln.EndsWith(" */")) && ln.Length != 2)
                    {
                        errString += "\n" + typeFile.fileName + "(行号:" + lnum + ")";
                        ret = 1;
                       
                    }
                }
            }
            if (ret == 1)
            {

                outputln(errString);
                outputln("不规范注释示例：/*我是注释*/");
                outputln("规范注释示例：/* 我是注释 */");
            }
            return ret;
        }


        private static String runCmd(String exe, String changeCmd)
        {
            ProcessStartInfo start = new ProcessStartInfo(exe);//设置运行的命令行文件问ping.exe文件，这个文件系统会自己找到
            //如果是其它exe文件，则有可能需要指定详细路径，如运行winRar.exe
            start.Arguments = changeCmd;//设置命令参数
            start.CreateNoWindow = true;//不显示dos命令行窗口
            start.RedirectStandardOutput = true;//
            start.RedirectStandardInput = true;//
            start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序
            Process p = Process.Start(start);
            StreamReader reader = p.StandardOutput;//截取输出流


            StringBuilder sb = new StringBuilder();

            string line = reader.ReadLine();//每次读取一行
            sb.Append(line + "\n");
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                sb.Append(line + "\n");
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();//关闭进程
            reader.Close();//关闭流
            return sb.ToString();
        }

    }
}

class TypeFile
{
    public String type;
    public String fileName;
    public String change;
}