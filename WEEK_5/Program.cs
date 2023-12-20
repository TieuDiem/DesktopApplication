using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WEEK_5.Contents;

namespace WEEK_5
{
    class Program
    {
        public static int count = 0;
        public static void DoSomeThing(string nameTask, int x, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("{0} - START", nameTask);
            Console.ResetColor();
            for (int i = 0; i < x; i++)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("{0} - {1}", nameTask, i);
                Thread.Sleep(500);
                Console.ResetColor();
            }
            Console.ForegroundColor = color;
            Console.WriteLine("{0} - END", nameTask);
            Console.ResetColor();
        }

        static object lock_count = new object();
        public static void InCreaseCount()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (lock_count)
                {
                    count++;
                }
            }
        }

        /* method Deadlock*/

        static object lock_dl_1 = new object();
        static object lock_dl_2 = new object();

        public static void method1()
        {
            Console.WriteLine("Deadlock");
            for (int i = 0; i < 50000; i++)
            {
                lock (lock_dl_1)
                {
                    lock (lock_dl_2)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine("UnDeadlock");
        }
        public static void method2()
        {
            Console.WriteLine("Deadlock");
            for (int i = 0; i < 50000; i++)
            {
                lock (lock_dl_2)
                {
                    lock (lock_dl_1)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine("UnDeadlock");
        }
        static void Main(string[] args)
        {
            //DoSomeThing("T1", 10, ConsoleColor.Red);
            //DoSomeThing("T2", 4, ConsoleColor.Yellow);
            //DoSomeThing("T3", 5, ConsoleColor.Blue);

            Thread t1 = new Thread(new ThreadStart(() => {
                method1();
            }));

            Thread t2 = new Thread(new ThreadStart(() => {
                method2();
            }));

            //Thread t3 = new Thread(new ThreadStart(() => {
            //    InCreaseCount();
            //}));

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();



            Task_Example task_Example = new Task_Example();


            Console.WriteLine("Gia tri cua bien Count: {0}", count);
            Console.WriteLine("___________________ FINISHED ___________________");
            //Console.ReadKey();
        }
    }
}
