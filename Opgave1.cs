using System;
using System.Threading;

namespace Opg1
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CountUp);
            Thread t2 = new Thread(CountDown);

            t1.Start();
            t2.Start();
        }

        static void CountUp()
        {
            while (true)
            {
                count += 2;
                Console.WriteLine(count + "| Up");

                Thread.Sleep(1000);
            }
        }

        static void CountDown()
        {
            while (true)
            {
                count -= 1;
                Console.WriteLine(count + "| Down");

                Thread.Sleep(1000);
            }
        }
    }
}
