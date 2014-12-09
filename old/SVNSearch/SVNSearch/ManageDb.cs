using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SVNSearch
{
    class ManageDb
    {
        public static string dir = "db/";
        public static bool writeFile(String fileName,String data)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                FileInfo file = new FileInfo(ManageDb.dir + fileName);
                if(file.Exists)
                {
                    file.Delete();
                }
                FileStream aFile = new FileStream(ManageDb.dir + fileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);

                sw.Write(data);
                sw.Close();
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }

        public static String readFile(String fileName)
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


        public static List<String> getFileNames()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            return Directory.GetFiles(dir).ToList();
        }

        public static void rmFile(String fileName)
        {
            if (File.Exists(dir+fileName))
            {
                //如果存在则删除
                File.Delete(dir + fileName);
            }
        }
    }
}
