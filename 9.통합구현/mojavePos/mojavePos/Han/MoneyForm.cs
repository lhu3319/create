using WindowsFormsApp;
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
    public partial class MoneyForm : Form
    {
        Panel ch1, ch2, ch3, ch4, ch5, ch6;
        Commons comm;
        _Create ct = new _Create();
        WebComm api;
        public MoneyForm()
        {
            InitializeComponent();
            Load += MoneyForm_Load;
            this.BackgroundImage = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("배경화면1");
        }

        private void MoneyForm_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(1200, 800);
           
           
            //get_Combo();
            get_Date();
            get_button();
            moneyView();
           get_total(lv);

        }
        private void moneyView()
        {
            //uNo uName   uDate uNumber uRate uTotal  delYn regDate modDate
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "view", 960, 700, 120, 60, list_Click));
            lv = ct.listview((lvSet)list[0]);
            Controls.Add(lv);

            lv.Columns.Add("번호", 65, HorizontalAlignment.Center);
            lv.Columns.Add("날짜", 215, HorizontalAlignment.Center);
            lv.Columns.Add("메뉴", 215, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 115, HorizontalAlignment.Center);
            lv.Columns.Add("금액", 175, HorizontalAlignment.Center);
            lv.Columns.Add("등록자", 175, HorizontalAlignment.Center);

           
            api = new WebComm();
            api.SelectListView("http://192.168.3.28:5000/cm_init", lv);

        }

        private void list_Click(object sender, MouseEventArgs e)
        {

        }

        //1500 800 6 1400 250

        public void get_Combo()
        {
            comm = new Commons();
            ComboBox combo = new ComboBox();
            comboboxSet cb1 = new comboboxSet(this, "period", 120, 35, 650, 35);
            combo = ct.combobox(cb1);
            combo.Font = new Font("Verdana", 10.5f, FontStyle.Italic);
            combo.Text = "분기선택";
            combo.Items.Add("1분기");
            combo.Items.Add("2분기");
            combo.Items.Add("3분기");
            combo.Items.Add("4분기");


            combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            Controls.Add(combo);
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e) // 콤보박스 이벤트 
        {
            ComboBox combo = (ComboBox)sender;

            string index = (string)combo.SelectedItem;

            if (index == "1분기")
            {
                MessageBox.Show("1분기");
            }
            else if (index == "2분기")
            {
                MessageBox.Show("2분기");
            }
            else if (index == "3분기")
            {
                MessageBox.Show("3분기");
            }
            else if (index == "4분기")
            {
                MessageBox.Show("4분기");
            }

        }
        DateTimePicker dt1;
        DateTimePicker dt2;
        private ListView lv;

        private void get_Date()
        {
            ArrayList list = new ArrayList();
            dt1 = new DateTimePicker();
            dt2 = new DateTimePicker();
            DateSet dts1 = new DateSet(this, "first", 150, 50, 120 , 40);
            DateSet dts2 = new DateSet(this, "second", 150, 50, 300, 40);
            dt1 = ct.datepic(dts1);
            dt2 = ct.datepic(dts2);


            lbSet ls = new lbSet(this, "lb1", " ~ ", 30, 15, 270, 43, 13);

            Label label1 = new Label();
            label1 = ct.lable(ls);
            label1.BackColor = Color.Transparent;
            label1.Parent = this;

            label1.Font = new Font(FontFamily.GenericSansSerif, 13.0F, FontStyle.Bold);

    
            Controls.Add(label1);
 
        }
        private void get_button()
        {
            comm = new Commons();
            Button btn = new Button();
            btnSet bs1 = new btnSet(this, "ok", "검색", 50, 22, 450, 39, ok_Click);
            btn = ct.btn(bs1);
            Controls.Add(btn);
        }
        Label label2;
        lbSet ls1;
        private void get_total(ListView lv)
        {
            long total=0;
            for(int i = 0; i < lv.Items.Count; i++)
            {
                ListViewItem item = lv.Items[i];
                total += Convert.ToInt64(item.SubItems[4].Text);
            }
            ls1 = new lbSet(this, "lb2", "총 금액: " + total.ToString()+"원", 600, 50, 530, 25, 30);

            label2 = new Label();
            label2 = ct.lable(ls1);
            label2.BackColor = Color.Transparent;
            label2.Parent = this;
            label2.Font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
            label2.ForeColor = Color.White;
            Controls.Add(label2);
        }
        private void ok_Click(object sender, EventArgs e)
        {
            int a = dt1.Text.Substring(0, 10).CompareTo(dt2.Text.Substring(0, 10)); // 시작날짜가 종료날짜보다 클때 에러처리

           if(a==1)
            {
                MessageBox.Show("정확한 날짜를 입력바랍니다.");
            }
           
            else{
                Hashtable ht = new Hashtable();
                api = new WebComm();
                ht.Add("spName", "select_date");
                ht.Add("start", dt1.Text.Substring(0, 10));
                ht.Add("end", dt2.Text.Substring(0, 10));
                ArrayList list = api.Select("http://192.168.3.28:5000/sel_date", ht);
                api.ListView(lv, list);

                Hashtable pro = new Hashtable();
                pro.Add("spName", "total_Money");
                pro.Add("start", dt1.Text.Substring(0, 10));
                pro.Add("end", dt2.Text.Substring(0, 10));
                ArrayList money = api.Select("http://192.168.3.28:5000/sel_date", pro);

                string[] arr2 = api.str(money); // 총가격
                if (arr2[0] == "") label2.Text = "총 금액: 0원";
                else
                {
                    ls1 = new lbSet(this, "lb2", arr2[0] + "원", 600, 50, 650,11, 30);

                    label2.Text = "총 금액: " + arr2[0] + "원";
                    
                    label2.Font = new Font(FontFamily.GenericSansSerif, 25.0F, FontStyle.Bold);
                }
                Controls.Add(label2);
            }
        }
    }
}
