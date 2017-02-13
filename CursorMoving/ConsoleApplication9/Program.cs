using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFiles
{
    class CustomFolderInfo
    {
        CustomFolderInfo prev;
        int index;
        FileSystemInfo[] objs; //свойство для чтения, создания, удаления файла

        public CustomFolderInfo(CustomFolderInfo prev, int index, FileSystemInfo[] objs)//конструктор с тремя аргументами
        {
            this.prev = prev;
            this.index = index;
            this.objs = objs;
        }

        public void PrintFolderInfo()
        {
            Console.Clear();// Осищает консоль

            for (int i = 0; i < objs.Length; ++i)
            {
                if (i == index)// если индекс равен положению курсора, то цвета строки и бэкграунда соответсвующие
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(objs[i]);
            }
        }

        public void DecreaseIndex()//работа с индексом строки
        {
            if (index - 1 >= 0) index--;
        }

        public void IncreaseIndex()
        {
            if (index + 1 < objs.Length) index++;
        }

        public CustomFolderInfo GetNextItem()
        {
            FileSystemInfo active = objs[index];

            if (active.GetType() == typeof(DirectoryInfo))// если 
            {
                List<FileSystemInfo> list = new List<FileSystemInfo>();

                DirectoryInfo d = (DirectoryInfo)active;

                list.AddRange(d.GetDirectories());
                list.AddRange(d.GetFiles());

                CustomFolderInfo x = new CustomFolderInfo(this, 0, list.ToArray());
                return x;
            }
            else
            {
                Console.Clear();
                FileStream fs = new FileStream(active.FullName, FileMode.Open, FileAccess.Read);//открываем и получаем доступ к файлу
                StreamReader sr = new StreamReader(fs);//читаем строку в файле

                Console.WriteLine(sr.ReadToEnd());

                sr.Close();
                fs.Close();
            }

            return null;
        }

        public CustomFolderInfo GetPrevItem()
        {
            return prev;
        }
    }

    class Program
    {
        static void ShowFolderInfo(CustomFolderInfo item)
        {
            item.PrintFolderInfo();

            ConsoleKeyInfo pressedKey = Console.ReadKey();
            //работаем с клавиатурой
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                item.DecreaseIndex();
                ShowFolderInfo(item);
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                item.IncreaseIndex();
                ShowFolderInfo(item);
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                CustomFolderInfo newItem = item.GetNextItem();
                ShowFolderInfo(newItem);
            }
            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                CustomFolderInfo newItem = item.GetPrevItem();
                ShowFolderInfo(newItem);
            }
        }

        static void Main(string[] args)
        {
            
            List<FileSystemInfo> list = new List<FileSystemInfo>();

            var d = new DirectoryInfo(@"C:\");
            list.AddRange(d.GetDirectories());//возвращает имена подкаталогов
            list.AddRange(d.GetFiles());//возвращает имена файлов, включая пути

            CustomFolderInfo test = new CustomFolderInfo(null, 0, list.ToArray());
            ShowFolderInfo(test);
        }
    }
}