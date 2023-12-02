using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEEK_2.Contents;
using static WEEK_2.Contents.Content5;

namespace WEEK_2
{
    /*
        1. Class - OOP 
        2. Struct
        3. Enum 
        4. Event Driven programing
     */


    class Camera
    {
        public int width;
        
        public int height { get; set; }

        public int mode;
        public Camera(int _width, int _height, int _mode)
        {
            width = _width;
            height = _height;
            mode = _mode;
        }
        public Camera()
        {

        }
        public Camera(int _width, int _height)
        {
            width = _width;
            height = _height;
        }

        void snap()
        {
            Console.WriteLine("Goi ham snap");
        }

        void stream()
        {
            Console.WriteLine("Goi ham stream");
        }
    }
    class Can
    {
        public Can(Content5 ct5)
        {
            ct5.suKienNhapSo += tinhCan;
        }
        public void tinhCan(object sender, EventArgs e)
        {
            DataSender data = (DataSender)e;

            double can = Math.Sqrt(data.x);
            Console.WriteLine(string.Format("Binh phuong cua {0} bang: {1} ", data.x, can));
        }
        public void Cancel(Content5 ct5)
        {
            ct5.suKienNhapSo -= tinhCan;
        }
    }
    class BinhPhuong
    {
        public BinhPhuong(Content5 ct5)
        {
            ct5.suKienNhapSo += tinhBinhPhuong;
        }
        public void tinhBinhPhuong (object sender, EventArgs e)
        {
            DataSender data = (DataSender)e;
            int binhPhuong = data.x * data.x;
            Console.WriteLine(string.Format("Binh phuong cua {0} bang: {1} ", data.x, binhPhuong));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //// mode= 1 : gray scale
            //Camera camera1 = new Camera(1800, 1050);

            //Console.WriteLine(string.Format("Height cua camera1: {0}", camera1.height));
            //Console.WriteLine(string.Format("Width cua camera1: {0}", camera1.width));
            //Console.WriteLine(string.Format("Mode cua camera1: {0}", camera1.mode));

            //// mode =2: Color 
            //Camera camera2 = new Camera(2400, 2024, 2);
            //Console.WriteLine(string.Format("Height cua camera2: {0}", camera2.height));
            //Console.WriteLine(string.Format("Width cua camera2: {0}", camera2.width));
            //Console.WriteLine(string.Format("Mode cua camera2: {0}", camera2.mode));
            //// 


            //Content_1 ct1 = new Content_1();
            //Content_2 ct2 = new Content_2();

            //Content_3 ct3 = new Content_3();

            //Content_4 ct4 = new Content_4();

            // Phat di su kien 
            //Content_4.CBDelegate?.Invoke("Calling delegate");
            //Content_4.action?.Invoke("Calling ACtion");
            //string tong = Content_4. tinhTongFunc?.Invoke(100, 200);


            //Console.WriteLine(string.Format("Tong la: {0}", tong));
            Content5 ct5 = new Content5();

            BinhPhuong binhPhuong = new BinhPhuong(ct5);
            Can can = new Can(ct5);
            can.Cancel(ct5);

            ct5.startInput();
            Console.ReadLine();
        }
    }
}
