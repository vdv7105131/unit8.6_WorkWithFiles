using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";
            
            string[] q = GetDir(path);
            var result = GetFiles(q);
            Console.WriteLine($"Итого: {result} байт");
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

        static long GetFiles(string[] dir)
        {
            long sum = 0;
            long sum2 = 0;
            for (int i = 0; i < dir.Length; i++)
            {
                string[] listFiles = Directory.GetFiles(dir[i]); // получает список файлов

                FileInfo sizeF = new FileInfo(listFiles[i]);
                for (int j = 0; j < listFiles.Length; j++)
                {
                    long b = sizeF.Length;  // размер файла
                    sum2 += b;
                }
                sum += sum2;
            }         
            return sum;
        }
    }
}
