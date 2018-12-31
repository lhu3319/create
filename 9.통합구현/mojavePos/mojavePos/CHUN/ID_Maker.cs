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

/*-----------------------------------------------------------------
 // 클릭시 버튼 색상 변경해줘야 함.
 // 아이디는 하나만 만들어야 하니, DB에 No = 2 이상은 넣어지면 안된다. => 경고박스("이미 한개이상 가입 하였습니다 한 포스기당 하나의 아이디만 가입할수 있습니다.")가 뜨고 디비에 올라가지면 안된다.
 // 모듈화 시켜서 만들어 놓기.
------------------------------------------------------------------*/

namespace mojavePos
{
    public partial class FORM_02 : Form
    {



        //static ToolStripStatusLabel StripLb;
        //StatusStrip statusStrip;
        _Create ct;
        RichTextBox 네임택박, 포지션택박, 시리얼택박;
        TextBox 패스워드택박;
        FORM_01 F1;
        FORM_02 F2;
        Module api;
        private string PS_No;

        public FORM_02()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load += FORM_02_Load;
        }

        private void FORM_02_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(750, 430);  //폼 사이즈
            this.ControlBox = false;        //최소화 최대화 버튼 없애기

            ct = new _Create();

            //Name 텍스트박스 출력
            Richtb tx1 = new Richtb(this, "txt1", 170, 30, 30, 60);
            네임택박 = ct.richbox(tx1);
            네임택박.SelectionFont = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(네임택박);

            //Postion 텍스트박스 출력
            Richtb tx2 = new Richtb(this, "txt2", 170, 30, 30, 120);
            포지션택박 = ct.richbox(tx2);
            포지션택박.SelectionFont = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(포지션택박);

            //Password 텍스트박스 출력
            tbSet tx3 = new tbSet(this, "txt3", 170, 30, 30, 180);
            패스워드택박 = ct.txtbox(tx3);
            패스워드택박.PasswordChar = '*';
            패스워드택박.Font = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(패스워드택박);

            //Serial 텍스트박스 출력
            Richtb tx4 = new Richtb(this, "txt4", 170, 30, 30, 240);
            시리얼택박 = ct.richbox(tx4);
            시리얼택박.SelectionFont = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(시리얼택박);

            pnSet pn1 = new pnSet(this, 230, 370, 30, 30);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(패널);
            패널.Controls.Add(네임택박);
            패널.Controls.Add(포지션택박);
            패널.Controls.Add(패스워드택박);
            패널.Controls.Add(시리얼택박);

            ArrayList arr = new ArrayList();

            arr.Add(new lbSet(this, "label1", "Name", 50, 15, 90, 40, 10));
            arr.Add(new lbSet(this, "label2", "Postion", 100, 15, 83, 100, 10));
            arr.Add(new lbSet(this, "label3", "Password", 100, 15, 75, 160, 10));
            arr.Add(new lbSet(this, "label4", "Serial Number", 100, 15, 90, 220, 10));
            arr.Add(new btnSet(this, "Btn1_pn1", "가입", 80, 50, 30, 290, btn_Click));
            arr.Add(new btnSet(this, "Btn2_pn1", "취소", 80, 50, 120, 290, btn2_Click));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.ForeColor = Color.White;
                    label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    패널.Controls.Add(label);
                }
                else
                {
                    if (typeof(btnSet) == arr[i].GetType())
                    {
                        Button button = ct.btn((btnSet)arr[i]);
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        패널.Controls.Add(button);
                    }
                }
            }
          
            pnSet pn2 = new pnSet(this, 420, 370, 300, 30);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.FromArgb(232, 227, 227);
            Controls.Add(패널2);   //패널 화면 출력
           
            ArrayList arr2 = new ArrayList();
            arr2.Add(new lbSet(this, "label5", "ELBON the table     _", 140, 15, 35, 40, 10));
            arr2.Add(new lbSet(this, "label6", "Mojave of Pos", 200, 27, 180, 29, 30));
            arr2.Add(new lbSet(this, "label7", "1. Mojave of Pos 는 'Mojave/모하비'에서 제작하였습니다.", 350, 15, 35, 70, 8));
            arr2.Add(new lbSet(this, "label8", "2. Mojave of Pos는 ELBON the table의 효율적인 재정관리를 할 수                있도록 돕기 위해 제작 되었습니다.", 380, 30, 35, 100, 8));
            arr2.Add(new lbSet(this, "label9", "3. Mojave of Pos는 자체 제공한 시리얼넘버로 하나의 아이디만 회원               가입할수 있습니다.", 380, 30, 35, 145, 8));
            arr2.Add(new lbSet(this, "label10", "4. Mojave of Pos는 비밀번호찾기 기능을 따로 제공하지 않습니다.", 380, 15, 35, 190, 8));
            arr2.Add(new lbSet(this, "label6", "5. Mojave of Pos안의 ELBON the table 정보는 절대 외부에 공개를                하지 않습니다.", 380, 30, 35, 220, 8));
            arr2.Add(new lbSet(this, "label12", "6. Mojave of Pos는 포스기에 최적화 되어 있습니다.", 380, 15, 35, 265, 8));
            arr2.Add(new lbSet(this, "label13", "문의사항 : question@MojaveKorea.co.kr", 380, 15, 35, 310, 8));
            for (int i = 0; i < arr2.Count; i++)
            {
                if (typeof(lbSet) == arr2[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr2[i]);
                    if (i == 0) label.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    else if (i == 1) label.Font = new Font("Tahoma", 19, FontStyle.Bold);
                    else label.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    패널2.Controls.Add(label);
                }
            }
        }

        //DB의 No = 1이 없으면 가입하고 가입되었습니다. 넣고 DB의 NO = 2 이상은 MessageBox로 이미 회원가입을 하셨습니다. 라는 메세지박스 출력할것.
        private void btn_Click(object sender, EventArgs e)
        {   
            F1 = new FORM_01();
            api = new Module();
            string Correctid = api.getIdPass("http://192.168.3.28:5000/sp_Pos_Count");

            if (Correctid !=  "[[\"0\"]]")
            {
                MessageBox.Show("아이디가 존재 합니다.");
            }
            else
            {

                if (네임택박.Text.Length == 0 || 포지션택박.Text.Length == 0 || 패스워드택박.Text.Length == 0 || 시리얼택박.Text.Length == 0)
                {

                    MessageBox.Show("값을 입력 받지 않았습니다.\n 확인 후 입력해주세요.");
                }
                else
                {
                    if (시리얼택박.Text != "GUDI")

                    {
                        MessageBox.Show("시리얼 번호가 맞지 않습니다. 다시 입력해주시기 바랍니다.");
                    }
                    else
                    {
                        Hashtable ht = new Hashtable();

                        ht.Add("ps_Id", 네임택박.Text);
                        ht.Add("ps_Rank", 포지션택박.Text);
                        ht.Add("ps_passwd", 패스워드택박.Text);
                        ht.Add("ps_code", 시리얼택박.Text);
                        api.insert_Category("http://192.168.3.28:5000/SI_insert_Pos", ht);
                        Close();
                    }
                }
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


