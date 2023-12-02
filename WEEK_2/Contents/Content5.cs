using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2.Contents
{
    class Content5
    {
        public class DataSender : EventArgs
        {
            public int x;
            public DataSender(int _x)
            {
                x = _x;
            }
        }
        public event EventHandler suKienNhapSo;
        public Content5()
        {
            
        }
        public void startInput()
        {
            while (true)
            {
                Console.WriteLine("Nhap vao so bat ky: ");
                string input_value = Console.ReadLine();

                int value = int.Parse(input_value);

                suKienNhapSo?.Invoke(this, new DataSender(value));
            }
        }
    }
}
