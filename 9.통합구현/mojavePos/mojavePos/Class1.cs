using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class LineSet
    {
       
        string imageRoute;
        int First_X;
        int First_Y;
        int Sscond_X;
        int Second_Y;

        public LineSet(int First_X, int First_Y, int Sscond_X, int Second_Y)
        {
            
            this.First_X = First_X;
            this.First_Y = First_Y;
            this.Sscond_X = Sscond_X;
            this.Second_Y = Second_Y;
           }

        public string ImageRoute { get => imageRoute; }
        public int PX { get => First_X; }
        public int PY { get => First_Y; }
        public int SX { get => Sscond_X; }
        public int SY { get => Second_Y; }
        
    }
}
