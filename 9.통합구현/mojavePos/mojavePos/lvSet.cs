using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class lvSet
    {
        Form form;
        string text;
        int sX, sY, pX, pY;
        public MouseEventHandler listview;
        public lvSet(Form form, string text, int sX, int sY, int pX, int pY, MouseEventHandler listview)
        {
            this.form = form;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.listview = listview;
        }

        public Form Form
        {
            get { return form; }
        }
        public string Text
        {
            get { return text; }
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

