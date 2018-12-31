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
using WindowsFormsApp;

namespace mojavePos.Han
{
    public partial class MenuForm : Form
    {
        public static string camo_no , camo_no1;
        _Create ct = new _Create();
        Panel bottom, line;
        private Graphics gr;
        Module api = new Module();
        Button button, 수정버튼 ,수정버튼2;
        public string no;
        Category_Update_delete_modal CUD;
        Menu_update_delete_modal MCUD;
        ListView.SelectedListViewItemCollection slv, slv2;
        ListViewItem item , item2;
        public ListView listview2 , listview;
        public MenuForm()
        {
            InitializeComponent();
            Load += MenuForm_Load;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1200, 800);

            lvSet lv1 = new lvSet(this, "lv1", 300, 265, 170, 230, lv_mouseClick);
            listview = ct.listview(lv1);
            listview.Font = new Font("Tahoma", 20, FontStyle.Bold);
            listview.Items.Clear();
            listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listview.Columns.Add(" ", 0, HorizontalAlignment.Center);
            listview.Columns.Add(" ", 296, HorizontalAlignment.Center);
            Controls.Add(listview);
            api = new Module();
            api.selectListView("http://192.168.3.28:5000/mc_select", listview);
           

            lvSet lv2 = new lvSet(this, "lv2", 350, 500, 625, 230, lv2_mouseClick);
            listview2 = ct.listview(lv2);
            listview2.Font = new Font("Tahoma", 15, FontStyle.Bold);
            listview2.Columns.Add("", 0, HorizontalAlignment.Center);
            listview2.Columns.Add("메뉴명", 200, HorizontalAlignment.Center);
            listview2.Columns.Add("가격", 150, HorizontalAlignment.Center);

            //listview2.Columns.Add("변경/삭제", 100, HorizontalAlignment.Center);

            btnSet btn1_1 = new btnSet(this, "btn_1_1", "--", 30, 30, 370, 170, btn3_Click);
            수정버튼 = ct.btn(btn1_1);
            Controls.Add(수정버튼);

            btnSet btn2_1 = new btnSet(this, "btn_2_1", "--", 30, 30, 840, 170, btn4_Click);
            수정버튼2 = ct.btn(btn2_1);
            Controls.Add(수정버튼2);

            pnSet pn3 = new pnSet(this, 950, 2, 100, 218);
            line = ct.panel(pn3);
            Controls.Add(line);

            pnSet pn2 = new pnSet(this, 1200, 800, 0, 0);
            bottom = ct.panel(pn2); // 패널이름 : bottom
            Controls.Add(bottom);
            bottom.Controls.Add(listview);
            bottom.Controls.Add(listview2);
            bottom.Controls.Add(수정버튼);
            bottom.Controls.Add(수정버튼2);

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "lb1", "Category", 250, 60, 200, 100, 35));
            arr.Add(new btnSet(this, "btn_1", "", 30, 30, 330, 170, btn_Click));

            arr.Add(new pictureBoxSet(this, 40, 40, 280, 165, " "));
            arr.Add(new lbSet(this, "lb2", "Menu", 200, 50, 710, 100, 35));
            arr.Add(new btnSet(this, "btn_2", "", 30, 30, 800, 170, btn2_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 750, 165, " "));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.Font = new Font("Tahoma", 35, FontStyle.Bold);
                    label.BackColor = System.Drawing.Color.Transparent;
                    bottom.Controls.Add(label);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    button = ct.btn((btnSet)arr[i]);
                    button.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    button.BackgroundImage = mojavePos.Properties.Resources.버튼;
                    bottom.Controls.Add(button);
                }
                else if (typeof(pictureBoxSet) == arr[i].GetType())
                {
                    PictureBox picuturebox = ct.picture((pictureBoxSet)arr[i]);
                    picuturebox.BackgroundImage = mojavePos.Properties.Resources.coo1;
                    bottom.Controls.Add(picuturebox);
                }

            }

            //bottom.BackColor = Color.BurlyWood;
            bottom.BackgroundImage = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("배경화면1");

        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn_1":
                    Category_Insert_modal Me_mo = new Category_Insert_modal();
                    //Me_mo.Location = new Point(100, 100);
                    Me_mo.StartPosition = FormStartPosition.Manual;
                    Me_mo.Location = new System.Drawing.Point(550, 420); //모달 처음 위치값 지정<나중에 바꾸기>
                    Me_mo.ShowDialog();
                    api = new Module();
                    api.selectListView("http://192.168.3.28:5000/mc_select", listview);

                    break;
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn_2":
                    
                    run2();
                    break;
            }
        }
        private void lv_mouseClick(object o, MouseEventArgs e)
        {
            수정버튼 = new Button();
            api = new Module();
            button = new Button();
            CUD = new Category_Update_delete_modal();
            ListView lv = (ListView)o;
            slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                no = item.SubItems[0].Text;
                camo_no = item.SubItems[0].Text;
                
                this.No = camo_no;
            }
            api.selectListView_Menu("http://192.168.3.28:5000/mn_select", listview2, no);
        }
        private void lv2_mouseClick(object o, EventArgs e)
        {
            수정버튼2 = new Button();
            api = new Module();
            button = new Button();
            MCUD = new Menu_update_delete_modal();
            ListView lv2 = (ListView)o;
            slv2 = lv2.SelectedItems;
            for(int i = 0; i<slv2.Count; i++)
            {
                ListViewItem item2 = slv2[i];
                no = item2.SubItems[0].Text;
                camo_no1 = item2.SubItems[0].Text;
                
                this.No1 = camo_no1;
            }

        }
        private void btn3_Click(object o, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CUD.StartPosition = FormStartPosition.Manual;
                CUD.Location = new System.Drawing.Point(550, 420);
                CUD.ShowDialog();
                
                for (int i = 0; i < slv.Count; i++)
                {
                    item = slv[i];

                    CUD.textbox1.Text = item.SubItems[1].Text;
                   
                }
                api = new Module();
                api.selectListView("http://192.168.3.28:5000/mc_select", listview);
            }
            //MessageBox.Show(camo_no);
        }
        private void btn4_Click(object o, EventArgs e)
        {
            MenuForm mf = new MenuForm();
            if (MessageBox.Show("수정하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MCUD.StartPosition = FormStartPosition.Manual;
                MCUD.Location = new System.Drawing.Point(1000, 420);
                MCUD.ShowDialog();
                api = new Module();
                api.selectListView("http://192.168.3.28:5000/mn_select", listview);
                for (int i = 0; i < slv.Count; i++)
                {
                    item2 = slv2[i];
                    MCUD.textbox1.Text = item2.SubItems[1].Text;
                    MCUD.textbox2.Text = item2.SubItems[2].Text;
                }
            }
        }
        
        public string No
        {
            get
            {
                return camo_no;
            }
            set
            {
                camo_no = value;
            }
        }
        public string No1
        {
            get
            {
                return camo_no1;
            }
            set
            {
                camo_no1 = value;
            }
        }
        private delegate void del11();
        public void run2()
        {
            Menu_Insert_modal ff2 = new Menu_Insert_modal();

            ff2.StartPosition = FormStartPosition.Manual;
            ff2.Location = new System.Drawing.Point(1000, 420); //모달 처음 위치값 지정<나중에 바꾸기>
            ff2.ShowDialog();
            api = new Module();
            api.selectListView("http://192.168.3.28:5000/mc_select", listview);
            api.selectListView("http://192.168.3.28:5000/mn_select", listview);

            string sql = no;
          
            ff2.value1 = sql;
            ff2.sss();
        }
    }
}
