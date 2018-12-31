
using mojavePos.Modal;
using mojavePos;
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
    public partial class InsertForm : Form
    {
        Commons comm;
        _Create ct = new _Create();


        public InsertForm()
        {
            InitializeComponent();
            Load += InsertForm_Load;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //이름(텍스트) 생년월일(date) 전화번호(텍스트박스) 등급(콤보박스) 주문금액(텍스틉ㄱ스)
        private void InsertForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(400, 650);
            get_label();
            get_text();
            get_Combo();
            get_Button();
        }
        public void get_label()
        {
            ArrayList lb_list = new ArrayList();
            lb_list.Add(new lbSet(this, "lbname", "이름", 100, 30, 50, 40, 14));
            lb_list.Add(new lbSet(this, "lbdate", "생년월일", 100, 30, 50, 150, 14));
            lb_list.Add(new lbSet(this, "lbhone", "전화번호", 100, 30, 50, 270, 14));
            lb_list.Add(new lbSet(this, "lbrate", "등급", 100, 30, 50, 390, 14));
            lb_list.Add(new lbSet(this, "lbtotal", "주문금액", 100, 30, 50, 510, 14));

            for (int i = 0; i < lb_list.Count; i++)
            {
                Label lb = ct.lable((lbSet)lb_list[i]);
                lb.Font = new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold);
                Controls.Add(lb);
            }
        }
        public void get_text()
        {
            ArrayList rtb_list = new ArrayList();
            rtb_list.Add(new Richtb(this, "tbname", 300, 35, 50, 70));
            rtb_list.Add(new Richtb(this, "tbyear", 100, 35, 50, 180));
            rtb_list.Add(new Richtb(this, "tbday", 100, 35,250, 180));
            rtb_list.Add(new Richtb(this, "tbphone", 200, 35, 150, 300));
            rtb_list.Add(new Richtb(this, "tbtotal", 300, 35, 50, 540));

            for (int i = 0; i < rtb_list.Count; i++)
            {
                RichTextBox rtb = ct.richbox((Richtb)rtb_list[i]);
                rtb.SelectionFont = new Font("Verdana", 13, FontStyle.Bold);
                Controls.Add(rtb);
            }
        }
        public void get_Combo()
        {
            comm = new Commons();
            ArrayList list = new ArrayList();

            list.Add(new comboboxSet(this, "cmonth", 60, 35, 170, 180));
            list.Add(new comboboxSet(this, "cnum", 100, 35, 50, 300));
            list.Add(new comboboxSet(this, "crate", 300, 35, 50, 420));
            for(int i =0; i < list.Count; i++)
            {
                ComboBox combo =  ct.combobox((comboboxSet)list[i]);
                combo.Font = new Font("Verdana", 14.5f, FontStyle.Bold);
                if (i == 0)
                {
                    combo.Text = "월";
                    for(int j=1; j < 13; j++)
                    {
                    combo.Items.Add(j+"월");
                    }
                }
                else if(i == 1)
                {
                    combo.Text = "010";
                    combo.Items.Add("010");
                    combo.Items.Add("017");
                    combo.Items.Add("018");
                    combo.Items.Add("016");
                }
                else if(i == 2)
                {
                    combo.Text = "브론즈";
                    combo.Items.Add("브론즈");
                    combo.Items.Add("실버");
                    combo.Items.Add("골드");
                    combo.Items.Add("플래티넘");
                    combo.Items.Add("다이아몬드");
                }
                Controls.Add(combo);
            }
        }
        public void get_Button()
        {
            ArrayList list = new ArrayList();
                list.Add(new btnSet(this, "ok", "확인", 70, 40,250,600, ok_Click));
            list.Add(new btnSet(this, "cancel", "취소", 70, 40, 320, 600, cancel_Click));
        for(int i = 0; i < list.Count; i++)
            {
                Button button = ct.btn((btnSet)list[i]);
                Controls.Add(button);
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {

        }
    }
}
