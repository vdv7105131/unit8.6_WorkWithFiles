using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";
            
            var q = GetDir(path);
            GetFiles(q);
        }

        // Напишите программу, которая считает размер папки на диске
        // (вместе со всеми вложенными папками и файлами). 
        // На вход метод принимает URL директории, в ответ — размер в байтах.

        static string[] GetDir(string path)
        {
            string[] listDir = Directory.GetDirectories(path); // получает список каталогов
            foreach (string s in listDir)
            {
                Console.WriteLine(s);
                GetDir(s);
            }
            return listDir;
        }

        static string[] GetFiles(string[] dir)
        {
            for (int i = 0; i < dir.Length; i++)
            {
                string[] listFiles = Directory.GetFiles(dir[i]); // получает список файлов
                                                                 // 
                FileInfo sizeF = new FileInfo(listFiles[i]);
                long b = sizeF.Length;  // размер файла
                Console.WriteLine(b);
            }         
            string[] a = {"", "" };
            return a;
        }
    }
}
