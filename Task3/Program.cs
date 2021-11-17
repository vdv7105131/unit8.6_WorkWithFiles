using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";
            string[] listD = GetDir(path);
            var result = GetSize(listD, path);
            Console.WriteLine($"Исхожный размер папки: {result} байт");

            DeleteDir(listD);
            DeleteFiles(listD, path);
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

            string[] listFilesFirstDir = Directory.GetFiles(path); // получает список файлов первой папки
            for (int i = 0; i < listFilesFirstDir.Length; i++)
            {
                FileInfo sizeF = new FileInfo(listFilesFirstDir[i]);
                long b = sizeF.Length;  // размер файла
                sum3 += b;
            }
            return sum + sum3;
        }

        static void DeleteDir(string[] listD)
        {
            for (int i = 0; i < listD.Length; i++)
            {
                try
                {
                    DirectoryInfo delDir = new DirectoryInfo(listD[i]);
                    if (delDir.Exists)
                    {
                        delDir.Delete(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static long DeleteFiles(string[] listD, string path)
        {
            long sum = 0;
            int num = 0;
            string[] listFiles = Directory.GetFiles(path); // получает список файлов

            for (int i = 0; i < listFiles.Length; i++)
            {
                FileInfo sizeF = new FileInfo(listFiles[i]);
                long size = sizeF.Length; // размер освобожденного места
                sum += size;
                num++;
                FileInfo delF = new FileInfo(listFiles[i]); // удаление
                delF.Delete();

                string name = sizeF.Name;
                Console.WriteLine(name);
            }
            Console.WriteLine($"Освобожденно: {sum} байт");
            Console.WriteLine($"Удаленно: {num} шт.");

            return sum;
        }
    }
}
