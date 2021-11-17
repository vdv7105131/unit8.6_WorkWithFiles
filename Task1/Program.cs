using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";
            string[] listD = GetDir(path);
            DeleteDir(listD);
            DeleteFiles(path);

        }

        //Напишите программу, которая чистит нужную нам папку от файлов
        //и папок, которые не использовались более 30 минут

        //При разработке постарайтесь предусмотреть возможные ошибки
        //(нет прав доступа, папка по заданному адресу не существует,
        //передан некорректный путь) и уведомить об этом пользователя.

        //2 балла(хорошо) : код должен удалять папки рекурсивно
        //(если в нашей папке лежит папка со вложенными файлами,
        //не должно возникнуть проблем с её удалением).
        //4 балла(отлично) : предусмотрена проверка на наличие папки
        //по заданному пути(строчка if directory.Exists); предусмотрена
        //обработка исключений при доступе к папке(блок try-catch,
        //а также логирует исключение в консоль).

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

        static void DeleteDir(string[] dir)
        {
            for (int i = 0; i < dir.Length; i++)
            {
                try
                {

                    DirectoryInfo delDir = new DirectoryInfo(dir[i]);
                    if (delDir.Exists)
                    {
                        TimeSpan.FromMinutes(30); // временной интервал 30 минут
                        delDir.Delete(true);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void DeleteFiles(string path)
        {
            string[] listFiles = Directory.GetFiles(path); // получает список файлов

            for (int i = 0; i < listFiles.Length; i++)
            {
                FileInfo delF = new FileInfo(listFiles[i]);
                delF.Delete();                
            }
        }
    }
}
