using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPaste
{
    class State
    {
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                int maxVal = Folder.GetFileSystemInfos().Length;
                if (value >= 0 && value < maxVal)
                {
                    index = value;
                }
            }
        }
        public DirectoryInfo Folder { get; set; }
    }


    class Program
    {
        static void ShowFolderContent(State state)
        {
            Console.Clear();
            FileSystemInfo[] list = state.Folder.GetFileSystemInfos();


            for (int i = 0; i < list.Length; ++i)
            {
                if (state.Index == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (list[i] is DirectoryInfo)
                {

                    Console.Write("[+] " + list[i]);
                }
                else
                {
                    Console.Write(list[i]);

                }
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

        }


        static void Main(string[] args)
        {
            //Setting default color for manager
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            bool alive = true;
            State state = new State { Folder = new DirectoryInfo(@"C:\Users\67493\Desktop\cf"), Index = 0 };
            Stack<State> layers = new Stack<State>();
            layers.Push(state);
            FileSystemInfo CopyFileName = new DirectoryInfo(@"C:\Users\67493\Desktop\cf");
            while (alive)
            {

                ShowFolderContent(layers.Peek());
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                FileSystemInfo[] list;
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        layers.Peek().Index--;
                        break;
                    case ConsoleKey.DownArrow:
                        layers.Peek().Index++;
                        break;
                    case ConsoleKey.Escape:
                        if (layers.Count != 1)
                            layers.Pop();
                        break;
                    case ConsoleKey.Enter:
                        list = layers.Peek().Folder.GetFileSystemInfos();
                        if (list[layers.Peek().Index] is DirectoryInfo)
                        {
                            State newState = new State
                            {
                                Folder = new DirectoryInfo(list[layers.Peek().Index].FullName),
                                Index = 0
                            };
                            layers.Push(newState);
                            break;
                        }
                        break;
                    case ConsoleKey.C:
                        list = layers.Peek().Folder.GetFileSystemInfos();
                        CopyFileName = list[layers.Peek().Index];
                        break;
                    case ConsoleKey.P:
                        string NewPath = Path.Combine(layers.Peek().Folder.FullName, CopyFileName.Name);
                        File.Copy(CopyFileName.FullName, NewPath);
                        break;
                    case ConsoleKey.N:
                        string NFN = Console.ReadLine();
                        Directory.CreateDirectory(Path.Combine(layers.Peek().Folder.FullName, NFN));

                        break;
                }
            }

        }
    }
}