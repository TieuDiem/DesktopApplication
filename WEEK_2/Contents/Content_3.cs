using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2.Contents
{
    class Content_3
    {
        public enum MODE_APP
        {
            ONLINE , 
            OFFLINE , 

            UNKNOW
        }
        public MODE_APP getCurrentMode(string s  )
        {
            switch (s)
            {
                case "1":
                    return MODE_APP.ONLINE;
                case "2":
                    return MODE_APP.OFFLINE;
                default:
                    break;
            }
            return MODE_APP.UNKNOW;
        }
        public Content_3()
        {
            MODE_APP mode= getCurrentMode("100");
            int a = 0;
        }
    }
}
