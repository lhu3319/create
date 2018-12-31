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

/*===========================================================================================================================================

// 클릭시 버튼 색상 변경해줘야 함.
// 아래 클릭버튼 주석 관련된것 해줘야함.

 =============================================================================================================================================*/

namespace mojavePos
{
    public partial class FORM_01 : Form
    {
        _Create ct = new _Create();
        RichTextBox 텍스트박스1;
        TextBox 텍스트박스2;
        FORM_01 F1;
        FORM_03 F3;
        public FORM_01()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load += FORM_01_Load;
        }

        private void FORM_01_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(750, 430);  // 폼 사이즈 지정
            //this.ControlBox = false;
            BackColor = Color.Black;
            // 제목 패널
            pnSet pn1 = new pnSet(this, 750, 110, 0, 0);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(패널);   //패널 화면 출력

            ArrayList arr = new ArrayList();

            arr.Add(new lbSet(this, "lb1", "ELBON", 500, 35, 330, 10, 40));
            arr.Add(new lbSet(this, "lb2", "the table", 300, 70, 260, 30, 20));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    if (i == 1)
                    {
                        label.Font = new Font("Tahoma", 40, FontStyle.Bold); //글꼴설정
                        label.ForeColor = Color.White;
                    }
                    else
                    {
                        label.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        label.ForeColor = Color.White;
                    }
                    패널.Controls.Add(label);
                }
            }

            //로그인 패널
            Richtb tx1 = new Richtb(this, "tb1", 200, 35, 370, 45);
            텍스트박스1 = ct.richbox(tx1);
            텍스트박스1.SelectionFont = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(텍스트박스1);

            tbSet tx2 = new tbSet(this, "tb2", 200, 35, 370, 93);
            텍스트박스2 = ct.txtbox(tx2);
            텍스트박스2.Font = new Font("Tahoma", 15, FontStyle.Bold);
            텍스트박스2.PasswordChar = '*';
            Controls.Add(텍스트박스2);

            pnSet pn2 = new pnSet(this, 750, 169, 0, 110);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.White;
            Controls.Add(패널2);
            패널2.Controls.Add(텍스트박스1);
            패널2.Controls.Add(텍스트박스2);


            ArrayList arr1 = new ArrayList();
            arr1.Add(new lbSet(this, "lb3", "Name ", 150, 20, 190, 50, 15));
            arr1.Add(new lbSet(this, "lb4", "Password", 150, 20, 190, 100, 15));

            for (int i = 0; i < arr1.Count; i++)
            {
                if (typeof(lbSet) == arr1[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr1[i]);
                    label.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    패널2.Controls.Add(label);
                }
            }
            //끝 패널
            pnSet pn3 = new pnSet(this, 750, 130, 0, 280);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(패널3);   //패널 화면 출력

            ArrayList arr2 = new ArrayList();
            arr2.Add(new btnSet(this, "button", "로그인", 250, 40, 260, 25, btn_Click));
            arr2.Add(new btnSet(this, "button", "계정만들기", 130, 30, 320, 75, btn2_Click));
            for (int i = 0; i < arr2.Count; i++)
            {
                if (typeof(btnSet) == arr2[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr2[i]);
                    button.Font = new Font("Tahoma", 8, FontStyle.Regular);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    패널3.Controls.Add(button);
                }
            }

            pnSet pn4 = new pnSet(this, 750, 19, 0, 411);
            Panel 패널4 = ct.panel(pn4);
            패널4.BackColor = Color.White;
            Controls.Add(패널4);   //패널 화면 출력

            ArrayList arr3 = new ArrayList();
            arr3.Add(new lbSet(this, "lb3", "관리자 : (주)Mojave  연락처 : 1588-3000", 300, 20, 517, 3, 8));
            for (int i = 0; i < arr3.Count; i++)
            {
                if (typeof(lbSet) == arr3[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr3[i]);
                    label.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    패널4.Controls.Add(label);
                }
            }
        }
       
        private void btn_Click(object sender, EventArgs e)
        {
            Module api = new Module();
            api = new Module();

            F3 = new FORM_03();
            F1 = new FORM_01();

            string Correctid = api.getIdPass("http://192.168.3.28:5000/SI_select_Pos_Id");
            string Correctpw = api.getIdPass("http://192.168.3.28:5000/SI_select_Pos_Pass");

            if (텍스트박스1.Text == Correctid && 텍스트박스2.Text == Correctpw)
            {
                F3.Show();
                Dispose(false);
            }
            if (텍스트박스1.Text.Length == 0 || 텍스트박스2.Text.Length == 0)
            {
                MessageBox.Show("입력을 받지 않았습니다. 다시 입력해주시기 바랍니다.");
            }
            else if (텍스트박스1.Text != Correctid)
            {
                MessageBox.Show("아이디를 잘못 입력하셨습니다.");
            }
            else if (텍스트박스1.Text == Correctid && 텍스트박스2.Text != Correctpw)
            {
                MessageBox.Show("비밀번호를 잘못 입력하셨습니다.");
            }

        }


        private void btn2_Click(object sender, EventArgs e)
        {
            FORM_02 F2 = new FORM_02();
            F2.ShowDialog();
        }

    }
}
