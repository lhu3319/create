using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace mojavePos
{
    class DateSet
    {
        Form form;
        string name;
        int sX, sY, pX, pY;

        public DateSet(Form form, string name, int sX, int sY,int pX,int pY)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY; 
        }
        public Form Form
        {
            get { return form; }
        }
        public string Name
        {
            get { return name; }
        }
        public int SX
        {
            get { return sX; }
        }
        public int SY
        {
            get { return sY; }
        }
        public int PX
        {
            get { return pX; }
        }
        public int PY
        {
            get { return pY; }
        }
    }
}
