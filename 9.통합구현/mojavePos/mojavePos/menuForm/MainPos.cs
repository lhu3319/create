using mojavePos.Modules;
using Newtonsoft.Json.Linq;
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
        _Create ct= new _Create();
        private Panel pn4,pn5;
        private Commons comm;
        private Hashtable ht;
        private WebAPI api;
        private string tNo;

        public MainPos()
        {
            InitializeComponent();
            Load += MainPos_Load;
            //this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void MainPos_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            //this.BackColor = Color.DarkBlue;
            this.BackColor = Color.FromArgb(19, 38, 78);
            comm = new Commons();
            this.IsMdiContainer = true;
            this.ClientSize = new Size(1300, 900);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Mainup_Load();
            //button();
            btn_Load();
            
        }

        //메인Pos 상단바 UI
        private void Mainup_Load()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new pnSet(this, 1000, 100, 0, 0));
            arr.Add(new pnSet(this, 300, 100, 1000, 0));
            
            Panel pnl2 = new Panel();
            pnl2 = ct.panel((pnSet)arr[0]);
            pnl2.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(pnl2);

            PictureBox mojave = new PictureBox();
            mojave.Image = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("mojave");
            mojave.SizeMode = PictureBoxSizeMode.StretchImage;
            mojave.Size = new Size(200, 100);
            mojave.Location = new Point(0, 0);
            pnl2.Controls.Add(mojave);

            Panel pnl3 = new Panel();
            pnl3 = ct.panel((pnSet)arr[1]);
            pnl3.BackColor = Color.DimGray;
            pnl3.Click += Pnl3_Click;
            Controls.Add(pnl3);
            
            //arr.Add(new lbSet(this, "라벨1", "MojavePos System", 300, 70, 200, 20, 40));
            arr.Add(new lbSet(this, "라벨2", "종료", 150, 50, 100, 20, 35));
            
            Label label1 = ct.lable((lbSet)arr[2]);
            label1.Font = new Font("Tahoma", 35, FontStyle.Bold);
            pnl3.Controls.Add(label1);

            arr.Add(new pnSet(this, 1280, 780, 10, 110));
            pn4 = new Panel();
            pn4 = ct.panel((pnSet)arr[3]);
            //pn4.BackColor = Color.FromArgb(19, 38, 78);
            pn4.BackColor = Color.Beige;
            Controls.Add(pn4);

            arr.Add(new pnSet(this, 1300, 800, 0, 100));
            pn5 = ct.panel((pnSet)arr[4]);
            pn5.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(pn5);

        }
        //종료버튼 클릭시 이벤트
        private void Pnl3_Click(object sender, EventArgs e)
        {
            Dispose();
            FORM_03 f3 = new FORM_03();
            f3.Show();
        }


        //버튼 UI
        private void btn_Load()
        {
            ArrayList array = new ArrayList();

            array.Add(new pnSet(this, 10, 310, 480, 20));
            array.Add(new pnSet(this, 10, 310, 480, 450));
            array.Add(new pnSet(this, 420, 20, 30, 375));
            array.Add(new pnSet(this, 730, 20, 520, 375));
            array.Add(new pnSet(this, 730, 20, 520, 375));
            array.Add(new btnSet(this, "count", "카운트", 175, 310, 1080, 450, btn_Click));

            for (int i = 0; i < array.Count; i++)
            {
                if (typeof(pnSet) == array[i].GetType())
                {
                    Panel panel = ct.panel((pnSet)array[i]);
                    panel.BackColor = Color.Silver;
                    pn4.Controls.Add(panel);
                }
                if (typeof(btnSet) == array[i].GetType())
                {
                    Button button = ct.btn((btnSet)array[i]);
                    button.BackColor = Color.Silver;
                    button.Enabled = false;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    pn4.Controls.Add(button);
                }
            }
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "sp_Table_Select");
            ht.Add("param", "");
            ArrayList list = api.Select("http://192.168.3.28:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button3(pn4, list, btn_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    pn4.Controls.Add(button);
                }
            }
        }
        
        private ArrayList list;

        //버튼 이벤트
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //MessageBox.Show(btn.Name);
            //MessageBox.Show(btn.Text);
            tNo = btn.Text;
            ht = new Hashtable();
            ht.Add("spName", "sp_Order_Select");
            ht.Add("param", "_tNo:" + tNo);
            list = api.Select("http://192.168.3.28:5000/select", ht);


            CountView cv = new CountView(tNo,list);
            cv.MdiParent = this;
            cv.WindowState = FormWindowState.Maximized;
            cv.FormBorderStyle = FormBorderStyle.None;
            pn4.Controls.Add(cv);
            cv.Show();
        }
    }
}
