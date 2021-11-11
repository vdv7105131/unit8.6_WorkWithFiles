using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"";
        }

        //Напишите программу, которая чистит нужную нам папку от файлов
        //и папок, которые не использовались более 30 минут
        public void CleanFolder(string path)
        {
            TimeSpan.FromMinutes(30); // временной интервал 30 минут
        }
    }
}
