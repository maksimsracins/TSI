using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        static void thread()
        {
            for (int i = -100; i < 0; i++)
            {
                Console.WriteLine($"THREAD:{i}");
                Console.ForegroundColor= ConsoleColor.Red;
            }
        }


        static void Main(string[] args)
        {
            //thread();
            Thread t = new Thread(thread);
            t.Start();
            t.Join(); //wait until stream before will finish
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"MAIN:{i}");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ReadLine();
        }
    }
}
