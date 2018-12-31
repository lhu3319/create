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
    public partial class Coupon : Form
    {
        _Create ct = new _Create();
        private Button btn;

        public Coupon()
        {
            InitializeComponent();
            Load += Coupon_Load;
        }

        private void Coupon_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
            ClientSize = new Size(600, 550);
            pnSet pn = new pnSet(this, 510, 460, 50, 50);
            Panel panel = ct.panel(pn);
            panel.BackColor = Color.Gainsboro;
            Controls.Add(panel);

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "lb1", "할인 쿠폰", 250, 30, 200, 20, 20));
            arr.Add(new lbSet(this, "lb2", "전화 번호", 150, 30, 30, 80, 20));
            arr.Add(new tbSet(this, "tb1", 250, 30, 200, 80));
            arr.Add(new lvSet(this, "", 430, 200, 40, 150, list_Click));
            arr.Add(new btnSet(this, "완료", "완료", 100, 50, 100, 370, btn_Click));
            arr.Add(new btnSet(this, "취소", "취소", 100, 50, 300, 370, btn_Click));

            
            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    panel.Controls.Add(label);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if (typeof(lvSet) == arr[i].GetType())
                {
                    ListView listView = ct.listview((lvSet)arr[i]);
                    panel.Controls.Add(listView);
                    listView.BackColor = Color.WhiteSmoke;
                    listView.Columns.Add("전화번호", 120, HorizontalAlignment.Center);
                    listView.Columns.Add("쿠폰", 150, HorizontalAlignment.Center);
                    listView.Columns.Add("기간", 160, HorizontalAlignment.Center);

                }
                else if (typeof(tbSet) == arr[i].GetType())
                {
                    TextBox textbox = ct.txtbox((tbSet)arr[i]);
                    panel.Controls.Add(textbox);
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            switch (btn.Name)
            {
                case "완료":
                    break;
                case "취소":
                    Dispose();
                    break;
                default:
                    break;
            }
        }

        private void list_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
        }
    }
}
