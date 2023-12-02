using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_2.Contents
{
    /*
     
      Xay dung OOP

     */
    
    public static class ImbLib 
    {

        // img : chinhs la du kieu buc anh
        public static void threshold(string img, int T) {
            // Thu hien threshold
        }
    }
    public interface ICamera
    {
        void snap();
        void stream();

    }
    public abstract class CameraBase
    {
        public int width;
        public int height;
        public int mode;

        public CameraBase(int _width, int _height, int _mode){}
    }

    class Camera1 : CameraBase , ICamera  {

        public int field_of_camera;
        public Camera1(int _width, int _height, int _mode, int filed): base(_width, _height, _mode)
        {
            width = _width;
            height = _height;
            mode = _mode;
            field_of_camera = filed;
        }

        public void snap()
        {
            Console.WriteLine("Call snap from Camera1");
        }

        public void stream()
        {
            Console.WriteLine("Call stream from Camera1");
        }

        public void A() { }

    }

    class Camera2: CameraBase , ICamera
    {
        public Camera2(int _width, int _height,int _mode): base(_width, _height, _mode)
        {
            width = _width;
            height = _height;
            mode = _mode;
        }

        public void snap()
        {
            // 
            Console.WriteLine("Call snap from Camera2");
        }

        public void stream()
        {
            Console.WriteLine("Call stream from Camera2");
        }

        public void B() { }
    }
    class Content_1
    {
        public Content_1()
        {
            Camera1 cm1 = new Camera1(1800, 1050, 1,55);
            cm1.field_of_camera = 100;
            Console.WriteLine(string.Format("field : {0}", cm1.field_of_camera));
            cm1.snap();
            cm1.stream();

            Camera2 cm2 = new Camera2(2480, 2040, 3);
            cm2.snap();
            cm2.stream();

            // CvImage 
            ImbLib.threshold("asada", 10);

           

        }
    }
}
