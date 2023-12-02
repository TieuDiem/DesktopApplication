using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_3.Contents
{
    class Content2
    {
        public delegate void ShowInfor(string s);
        public ShowInfor showInfor;

        public Content2()
        {
            Console.WriteLine("---------------- Anonymous Type - Anonymous Method ----------------");

            var value = 1;

            //  Anonymous Type 

            var anonymous_type = new
            {
                toa_do_x = 10,
                toa_do_y = 10
            };
            // Get value 
            Console.WriteLine(string.Format("Toa do x:{0} toa do y:{1}", anonymous_type.toa_do_x, anonymous_type.toa_do_y));
            // Set value (can not set value)

            // Anonymous method         
            showInfor = (string s) => {
                Console.WriteLine(s);
            };
            showInfor?.Invoke("This is Anonymous Method");

        }
    }
}
