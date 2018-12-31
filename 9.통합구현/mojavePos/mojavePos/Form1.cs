using System;
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
    public partial class Form1 : Form
    {
        int sX = 1500, sY = 700; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        /////////////////////////////////////
  


        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            _Create ct = new _Create();
            Point_Print();


            //버튼 생성 방법
            btnSet 버튼객체 = new btnSet(this, "button", "버튼1번", 100, 100, 0, 100,btn_Click);
            Button 버튼생성 = ct.btn(버튼객체);
            Controls.Add(버튼생성);

            //라벨 생성 방법
            lbSet lb1 = new lbSet(this, "label1", "라벨.", 50, 50, 100, 40,10);
            Label 라벨 = ct.lable(lb1);
            Controls.Add(라벨);
            
            //패널 생성 방법
            pnSet pn1 = new pnSet(this, 600, 100, 30, 30 );
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.Aqua;
            Controls.Add(패널);   //패널 화면 출력
            패널.Controls.Add(라벨);    //패널 위에 라벨 출력

            //텍스트박스 출력
            tbSet tx1 = new tbSet(this, "txt1", 100, 30, 150, 150);
            TextBox test = ct.txtbox(tx1);
            Controls.Add(test);

            //리스트뷰 출력
            lvSet lv1 = new lvSet(this, "리스트", 400, 400, 200, 200,lv_mouseClick);
            ListView 리스트뷰 = ct.listview(lv1);
            Controls.Add(리스트뷰);

            //픽처박스 출력
            pictureBoxSet 픽쳐박스 = new pictureBoxSet(this, 60, 60, 0, 300," ");
            PictureBox 픽박출력 = ct.picture(픽쳐박스);
            픽박출력.BackColor = Color.Green;
            Controls.Add(픽박출력);

            //콤보박스 출력
            /*
            comboboxSet 콤보박스 = new comboboxSet(this, "콤박1",30, 30, 700, 200, cbox_mouseClick);
            ComboBox 콤박출력 = ct.combobox(콤보박스);
            Controls.Add(콤박출력);
            */




        }

        private void cbox_mouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lv_mouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }











        ///////////////////////// 좌표 체크시 추가 /////////////////////////////

        private void Point_Print()
        {

            MouseMove += new MouseEventHandler(this.Current_FORM_MouseMove);
            statusStrip = new StatusStrip();
            StripLb = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripLb });
            statusStrip.Location = new Point(0, sY);
            statusStrip.Name = "statusStrip1";
            statusStrip.Size = new Size(sX, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // toolStripStatusLabel1
            StripLb.Name = "StripLb1";
            StripLb.Size = new Size(121, 17);
            StripLb.Text = "StripLb1";
            Controls.Add(statusStrip);
        }
        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
    }
}
