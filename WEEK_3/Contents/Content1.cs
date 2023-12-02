using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_3.Contents
{
    class Content1
    {
        class Point
        {
            public int x;
            public int y;
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            public override string ToString()
            {
                Console.WriteLine(string.Format("Toa do x:{0} y:{1}", x, y));
                return "";
            }
        }
        class ImageSave
        {
            string path_image;
            byte[] bufferImage;
        }
        List<Point> list_point;
        Queue<Point> queue_point = new Queue<Point>(); // Vao truoc ra truoc

        Stack<Point> stack_point = new Stack<Point>();

        Dictionary<string, Point> dict_point = new Dictionary<string, Point>() {
            { "1",new Point(1,0) },
            { "2",new Point(3,2) },
            { "3",new Point(1,5) },
            { "4",new Point(2,20) },
        };
        public Content1()
        {
            list_point = new List<Point>()
            {
                new Point(1,98),
                new Point(10,3),
                new Point(36,30),
                new Point(23,3),
            };
            list_point.Add(new Point(3, 3));
            int count = list_point.Count();
            Point p = list_point[4];

            /*Queue*/
            Console.WriteLine("-------------------------------- Queue");
            queue_point.Enqueue(new Point(1, 98));
            queue_point.Enqueue(new Point(10, 3));
            queue_point.Enqueue(new Point(36, 30));
            queue_point.Enqueue(new Point(23, 3));


            while (queue_point.Count() >= 1)
            {
                Point p1 = queue_point.Dequeue();
                p1.ToString();
            }

            // Stack (Push, Pop)
            Console.WriteLine("-------------------------------- Stack");
            stack_point.Push(new Point(1, 98));
            stack_point.Push(new Point(10, 3));
            stack_point.Push(new Point(36, 30));
            stack_point.Push(new Point(23, 3));

            while (stack_point.Count() >= 1)
            {
                Point p2 = stack_point.Pop();
                p2.ToString();
            }
            // Dictionary
            Console.WriteLine("-------------------------------- Dictionary");
            dict_point.Add("5", new Point(29, 30));
            dict_point["3"] = new Point(20, 3);

            //
            foreach (var item in dict_point.Keys)
            {
                var point = dict_point[item];
                //point.ToString();
            }

            /* Truy van Linq */
            /* Lấy ra tập hợp những điểm point hoặc những thuộc tính/ trường dữ liệu của điểm point đó*/
            Console.WriteLine("------------------------ Select ------------------------");

            var result = list_point.Select((point_select) =>
            {
                return point_select.y;
            });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            /* Từ list_point ban đâu lấy ra tất cả những điểm có tọa độ x lớn hơn 10 và lưu chúng vào biến result2 */
            Console.WriteLine("------------------------ from select where -> return object (Instance of class) ------------------------");

            var result2 = from point in list_point where point.x <= 10 select point;
            foreach (var item in result2)
            {
                item.ToString();
            }

            /* Từ list_point ban đâu lấy ra tất cả những điểm có tọa độ x nhỏ hơn hoặc bằng 10 và lưu chúng vào biến result3 là 
            kiểu dữ liệu Anonymous chứa các thuộc tính mới là toa_do_x và toa_do_y
             */
            Console.WriteLine("------------------------ from select where -> return Anonymous Type ------------------------");
            var result3 = from point in list_point
                          where point.x <= 10
                          select new
                          {
                              toa_do_x = point.x,
                              toa_do_y = point.y
                          };

            foreach (var item in result3)
            {
                Console.WriteLine("Toa do x:{0} toa do y:{1}", item.toa_do_x, item.toa_do_y);
            }

            /* Phương thức FindAll -> Tìm tất cả các point có trong list_point và trả về những point nào có tọa độ x > threshold*/
            /* Phương thức FindAll truyền vào tham số là delegate có kierur trả về là True và False và tham số trong delegate phải phù hợp với kiểu dự liệu của List<T>*/
            Console.WriteLine("------------------------ Find All ------------------------");
            int threshold = 2;
            Predicate<Point> greater = (Point point) => {
                if (point.x > threshold) { return true; }
                else { return false; }
            };
            List<Point> resul4 = list_point.FindAll(greater);
            foreach (var item in resul4)
            {
                Console.WriteLine("Toa do x:{0} toa do y:{1}", item.x, item.y);
            }
            /* Any Tìm xem trong List<Point> đã cho có điểm nào có point.x ==1 và point.x==2 không, nếu có trả về giá trị True, nếu không trả về giá trị False */
            Console.WriteLine("------------------------ Any ------------------------");
            Func<Point, bool> isAny = (Point point) => {
                if (point.x == 1 && point.y == 2) { return true; } else { return false; }
            };
            var isHave = list_point.Any(isAny);

            Console.WriteLine(string.Format("Co diem nao trong list_poitn x=1 va y==2 khong ? : {0}", isHave));

        }
    }
}
