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

namespace mojavePos.Modal
{
    public partial class Receipt : Form
    {
        ListView lv;
        _Create ct = new _Create();
        public Receipt()
        {
            InitializeComponent();
            Load += Receipt_Load;
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            this.Size = new Size(400, 700);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            PictureBox mojave = new PictureBox();
            mojave.Image = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("모자브포스2");
            mojave.SizeMode = PictureBoxSizeMode.StretchImage;
            mojave.Size = new Size(250, 100);
            mojave.Location = new Point(75, 0);
            Controls.Add(mojave);

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "label1", "영수증", 100, 20, 150, 110, 10));
            arr.Add(new lbSet(this, "label2", "상호명: ", 60, 20, 0, 130, 11));
            arr.Add(new lbSet(this, "label10", "Mojaves", 120, 15, 60, 135, 10));
            arr.Add(new lbSet(this, "label4", "대표자: ", 60, 20, 0, 155, 11));
            arr.Add(new lbSet(this, "label11", "천호성", 100, 15, 60, 160, 10));
            arr.Add(new lbSet(this, "label5", "주소: ", 50, 20, 0, 180, 11));
            arr.Add(new lbSet(this, "label12", "서울특별시 금천구 가산디지털2로", 250, 15, 50, 185, 10));
            arr.Add(new lbSet(this, "label6", "\t          115, 509호, 811호 (가산동, 대륭테크노타운 3차)", 400, 15, 0, 205, 10));
            arr.Add(new lbSet(this, "label21", "거래일시:", 70, 20, 0, 225, 11));
            arr.Add(new lbSet(this, "label20", DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"), 400, 20, 68, 232, 10));

            for (int i = 0; i < arr.Count; i++)
            {
                Label lb = ct.lable((lbSet)arr[i]);
                if (i == 0) lb.Font = new Font("Tahoma", 15, FontStyle.Bold);
                if(i==1) lb.Font = new Font("Tahoma", 13, FontStyle.Bold);
                if (i == 3) lb.Font = new Font("Tahoma", 13, FontStyle.Bold);
                if (i == 5) lb.Font = new Font("Tahoma", 13, FontStyle.Bold);
                if (i == 8) lb.Font = new Font("Tahoma", 13, FontStyle.Bold);
                Controls.Add(lb);
            }
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "view", 350, 400, 25, 255, list_Click));
            lv = ct.listview((lvSet)list[0]);
            Controls.Add(lv);

            lv.Columns.Add("메뉴명", 100, HorizontalAlignment.Center);
            lv.Columns.Add("단가", 80, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 55, HorizontalAlignment.Center);
            lv.Columns.Add("금액", 107, HorizontalAlignment.Center);
            lv.Font = new Font("굴림", 11, FontStyle.Bold);
        }

        private void list_Click(object sender, MouseEventArgs e)
        {
            
        }
    }
}
