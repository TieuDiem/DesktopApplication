using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WEEK_5.Contents
{
    public class Task_Example
    {
        public static object lock_color = new object(); 
        public static void DoSomeThing(string nameTask, int x, ConsoleColor color)
        {
            lock (lock_color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("{0} - START", nameTask);
                Console.ResetColor();
            }
           
            for (int i = 0; i < x; i++)
            {
                lock (lock_color)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine("{0} - {1}", nameTask, i);
                    Thread.Sleep(500);
                    Console.ResetColor();
                }
               
            }
            lock (lock_color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("{0} - END", nameTask);
                Console.ResetColor();
            }
           
        }

        public async Task get_t1()
        {
            Task task = new Task(() =>
            {
                DoSomeThing("T1", 10, ConsoleColor.Red);
            });
            task.Start();
            await task;
           
        }
        public async Task get_t2()
        {
            Task task = new Task(() =>
            {
                DoSomeThing("T2", 4, ConsoleColor.Yellow);
            });

            task.Start();
            await task;
        }
        public async Task get_t3()
        {
            Task task = new Task(() =>
            {
                DoSomeThing("T3", 5, ConsoleColor.Blue);
            });

            task.Start();
            await task;
        }
        public Task_Example()
        {
            Task a;
            a = get_t1();
            a = get_t2();
            a = get_t3();
            Console.ReadKey();
        }
    }
}
