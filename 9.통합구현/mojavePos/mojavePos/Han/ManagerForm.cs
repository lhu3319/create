using mojavePos.CHUN;
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

namespace mojavePos.Han
{
    public partial class ManagerForm : Form
    {
        _Create ct = new _Create();
        Panel bottom;
        private Graphics gr;
        MenuForm menu;

        public ManagerForm()
        {
            InitializeComponent();
            Load += MemberForm_Load;
        }
        private void MemberForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1200, 900);
            this.IsMdiContainer = true;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Head();

          
        }
        private void Head()
        {


            pnSet pn1 = new pnSet(this, 1200, 100, 0, 0);
            Panel head = ct.panel(pn1);
            Controls.Add(head);

            PictureBox mojave = new PictureBox();
            mojave.Image = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("mojave");
            mojave.SizeMode = PictureBoxSizeMode.StretchImage;
            mojave.BackColor = Color.FromArgb(19, 38, 78);
            mojave.Size = new Size(240, 100);
            mojave.Location = new Point(0, 0);
            head.Controls.Add(mojave);

            pnSet pn2 = new pnSet(this, 1200, 800, 0, 100);
           bottom = ct.panel(pn2); // 패널이름 : bottom
           Controls.Add(bottom);

            MenuForm mf = new MenuForm();
            mf.MdiParent = this;
            mf.WindowState = FormWindowState.Maximized;
            mf.FormBorderStyle = FormBorderStyle.None;
            bottom.Controls.Add(mf);
            mf.Show();
            
            ArrayList btn_list = new ArrayList();
            //btn_list.Add(new btnSet(this, "image", "image", 300, 100, 0, 0, Main_Click));
            btn_list.Add(new btnSet(this, "menu", "메뉴관리", 240, 100, 240, 0, Main_Click));
            btn_list.Add(new btnSet(this, "money", "매출관리", 240, 100, 480, 0, Main_Click));
            btn_list.Add(new btnSet(this, "rank", "메뉴순위", 240, 100, 720, 0, Main_Click));
            btn_list.Add(new btnSet(this, "exit", "종료", 240, 100, 960, 0, Main_Click));

            for (int i=0; i < btn_list.Count; i++)
            {
                Button button = ct.btn((btnSet)btn_list[i]);
                button.BackColor = Color.FromArgb(19, 38, 78);
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                head.Controls.Add(button);
            }

        }
        private void Main_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "menu":
                    MenuForm menu = new MenuForm();
                    menu.MdiParent = this;
                    menu.WindowState = FormWindowState.Maximized;
                    menu.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(menu);
                    menu.Show();
                    break;
                case "money":
                    MoneyForm  money= new MoneyForm();
                    money.MdiParent = this;
                    money.WindowState = FormWindowState.Maximized;
                    money.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(money);
                    money.Show();
                    break;
                
                case "rank":
                    RankForm rf = new RankForm();
                    rf.MdiParent = this;
                    rf.WindowState = FormWindowState.Maximized;
                    rf.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(rf);
                    rf.Show();
                    break;
                case "exit":
                    FORM_03 F3 = new FORM_03();
                    Close();
                    break;
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch(btn.Name)
            {
                case "btn_1":
                    Category_Insert_modal Me_mo = new Category_Insert_modal();
                    Me_mo.Location = new Point(100, 100);
                    Me_mo.StartPosition = FormStartPosition.Manual;
                    Me_mo.Location = new System.Drawing.Point(240, 30); //모달 처음 위치값 지정<나중에 바꾸기>
                    Me_mo.BackColor = Color.Black;
                    Me_mo.Show();
                    break;
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
    }
}
