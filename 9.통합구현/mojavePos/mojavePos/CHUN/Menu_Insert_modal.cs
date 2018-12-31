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
    public partial class Menu_Insert_modal : Form
    {
        _Create ct = new _Create();
        TextBox textbox1, textbox2;
        MenuForm MenuForm;
        string abb;
        public Menu_Insert_modal()
        {
            this.ControlBox = false;
            InitializeComponent();
            Load += Menu_Insert_modal_Load;
        }

        private void Menu_Insert_modal_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(280, 50);
          

            pnSet pn = new pnSet(this, 280, 50, 0, 0);
            Panel panel = ct.panel(pn);
            Controls.Add(panel);

            tbSet tb = new tbSet(this, "tb1", 130, 25, 50, 0);
            textbox1 = ct.txtbox(tb);
            textbox1.Font = new Font("Tahoma", 10, FontStyle.Bold);
            panel.Controls.Add(textbox1);

            tbSet tb2 = new tbSet(this, "tb2", 130, 25, 50, 25);
            textbox2 = ct.txtbox(tb2);
            textbox2.Font = new Font("Tahoma", 10, FontStyle.Bold);
            panel.Controls.Add(textbox2);



            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "label1", "이름", 50, 25, 0, 0, 10));
            arr.Add(new lbSet(this, "label2", "가격", 50, 25, 0, 25, 10));
            arr.Add(new btnSet(this, "btn1", "추가", 50, 50, 180, 0, btn_click));
            arr.Add(new btnSet(this, "btn2", "취소", 50, 50, 230, 0, btn_click));

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
            Module api = new Module();
            MenuForm = new MenuForm();
            switch (btn.Name)
            {
                case "btn1":
                    Hashtable ht = new Hashtable();
                    api = new Module();
                    ht.Add("m_bNo", MenuForm.No);
                    ht.Add("m_Name", textbox1.Text);
                    ht.Add("m_Price",textbox2.Text);
                    api.insert_Category("http://192.168.3.28:5000/mn_insert", ht);
                    MessageBox.Show("추가 되었습니다.");
                    break;

                case "btn2":
                    this.Close();
                    break;
            }
        }
        public string value1
        {
            get;
            set;
        }
        public string value2
        {
            get;
            set;
        }

        public void sss()
        {

            abb = value1;
            MessageBox.Show(abb);
        }
    }
}
