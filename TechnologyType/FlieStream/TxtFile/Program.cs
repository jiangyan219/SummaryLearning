using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TxtFile
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 读操作
            {
                //StreamReader sR = File.OpenText(@"C:\456.txt");
                ////string nextLine;
                ////while ((nextLine = sR.ReadLine()) != null)
                ////{
                ////    Console.WriteLine(nextLine);
                ////}

                //string txtStr = string.Empty;
                //if ((txtStr = sR.ReadToEnd()) != null)
                //{
                //    ////Console.WriteLine(txtStr);
                //    //string[] strkk=txtStr.Split('FA');
                //    //foreach(string strk in strkk)
                //    //{
                //    //   Console.WriteLine(strk+"\n");
                //    //}

                //    //int i = txtStr.IndexOf("FA");
                //    //int j = txtStr.IndexOf("FB");
                //    //string str = txtStr.Substring(i, j - i + 2);
                //    //Console.WriteLine(str + "\n");

                //    while (txtStr.Length > 0 && txtStr != " \r\n")
                //    {
                //        int i = txtStr.IndexOf("FA");
                //        int j = txtStr.IndexOf("FB");
                //        string str = txtStr.Substring(i, j - i + 2);
                //        Console.WriteLine(str + "\n");
                //        txtStr = txtStr.Remove(i, j + 2);

                //    }


                //    //string str = "ABCDEFG";

                //    //str= str.Remove(0,2);
                //    //int i = 1;




                //}

                //Console.Read();
                //sR.Close();
            }
            #endregion

            #region 写操作
            {
                #region 只能写入一行 无法不断写入
                //for (int i=0;i<10;i++)
                //{

                //    string str1 = DateTime.Now.ToString(); ;
                //    File.WriteAllText(@"D:\a.txt", str1);

                //    // 也可以指定编码方式 
                //    File.WriteAllText(@"D:\a.txt", str1, Encoding.ASCII);
                //}
                #endregion

                #region 可以写入多行
                try

                {
                    string path = @"D:\a.txt";

                    string str = System.DateTime.Now.ToString();
                    FileStream fs = new FileStream(path, FileMode.Append);//文本加入不覆盖

                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);//转码

                    sw.WriteLine(str);

                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();

                }
                catch (Exception)
                {


                }
                #endregion
            }
            #endregion

        }
    }
}
