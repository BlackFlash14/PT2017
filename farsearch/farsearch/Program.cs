using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR_MNGR
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
        static void Main(string[] args)
        {
            //Setting default color for manager

            Console.WriteLine(@"Введите название фрагмента файла:");
            String Q = Console.ReadLine();
            Stack<DirectoryInfo> layers = new Stack<DirectoryInfo>();
            layers.Push(new DirectoryInfo(@"C:\Users\67493\Desktop\cf"));
            while (layers.Count > 0)
            {
                DirectoryInfo CurState = layers.Peek();
                layers.Pop();
                for (int i = 0; i < CurState.GetFileSystemInfos().Length; i++)
                {
                    if (CurState.GetFileSystemInfos()[i] is DirectoryInfo)
                    {
                        layers.Push(new DirectoryInfo(CurState.GetFileSystemInfos()[i].FullName));
                    }
                    else
                    {
                        if (CurState.GetFileSystemInfos()[i].Extension == ".docx")
                        {
                            if (DoesItContain(CurState.GetFileSystemInfos()[i].FullName, Q))
                            {
                                Console.WriteLine(CurState.GetFileSystemInfos()[i].FullName);
                            }
                        }
                    }
                }
            }
            Console.ReadKey();

        }
        static bool DoesItContain(string fullName, string query)
        {

            StreamReader tmp = new StreamReader(new FileStream(fullName, FileMode.Open, FileAccess.Read));
            string s = tmp.ReadToEnd();
            tmp.Close();
            return s.Contains(query);
        }


    }
}