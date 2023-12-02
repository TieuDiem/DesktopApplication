using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2.Contents
{
    class Content_4
    {
        /*
            Delegate
            Action 
            Func<>
         
         */
        public delegate void CallBack(string mess);
        public static CallBack CBDelegate;
        public void showInfor(string s)
        {
            Console.WriteLine(s);
        }

        public static Action<string> action;

        public string tinhTong(int a, int b)
        {

            return (a + b).ToString();
        }
        public static Func<int, int, string> tinhTongFunc;
        public Content_4()
        {
            // Dk nhan su kien 
            CBDelegate = showInfor;
            action = showInfor;
            tinhTongFunc = tinhTong;
        }
    }
}
