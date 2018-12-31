using mojavePos.Han;
using mojavePos.Modules;
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
    public partial class Cash : Form
    {
        _Create ct = new _Create();
        TextBox textbox1,textbox2,textbox3, textbox4;
        Button btn;
        private Hashtable ht;
        private WebAPI api;
        private string tNo,Totalresult;
        public Cash(string tNo,string Totalresult)
        {
            InitializeComponent();
            Load += Cash_Load;
            this.tNo = tNo;
            this.Totalresult = Totalresult;
        }

        /// <summary>
        ///  화면 디자인
        /// </summary>
        private void Cash_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
            ClientSize = new Size(900,500);
            pnSet pn = new pnSet(this, 800, 400, 50, 50);
            Panel panel = ct.panel(pn);
            panel.BackColor = Color.Gainsboro;
            Controls.Add(panel);

            //계산내용
            tbSet tb = new tbSet(this, "tb4", 310, 30, 450, 100);
            textbox1 = ct.txtbox(tb);
            textbox1.ReadOnly = true;
            textbox1.Font = new Font("굴림", 18, FontStyle.Bold);
            panel.Controls.Add(textbox1);

            //받은금액
            tbSet tb1 = new tbSet(this, "받은금액", 200, 30, 150, 180);
            textbox2 = ct.txtbox(tb1);
            textbox2.ReadOnly = true;
            textbox2.Font = new Font("굴림", 18, FontStyle.Bold);
            panel.Controls.Add(textbox2);

            //거스름돈
            tbSet tb2 = new tbSet(this, "거스름돈", 200, 30, 150, 260);
            textbox3 = ct.txtbox(tb2);
            textbox3.ReadOnly = true;
            textbox3.Font = new Font("굴림", 18, FontStyle.Bold);
            
            panel.Controls.Add(textbox3);

            //총금액
            tbSet tb3 = new tbSet(this, "받을금액", 200, 30, 150, 100);
            textbox4 = ct.txtbox(tb3);
            textbox4.Text = Totalresult;
            textbox4.ReadOnly = true;
            textbox4.Font = new Font("굴림", 18, FontStyle.Bold);
            panel.Controls.Add(textbox4);

            ArrayList arr = new ArrayList();
            
            arr.Add(new lbSet(this, "lb1", "현금결제", 500, 30, 350, 20, 20));
            arr.Add(new lbSet(this, "lb2", "결제 금액", 100, 30, 30, 100, 15));
            arr.Add(new lbSet(this, "lb3", "받은 금액", 100, 30, 30, 180, 15));
            arr.Add(new lbSet(this, "lb4", "거스름돈", 100, 30, 30, 260, 15));
            //arr.Add(new tbSet(this, "tb1", 200, 30, 150, 100));
            //arr.Add(new tbSet(this, "tb2", 200, 30, 150, 180));
            //arr.Add(new tbSet(this, "tb3", 200, 30, 150, 260));
            arr.Add(new btnSet(this, "결제완료", "결제완료", 315, 40, 35, 330, btn1_Click));

            //계산기
            //arr.Add(new tbSet(this, "tb4", 300, 30, 460, 100));
            arr.Add(new btnSet(this, "1", "1", 70, 50, 450, 260, btn_Click));
            arr.Add(new btnSet(this, "2", "2", 70, 50, 530, 260, btn_Click));
            arr.Add(new btnSet(this, "3", "3", 70, 50, 610, 260, btn_Click));

            arr.Add(new btnSet(this, "4", "4", 70, 50, 450, 200, btn_Click));
            arr.Add(new btnSet(this, "5", "5", 70, 50, 530, 200, btn_Click));
            arr.Add(new btnSet(this, "6", "6", 70, 50, 610, 200, btn_Click));
            arr.Add(new btnSet(this, "DEL", "DEL", 70, 50, 690, 200, btn1_Click));

            arr.Add(new btnSet(this, "7", "7", 70, 50, 450, 140, btn_Click));
            arr.Add(new btnSet(this, "8", "8", 70, 50, 530, 140, btn_Click));
            arr.Add(new btnSet(this, "9", "9", 70, 50, 610, 140, btn_Click));
            arr.Add(new btnSet(this, "CA", "CA", 70, 50, 690, 140, btn1_Click));

            arr.Add(new btnSet(this, "0", "0", 70, 50, 450, 320, btn_Click));
            arr.Add(new btnSet(this, "00", "00", 70, 50, 530, 320, btn_Click));
            arr.Add(new btnSet(this, "000", "000", 70, 50, 610, 320, btn_Click));

            arr.Add(new btnSet(this, "ENTER", "ENTER", 70, 110, 690, 260, btn1_Click));

            for (int i = 0; i < arr.Count; i++)
            {
                if(typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    panel.Controls.Add(label);
                }
                else if(typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if (typeof(tbSet) == arr[i].GetType())
                {
                    TextBox textbox = ct.txtbox((tbSet)arr[i]);
                    textbox.ReadOnly = true;
                    panel.Controls.Add(textbox);
                }
            }
           
        }

        CountView cv = new CountView();
        private void btn1_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            switch (btn.Name)
            {
                case "CA":
                    textbox1.Clear();
                    break;
                case "DEL":
                    if(textbox1.Text.Length < 0)
                    {
                        textbox1.Text.Substring(textbox1.Text.Length + 1);
                    }
                    else if(textbox1.Text.Length > 0)
                    {
                        textbox1.Text = textbox1.Text.Substring(0,textbox1.Text.Length - 1);
                    }
                    break;
                case "ENTER":
                        textbox2.Text = textbox1.Text;
                        textbox3.Text = (Convert.ToInt32(textbox2.Text) - Convert.ToInt32(textbox4.Text)).ToString();

                    //if (Convert.ToInt32(textbox4.Text) > Convert.ToInt32(textbox2.Text))
                    //{
                    //}
                    //textbox3.Text = (Convert.ToInt32(textbox1.Text) - Convert.ToInt32(textbox2.Text)).ToString();
                    break;
                case "결제완료":
                    if (textbox2.Text == "") MessageBox.Show("받은금액을 입력바랍니다.");
                    if (textbox2.Text != "")
                    {
                        api = new WebAPI();
                        ht = new Hashtable();
                        WebComm wc = new WebComm();
                        ht.Add("spName", "sp_Order_Delete");
                        ht.Add("tNo", tNo);
                        api.Post("http://192.168.3.28:5000/sp_delete", ht);
                        wc.Post2("http://192.168.3.28:5000/insert_CM");
                        MessageBox.Show("거스름돈은 " + textbox3.Text + " 원입니다.");

                        this.Dispose();
                    }
                   
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            textbox1.Text = textbox1.Text + btn.Text;
        }
    }
}
