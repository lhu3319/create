using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using mojavePos.Han;
using WindowsFormsApp;

namespace mojavePos
{
    public partial class FORM_03 : Form
    {
       
        lbSet pn4_lb;
        string lbText1 = "영업중이 아닙니다. 판매를 하시려면 영업시작을 눌러주십시오.";
        string lbText2 = "영업중 입니다. 판매를 종료하시려면 영업종료를 눌러주십시오.";
        
        string lbText3 = "영업시작";
        string lbText4 = "영업종료";
        //TextBox 준비금텍스트박스;
        Label 시간, 날짜, 경고문 , 영업시작;
        Timer timer;
        _Create ct;
        Module api;
        bool value = true;
        object a;
        public FORM_03()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load += FORM_03_Load;
          
        }

        public void FORM_03_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(750, 430);
            ct = new _Create();
            BackColor = Color.FromArgb(191, 191, 191);
            this.StartPosition = FormStartPosition.Manual;
            
            //날짜라벨
            lbSet pn1_lb5 = new lbSet(this, "pn1_lb5", "//날짜", 250, 30, 5, 240, 15);
            날짜 = ct.lable(pn1_lb5);
            날짜.TextAlign = ContentAlignment.MiddleCenter;
            날짜.Font = new Font("Tahoma", 15, FontStyle.Bold);
            날짜.ForeColor = Color.White;
            Controls.Add(날짜);
            
            //시간라벨
            lbSet pn1_lb6 = new lbSet(this, "pn1_lb6", "//시간", 170, 30, 45, 270, 15);
            시간 = ct.lable(pn1_lb6);
            시간.TextAlign = ContentAlignment.MiddleCenter;
            시간.Font = new Font("Tahoma", 15, FontStyle.Bold);
            시간.ForeColor = Color.White;
            Controls.Add(시간);

            PictureBox mojave = new PictureBox();
            mojave.Image = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("모자브포스3");
            mojave.SizeMode = PictureBoxSizeMode.StretchImage;
            mojave.Size = new Size(250, 110);
            mojave.BackColor = Color.FromArgb(19, 38, 78);
            mojave.Location = new Point(0, 0);
            Controls.Add(mojave);

            //패널
            pnSet pn1 = new pnSet(this, 250, 350, 0, 0);
            Panel 패널1 = ct.panel(pn1);
            패널1.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(패널1);   //패널 화면 출력
            패널1.Controls.Add(날짜);
            패널1.Controls.Add(시간);
            패널1.Controls.Add(mojave);
            //그림넣기
            //분기매출액 표현하기

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "label1", "오늘매출액", 100, 25, 70, 140, 10));
            arr.Add(new lbSet(this, "label1_1", " ", 100, 25, 60, 170, 10));
            arr.Add(new lbSet(this, "label1_2", "원", 20, 25, 160, 170, 10));
           // arr.Add(new lbSet(this, "pn1_lb2", "분기 매출액", 110, 25, 70, 140, 10));
           // arr.Add(new lbSet(this, "pn1_lb2_0", "2", 20, 25, 58, 140, 10));
           // arr.Add(new lbSet(this, "pn1_lb2_1", "10,000,000", 100, 25, 60, 170, 10));
           // arr.Add(new lbSet(this, "pn1_lb2_2", "원", 20, 25, 160, 170, 10));
            
            for(int i = 0; i< arr.Count; i++)
            {
                if(typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);

                    if(i==1)
                    {
                        api = new Module();
                        string total_money = api.getIdPass("http://192.168.3.28:5000/F3_total_day");
                     
                        if (total_money == null)
                        {
                            label.Text = "0";
                        }
                        else label.Text = total_money;
                    }
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    패널1.Controls.Add(label);
                }
            }
            //영업시작 파트
            //영업시작 버튼
            btnSet pn2_btn_1 = new btnSet(this, "pn2_btn_1", " ", 80, 80, 50, 30, btn_Click);
            Button 영업시작버튼 = ct.btn(pn2_btn_1);
            영업시작버튼.Font = new Font("Tahoma", 10, FontStyle.Bold);
            영업시작버튼.BackgroundImage = mojavePos.Properties.Resources.자물쇠잠김;
            영업시작버튼.BackColor = Color.FromArgb(232, 227, 227);
            영업시작버튼.FlatStyle = FlatStyle.Flat;
            영업시작버튼.FlatAppearance.BorderSize = 0;
            Controls.Add(영업시작버튼);

            //영업시작 라벨
            lbSet pn2_lb1 = new lbSet(this, "pn2_lb1", lbText3,  130, 30, 30, 120, 20);
           영업시작 = ct.lable(pn2_lb1);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
             영업시작.Font = new Font("Tahoma", 20, FontStyle.Bold);

            Controls.Add(영업시작);

           
            //영업시작 패널
            pnSet pn2 = new pnSet(this, 180, 220, 300, 70);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.FromArgb(232, 227, 227);
            Controls.Add(패널2);   //패널 화면 출력
            패널2.Controls.Add(영업시작버튼);
            패널2.Controls.Add(영업시작);
            
            //관리자 시작 파트
            //관리자 버튼
            btnSet pn3_btn_1 = new btnSet(this, "pn3_btn_1", " ", 80, 80, 50, 30, btn1_Click);
            Button 관리자버튼 = ct.btn(pn3_btn_1);
            관리자버튼.Font = new Font("Tahoma", 10, FontStyle.Bold);
            관리자버튼.BackColor = Color.FromArgb(232, 227, 227);
            관리자버튼.FlatStyle = FlatStyle.Flat;
            관리자버튼.FlatAppearance.BorderSize = 0;
            관리자버튼.BackgroundImage = mojavePos.Properties.Resources.가방수정;
          

            Controls.Add(관리자버튼);

            //관리자 라벨
            lbSet pn3_lb1 = new lbSet(this, "pn3_lb1", "관리자", 100, 35, 45, 120, 20);
            Label 관리자 = ct.lable(pn3_lb1);
             관리자.Font = new Font("Tahoma", 20, FontStyle.Bold);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(관리자);

            //관리자 패널
            pnSet pn3 = new pnSet(this, 180, 220, 520, 70);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.FromArgb(232, 227, 227);
            Controls.Add(패널3);   //패널 화면 출력
            패널3.Controls.Add(관리자버튼);
            패널3.Controls.Add(관리자);

             a = pn4_lb;
            //경고문 라벨
            pn4_lb = new lbSet(this, "label2", lbText1, 750, 30, 0, 12, 15);
            경고문 = ct.lable(pn4_lb);
            경고문.Font = new Font("Tahoma", 15, FontStyle.Bold);
            경고문.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(경고문);

            //하단부 패널
            pnSet pn4 = new pnSet(this, 750, 50, 0,380);
            Panel 패널4 = ct.panel(pn4);
            패널4.BackColor = Color.FromArgb(232, 227, 227);
            패널4.Font = new Font("Tahoma", 20, FontStyle.Bold);
            Controls.Add(패널4);
            패널4.Controls.Add(경고문);
            
            Control_Init();
        }
        private void Control_Init()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick1;
            timer.Start();
        }
        private void Timer_Tick1(object sender, EventArgs e)
        {
            시간.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
            날짜.Text = string.Format("{0:yyyy.MM.dd (dddd)}", DateTime.Now);
        }
        //시작버튼 효과
        private void btn_Click(object sender, EventArgs e)
        {
            MainPos MP = new MainPos();
            if (value == true)
            {
                if (MessageBox.Show("영업을 시작 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    경고문.Text = lbText2;
                    영업시작.Text = lbText4;
                   
                    MP.Show();

                    value = false;
                  
                }
            }
            else
            {
                if (MessageBox.Show("영업을 종료 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    경고문.Text = lbText1;
                    영업시작.Text = lbText3;
                 
                    MessageBox.Show("영업을 종료 하였습니다.");

                    value = true;
                }
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            MainPos MP = new MainPos();
            if (MessageBox.Show("영업을 시작 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                MP.Show();
             
            }
            else if (MessageBox.Show("영업을 종료 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
             
            }
        }
        //관리자버튼 효과
        private void btn1_Click(object sender, EventArgs e)
        {
            ManagerForm MF = new ManagerForm();
            MF.StartPosition = FormStartPosition.Manual;
            MF.Location = new Point(350, 80);
            MF.Show();
        }
    }
}
