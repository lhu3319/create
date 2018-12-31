using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class btnSet
    {
        Form form;
        Control control;
        string name,text;
        int sX, sY, pX, pY;

        public btnSet(Form form, string name, string text, int sX, int sY, int pX, int pY,EventHandler eh_btn)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_btn = eh_btn;

            this.control = null; // 예외처리
        }

        public btnSet(Control control, string name, string text, int sX, int sY, int pX, int pY, EventHandler eh_btn)
        {
            this.form = null; // 예외처리
            this.control = control;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_btn = eh_btn;
        }

        public EventHandler eh_btn;
        public Form Form
        {
            get { return form; }
        }
        public Control Control
        {
            get { return control; }
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
    }
}
