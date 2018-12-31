using mojavePos.Han;
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

namespace mojavePos.CHUN
{
    public partial class Menu_update_delete_modal : Form
    {
        _Create ct = new _Create();
        public TextBox textbox1, textbox2;
        private string mc_No;
        MenuForm mf;

        public Menu_update_delete_modal()
        {
            this.ControlBox = false;
            InitializeComponent();
            Load += Menu_update_delete_modal_Load;
        }

        private void Menu_update_delete_modal_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(350, 50);
            pnSet pn = new pnSet(this, 350, 50, 0, 0);
            Panel panel = ct.panel(pn);
            Controls.Add(panel);

            tbSet tb = new tbSet(this, "tb1", 150, 25, 50, 0);
            textbox1 = ct.txtbox(tb);
            textbox1.Font = new Font("Tahoma", 10, FontStyle.Bold);
            panel.Controls.Add(textbox1);

            tbSet tb2 = new tbSet(this, "tb2", 150, 25, 50, 25);
            textbox2 = ct.txtbox(tb2);
            textbox2.Font = new Font("Tahoma", 10, FontStyle.Bold);
            panel.Controls.Add(textbox2);

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "label1", "이름", 50, 25, 0, 0, 10));
            arr.Add(new lbSet(this, "label2", "가격", 50, 25, 0, 25, 10));
            arr.Add(new btnSet(this, "btn1", "수정", 50, 50, 200, 0, btn_click));
            arr.Add(new btnSet(this, "btn2", "삭제", 50, 50, 250, 0, btn_click));
            arr.Add(new btnSet(this, "btn3", "취소", 50, 50, 300, 0, btn_click));


            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    button.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    panel.Controls.Add(button);
                }
                else if (typeof(tbSet) == arr[i].GetType())
                {
                    TextBox textbox = ct.txtbox((tbSet)arr[i]);
                    textbox.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    panel.Controls.Add(textbox);
                }
                else if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    panel.Controls.Add(label);
                }
            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Hashtable ht = new Hashtable();
            Module api = new Module();
            mf = new MenuForm();
            switch (btn.Name)
            {
                case "btn1":
                    api = new Module();
                    ht.Add("m_Sort", mf.No1);
                    ht.Add("m_Name", textbox1.Text);
                    ht.Add("m_Price", textbox2.Text);
                    ht.Add("m_bNo",mf.No);
                    api.insert_Category("http://192.168.3.28:5000/mn_update", ht);
                    MessageBox.Show("수정하셨습니다.");
                    this.Close();
                    //Close();
                    break;
                case "btn2":
                    api = new Module();
                    //MessageBox.Show(mf.No , mf.No1);
                    ht.Add("m_bNo", mf.No);
                    ht.Add("m_Sort", mf.No1);
                    api.insert_Category("http://192.168.3.28:5000/mn_delete", ht);
                    //MessageBox.Show("삭제하셨습니다.");
                    this.Close();
                    //Close();
                    break;
                case "btn3":
                    this.Close();
                    MessageBox.Show("취소하셨습니다.");
                    break;
            }
        }
    }
}
