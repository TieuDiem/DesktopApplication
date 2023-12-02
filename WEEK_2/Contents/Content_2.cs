using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2.Contents
{
    class Content_2
    {
        public struct Defect1
        {
            public string nameDefect;
            public int width;
            public int height;
            public int area;

            public int numberDefect;
        }

        public Content_2()
        {
            //
            Defect1 df = new Defect1();
            df.height = 10;
            df.width = 10;
            df.area = 10;
            df.nameDefect = "This is defect 1";
            df.numberDefect = 10;

            Console.WriteLine(string.Format("Name cua defect la; {0}", df.nameDefect));

            Console.WriteLine(string.Format("Thong so height cua defect la: {0}", df.height));
        }
    }
}
