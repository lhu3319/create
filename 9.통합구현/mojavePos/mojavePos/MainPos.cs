using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    public partial class MainPos : Form
    {
        _Create ct = new _Create();
        public MainPos()
        {
            InitializeComponent();
            Load += MainPos_Load;
        }

        private void MainPos_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 900);
            
            Mainup_Load();
            btn_Load();
        }

        //메인Pos 상단바 UI
        private void Mainup_Load()
        {
            ArrayList arr = new ArrayList();

            arr.Add(new pnSet(this, 300, 100, 0, 0));
            arr.Add(new pnSet(this, 900, 100, 300, 0));
            arr.Add(new pnSet(this, 300, 100, 1200, 0));

            Panel pnl = new Panel();
            pnl = ct.panel((pnSet)arr[0]);
            pnl.BackColor = Color.Blue;
            Controls.Add(pnl);

            Panel pnl2 = new Panel();
            pnl2 = ct.panel((pnSet)arr[1]);
            pnl2.BackColor = Color.Gainsboro;
            Controls.Add(pnl2);

            Panel pnl3 = new Panel();
            pnl3 = ct.panel((pnSet)arr[2]);
            pnl3.BackColor = Color.Green;
            pnl3.Click += Pnl3_Click;
            Controls.Add(pnl3);

            lbSet lb = new lbSet(this, "라벨1", "MojavePos System", 400, 70, 300, 20, 40);
            Label label1 = ct.lable(lb);
            pnl2.Controls.Add(label1);

            lbSet lb2 = new lbSet(this, "라벨2", "종료", 150, 50, 100, 20, 35);
            Label label2 = ct.lable(lb2);
            pnl3.Controls.Add(label2);

        }
        //종료버튼 클릭시 이벤트
        private void Pnl3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdas");
        }
        
        private void btn_Load()
        {
            ArrayList arrayList = new ArrayList();

            for( int i  = 0; i<arrayList.Count; i++)
            {

            }
            arrayList.Add(new btnSet(this, "table1", " ", 200, 300, 100, 150, btn_Click));
            arrayList.Add(new btnSet(this, "table1", " ", 200, 300, 100, 550, btn_Click));
            arrayList.Add(new btnSet(this, "table1", " ", 200, 300, 400, 150, btn_Click));
            arrayList.Add(new btnSet(this, "table1", " ", 200, 300, 400, 550, btn_Click));
            for (int i = 0; i<arrayList.Count; i++)
            {
                ct.btn1((btnSet)arrayList[i]);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
