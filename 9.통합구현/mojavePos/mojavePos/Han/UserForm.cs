
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
    public partial class UserForm : Form
    {
        Commons comm;
        _Create ct = new _Create();
        public UserForm()
        {
            InitializeComponent();
            Load += UserForm_Load;
        }
        
        private void UserForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Coral;

            UserView();
            get_Date();
            get_Combo();
            get_Textbox();
            get_Button();
        }

        private void UserView()
        {
            //uNo uName   uDate uNumber uRate uTotal  delYn regDate modDate
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "", 960, 700, 270, 60, list_Click));
            ListView lv = ct.listview((lvSet)list[0]);
            Controls.Add(lv);

            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 100, HorizontalAlignment.Center);
            lv.Columns.Add("생년월일", 150, HorizontalAlignment.Center);
            lv.Columns.Add("휴대폰번호", 160, HorizontalAlignment.Center);
            lv.Columns.Add("등급", 100, HorizontalAlignment.Center);
            lv.Columns.Add("누적금액", 100, HorizontalAlignment.Center);
            lv.Columns.Add("등록날짜", 150, HorizontalAlignment.Center);
            lv.Columns.Add("수정된 날짜", 150, HorizontalAlignment.Center);

        }
        private void get_Date()
        {
            ArrayList list = new ArrayList();
            list.Add(new DateSet(this, "first", 150, 50, 270, 40));
            list.Add(new DateSet(this, "second", 150, 50, 450, 40));
            for (int i = 0; i < list.Count; i++)
            {
                ct.datepic((DateSet)list[i]);
            }
            list.Add(new lbSet(this, "lb1", " ~ ", 30,15 , 420, 40, 13));
            Label label1 = ct.lable((lbSet)list[2]);
            label1.BackColor = Color.Coral;
            label1.Font = new Font(FontFamily.GenericSansSerif, 13.0F, FontStyle.Bold);
            Controls.Add(label1);

        }
        private void get_Combo()
        {
            comm = new Commons();
            ArrayList list = new ArrayList();
            
            list.Add(new comboboxSet(this, "combo", 60, 30, 640, 40));
            ComboBox combo = ct.combobox((comboboxSet)list[0]);
            combo.Items.Add("등급");
            combo.Items.Add("이름");
            combo.Items.Add("날짜");
            combo.Text = "이름";
            Controls.Add(combo);
        }

        private void get_Textbox()
        {
            TextBox textbox = new TextBox();

            tbSet tb1 = new tbSet(this, "tb1", 100, 20, 700, 40);
            textbox = ct.txtbox(tb1);
            Controls.Add(textbox);
        }
        private void get_Button()
        {
            ArrayList btn_list = new ArrayList();
            btn_list.Add(new btnSet(this, "search", "검색", 60, 22, 820, 40,search_Click));
            btn_list.Add(new btnSet(this, "insert", "추가", 60, 22, 890, 40, insert_Click));
            btn_list.Add(new btnSet(this, "update", "수정", 60, 22, 960, 40, update_Click));
            btn_list.Add(new btnSet(this, "delete", "삭제", 60, 22, 1030, 40, delete_Click));

            for (int i = 0; i < btn_list.Count; i++)
            {
                Button button = ct.btn((btnSet)btn_list[i]);
                Controls.Add(button);
            }
        }

        private void delete_Click(object sender, EventArgs e) //삭제버튼
        {
           
        }

        private void update_Click(object sender, EventArgs e) //변경버튼
        {
            //
        }

        private void insert_Click(object sender, EventArgs e) //추가버튼
        {
            InsertForm insert = new InsertForm();
            insert.ShowDialog();
        }

        private void search_Click(object sender, EventArgs e) //검색버튼
        {
            
        }


        private void list_Click(object sender, MouseEventArgs e) //안쓸것
        {
            
        }
    }
}
