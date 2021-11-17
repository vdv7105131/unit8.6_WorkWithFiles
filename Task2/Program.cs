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
            var result = GetSize(q, path);
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

        static long GetSize(string[] dir, string path)
        {
            long sum = 0;
            long sum2 = 0;
            long sum3 = 0;

            for (int i = 0; i < dir.Length; i++)
            {
                string[] listFiles = Directory.GetFiles(dir[i]); // получает список файлов

                for (int j = 0; j < listFiles.Length; j++)
                {
                    FileInfo sizeF = new FileInfo(listFiles[j]);
                    long b = sizeF.Length;  // размер файла
                    sum2 += b;
                }
                sum += sum2;
            }

            string[] listFilesFirstDir = Directory.GetFiles(path); // получает список файлов
            for (int i = 0; i < listFilesFirstDir.Length; i++)
            {
                FileInfo sizeF = new FileInfo(listFilesFirstDir[i]);
                long b = sizeF.Length;  // размер файла
                sum3 += b;
            }
             return sum + sum3;
        }
    }
}
