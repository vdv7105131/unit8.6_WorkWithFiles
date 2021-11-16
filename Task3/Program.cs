using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";

            string[] q = GetDir(path);
            var numberDir = GetFiles(q);
            Console.WriteLine($"Исходный размер папки: {numberDir} байт");
        }

        //Показать, сколько весит папка до очистки.Использовать метод из задания 2. 
        //Выполнить очистку.
        //Показать сколько файлов удалено и сколько места освобождено.
        //Показать, сколько папка весит после очистки.

        static string[] GetDir(string path)
        {
            string[] listDir = Directory.GetDirectories(path); // получает список каталогов
            foreach (string s in listDir)
            {
                //Console.WriteLine(s);
                GetDir(s);
            }
            return listDir;
        }

        static long GetFiles(string path)
        {
            long sum = 0;
            long sum2 = 0;

            string[] listDir = Directory.GetDirectories(path); // получает список каталогов
            foreach (string s in listDir)
            {
                //Console.WriteLine(s);
                GetDir(s);
            }

            for (int i = 0; i < listDir.Length; i++)
            {
                string[] listFiles = Directory.GetFiles(listDir[i]); // получает список файлов
                FileInfo sizeF = new FileInfo(listFiles[i]);
                for (int j = 0; j < listFiles.Length; j++)
                {
                    long b = sizeF.Length;  // размер файла
                    sum2 += b;
                }
                sum += sum2;


                try
                {
                    DirectoryInfo delF = new DirectoryInfo(path);
                    if (delF.Exists)
                    {
                        delF.Delete(true); // удаляем папку
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return sum;
        }
    }
}
