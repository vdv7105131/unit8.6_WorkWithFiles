using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    class Students
    {
        public string Name { get; set;}
        public string Group { get; set; }
        //public DateTime DateOfBirth { get; set;}

        public Students(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            //DateOfBirth = dateOfBirth;
        }
    }
    class Program
    {
        const string fileName = "Students.dat";

        static void Main(string[] args)
        {
            //1. Создать на рабочем столе директорию Students.
            //2. Внутри раскидать всех студентов из файла по группам 
            //  (каждая группа-отдельный текстовый файл), 
            //  в файле группы студенты перечислены построчно 
            //  в формате "Имя, дата рождения".

            string path = @"C:\Users\user\Desktop\Students";
            string pathF = @"C:\Users\user\Desktop\Students\file.txt";
            string pathS = @"C:\Users\user\Desktop\Students\Students.dat";

            CreatDir(path);
            CreatFiles(pathF);
            ReadValues();

        }

        static void CreatDir(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                }

                Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        static void CreatFiles(string path)
        {
            File.Create(path);
        }

        static void ReadValues()
        {
            //Свойства сущности Student:
            //Имя — Name(string);
            //Группа — Group(string);
            //Дата рождения — DateOfBirth(DateTime).

            // группа - отдельный тесктовый документ
            // в файле - "Имя, дата рождения"

            string pathS = @"C:\Users\user\Desktop\Students\Students.dat";



            BinaryFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream(pathS, FileMode.OpenOrCreate))
            {
                string[] studEx = new string[10];

                var newStud = formatter.Deserialize(fs);
                foreach (var stud in studEx)
                {
                    Console.WriteLine(stud);
                }
            }

        }
    }
}
