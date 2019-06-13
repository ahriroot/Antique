using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ancient.Common
{
    public class ReadAndWrite
    {
        /// <summary>
        /// 提供TXT地址，读取全部文档，作为一行字符串返回
        /// </summary>
        /// <param name="file">文档地址</param>
        /// <returns></returns>
        public string AllOneLine(string file)
        {
            string str = File.ReadAllText(file, Encoding.Default);
            return str;
        }

        /// <summary>
        /// 提供TXT地址，将每行作为字符串读取存到数组中返回
        /// </summary>
        /// <param name="file">文档地址</param>
        /// <returns></returns>
        public string[] AllOneArray(string file)
        {
            string[] strs1 = File.ReadAllLines(file, Encoding.Default);
            return strs1;
        }

        /// <summary>
        /// 提供TXT地址，按流读取全部，作为一行字符串返回
        /// </summary>
        /// <param name="file">文档地址</param>
        /// <returns></returns>
        public string ReadStream(string file)
        {
            string str = "";
            StreamReader sr = new StreamReader(file, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                str += line.ToString();
            }
            return str;
        }

        /// <summary>
        /// 提供TXT地址，按流读取每行作为字符串存到列表中返回
        /// </summary>
        /// <param name="file">文档地址</param>
        /// <returns></returns>
        public List<string> ReadStreamList(string file)
        {
            List<string> strList = new List<string>();
            StreamReader sr = new StreamReader(file, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                strList.Add(line.ToString());
            }
            return strList;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 将字符串按行追加写入
        /// </summary>
        /// <param name="file">文档地址</param>
        /// <param name="str">写入字符串</param>
        public void WriteOneLine(string file, string str)
        {
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(str);
            sw.Close();
        }

        /// <summary>
        /// 将数组元素按行追加写入
        /// </summary>
        /// <param name="file">文档地址</param>
        /// <param name="strArray">写入数组</param>
        public void WriteArray(string file, string[] strArray)
        {
            StreamWriter sw = new StreamWriter(file, true);
            for (int i = 0; i < strArray.Length; i++)
            {
                sw.WriteLine(strArray[i]);
            }
            sw.Close();
        }

        public void FWriteArray(string file, string str)
        {
            File.WriteAllText(file, str, Encoding.Default);
        }
    }
}
