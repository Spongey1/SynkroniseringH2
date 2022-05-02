using System;
using System.Threading;

namespace Opg3
{
    class Program
    {
        static int count = 0;
        static object Lock = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Character('*'));
            Thread t2 = new Thread(() => Character('#'));

            t1.Start();
            t2.Start();
        }

        static void Character(char c)
        {
            while (true)
            {
                Monitor.Enter(Lock);
                {
                    try
                    {
                        count += 60;
                        Console.WriteLine(new string(c, 60) + " | " + count);
                    }
                    finally
                    {
                        Monitor.PulseAll(Lock);
                    }
                    Monitor.Exit(Lock);
                }
                Thread.Sleep(500);
            }
        }
    }
}
