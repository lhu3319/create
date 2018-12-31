using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class lbSet
    {
        Form form;
        string name, text;
        int sX, sY, pX, pY,fs;

        public lbSet(Form form, string name, string text, int sX, int sY, int pX, int pY,int fs)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.fs = fs;
        }

        public Form Form
        {
            get { return form; }
        }
        public string Name
        {
            get { return name; }
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
        public int FS
        {
            get { return fs; }
        }
    }
}
