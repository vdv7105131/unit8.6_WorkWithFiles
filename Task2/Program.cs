using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";
            string path1 = @"C:\Users\user\Desktop\111\text.txt";
            SizeFolder(path);
        }

        // Напишите программу, которая считает размер папки на диске
        // (вместе со всеми вложенными папками и файлами). 
        // На вход метод принимает URL директории, в ответ — размер в байтах.

        static void SizeFolder(string path)
        {
            //DirectoryInfo sizeF = new DirectoryInfo(path);
            //sizeF.GetFiles();       // получает список файлов
            //sizeF.GetDirectories(); // получает список каталогов

            string[] listFolder = Directory.GetDirectories(path); // получает список каталогов
            foreach (string s in listFolder)
            {
                Console.WriteLine(s);
            }
                

            string[] listFiles = Directory.GetFiles(path); // получает список файлов
            long sumSize = 0;
            foreach (string q in listFiles)
            {
                Console.WriteLine(q);
                FileInfo sizeF = new FileInfo(q);
                long a = sizeF.Length;  // размер файла
                Console.WriteLine(a);
                sumSize += a;
            }
            //преобразование long to byte
            //byte[] byteArray = BitConverter.GetBytes(sumSize);
            Console.WriteLine($"Размер в байтах: {sumSize}");

        }
    }
}
