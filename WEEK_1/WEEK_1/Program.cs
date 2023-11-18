using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_1
{
    class Program
    {
        static void increase1(int a)
        {
            a = a + 1000;
        }
        static void increase2(ref int a)
        {
            a = a + 1000;
        }
        static void logInformation(string mess)
        {
            // Do somthing 
            Console.WriteLine(mess);
        }
        static int calcSum(int a, int b = 10)
        {
            int tong = a + b;
            return tong;
        }
        static void Main(string[] args)
        {
            int value_a = 100;
            Console.WriteLine(string.Format("Gia tri cua a truoc khi truyen vao ham increate1 la: {0}", value_a));
            increase1(value_a);
            Console.WriteLine(string.Format("Gia tri cua a sau khi truyen vao ham increate1 la: {0}", value_a));
            increase2(ref value_a);
            Console.WriteLine(string.Format("Gia tri cua a sau khi truyen vao ham increate2 la {0}", value_a));

            int tong = calcSum(10, 200);
            logInformation("This is information ");

            // Variables  and data type 
            int minThreshold = 200; // gạch dưới do khai báo ra mà không sử dụng
            int maxThreshold = 900;

            double minArea = 200;
            string logInfomation = "Area of Defect: ";

            char char_value = 'a'; // Khai báo biến với giá trị khởi tạo là false

            bool isDefect = false; // Khai báo biến với giá trị khởi tạo là false

            var bien_a = 10;
            var bien_b = "this is string";

            // Control Follow 
            bool isOnline = true;
            if (isOnline)
            {
                Console.WriteLine("This is Online Mode");
            }
            else
            {
                Console.WriteLine("This is Offline Mode");
            }
            // 
            int selectMode = 1;
            if (selectMode == 1)
            {
                // Block 1
                Console.WriteLine(string.Format("Bạn đang chọn mode {0}", selectMode));
            }
            else if (selectMode == 2)
            {
                // Block 2
                Console.WriteLine(string.Format("Bạn đang chọn mode {0}", selectMode));
            }
            else
            {
                // Block 3
                Console.WriteLine(string.Format("Bạn đang không chọn mode nào cả"));
            }

            // 
            int modeApp = 3; // modeApp= 1 -> Online  | modeApp =2 -> Offline

            switch (modeApp)
            {
                case 1:
                    // Do somthing , modeApp online 
                    Console.WriteLine("This in online mode");
                    break;
                case 2:
                    // Do somthing , modeApp online 
                    Console.WriteLine("This in offline mode");
                    break;

                default:
                    // Reset , Set Default 
                    Console.WriteLine("This in default mode");
                    break;
            }

            bool isRungning = false;
            while (false)
            {
                // Block while 
            }

            bool isContinue = false;


            int mode = 1;
            do
            {
                Console.WriteLine(string.Format("Value of mode {0}", mode));
                mode = mode + 1;
            } while (mode == 2);

            for (int i = 0; i < 10; i++)
            {
                // continue;
                Console.WriteLine(i);
                //break;  
                goto BLOCK1;
            }
        BLOCK1:

            List<int> listMode = new List<int>() { 10, 20 };

            foreach (var item in listMode)
            {
                Console.WriteLine(item);
            }
            try
            {
                int so_chia = 10;
                int so_bi_chia = 0;
                int thuong = so_chia / so_bi_chia;
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption occur");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            Console.ReadLine();
        }
    }
}
