using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AidaThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread F = new Thread(Amina);
            Thread S = new Thread(Aida);
            //Program.Aida();
            //Program.Amina();
            F.Start();
            Program.Aida();


            Program tmp = new Program();

            Program.staticfunc();
            tmp.nonstaticfunc();

        }
        static void staticfunc()
        {

        }
        void nonstaticfunc()
        {

        }
        static void Amina()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Amina");
                Thread.Sleep(250);
            }
        }
        static void Aida()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Aida");
                Thread.Sleep(501);
            }
        }
    }
}
