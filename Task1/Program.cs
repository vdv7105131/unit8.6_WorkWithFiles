using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\111";
            DelFolder(path);
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


        static void DelFolder(string path)
        {
            try
            {
                DirectoryInfo delF = new DirectoryInfo(path);
                if (delF.Exists)
                {
                TimeSpan.FromMinutes(30); // временной интервал 30 минут
                delF.Delete(true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
