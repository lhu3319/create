
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
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace mojavePos.Han
{
    public partial class RankForm : Form
    {
        Commons comm;
        _Create ct = new _Create();
        Chart chart1, chart2, chart3, chart4, chart5, chart6;
        ChartArea chartArea1;
        Legend legend1;
        Series series1;
        Hashtable chat;
        TextBox tb;
        string start = "";
        string end = "";
        string[] arr = null;
        Panel pasta, steake, salad, dessert, beverage, side;
        ArrayList list, array, panel;

        public RankForm()
        {
            InitializeComponent();
            Load += RankForm_Load;
        }


        private void RankForm_Load(object sender, EventArgs e)
        {
            get_Combo();
            get_panel();
            get_text();
            // get_panel();
            BackgroundImage = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("배경화면1");
        }
        public void get_panel()
        {

            panel = new ArrayList();
            comm = new Commons();

            pnSet pn1 = new pnSet(this, 393, 350, 10, 80);
            pasta = ct.panel(pn1);
            pasta.BackColor = Color.White;
            pasta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(pasta);
            panel.Add(pasta);

            pnSet pn2 = new pnSet(this, 393, 350, 403, 80);
            steake = ct.panel(pn2);
            steake.BackColor = Color.White;
            steake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(steake);
            panel.Add(steake);

            pnSet pn3 = new pnSet(this, 393, 350, 796, 80);
            salad = ct.panel(pn3);
            salad.BackColor = Color.White;
            salad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(salad);
            panel.Add(salad);

            pnSet pn4 = new pnSet(this, 393, 350, 10, 430);
            beverage = ct.panel(pn4);
            beverage.BackColor = Color.White;
            beverage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(beverage);
            panel.Add(beverage);

            pnSet pn5 = new pnSet(this, 393, 350, 403, 430);
            side = ct.panel(pn5);
            side.BackColor = Color.White;
            side.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(side);
            panel.Add(side);

            pnSet pn6 = new pnSet(this, 393, 350, 796, 430);
            dessert = ct.panel(pn6);
            dessert.BackColor = Color.White;
            dessert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(dessert);
            panel.Add(dessert);
        }

        public void get_Combo()
        {
            comm = new Commons();
            ComboBox combo = new ComboBox();
            comboboxSet cb1 = new comboboxSet(this, "month", 120, 35, 600, 45);
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
        public void get_chart()
        {
            chat = new Hashtable();
            chat.Add("areaname", "ChartArea1");
            chat.Add("legname", "Legend1");
            chat.Add("seriname", "Series1");
            chat.Add("chartname", "chartname");
            chat.Add("text", "pasta");
            chart1 = comm.getChart(chat, pasta);

            chat = new Hashtable();
            chat.Add("areaname", "ChartArea1");
            chat.Add("legname", "Legend1");
            chat.Add("seriname", "Series1");
            chat.Add("chartname", "chartname");
            chat.Add("text", "steake");
            chart2 = comm.getChart(chat, steake);

            chat = new Hashtable();
            chat.Add("areaname", "ChartArea1");
            chat.Add("legname", "Legend1");
            chat.Add("seriname", "Series1");
            chat.Add("chartname", "chartname");
            chat.Add("text", "salad");
            chart3 = comm.getChart(chat, salad);

            chat = new Hashtable();
            chat.Add("areaname", "ChartArea1");
            chat.Add("legname", "Legend1");
            chat.Add("seriname", "Series1");
            chat.Add("chartname", "chartname");
            chat.Add("text", "dessert");
            chart4 = comm.getChart(chat, dessert);

            chat = new Hashtable();
            chat.Add("areaname", "ChartArea1");
            chat.Add("legname", "Legend1");
            chat.Add("seriname", "Series1");
            chat.Add("chartname", "chartname");
            chat.Add("text", "beverage");
            chart5 = comm.getChart(chat, beverage);

            chat = new Hashtable();
            chat.Add("areaname", "ChartArea1");
            chat.Add("legname", "Legend1");
            chat.Add("seriname", "Series1");
            chat.Add("chartname", "chartname");
            chat.Add("text", "side");
            chart6 = comm.getChart(chat, side);
        }
        public void panel_clear()
        {
            pasta.Controls.Clear();
            steake.Controls.Clear();
            salad.Controls.Clear();
            side.Controls.Clear();
            dessert.Controls.Clear();
            beverage.Controls.Clear();
        }
        private void Combo_SelectedIndexChanged(object sender, EventArgs e) // 콤보박스 이벤트 
        {
            ComboBox combo = (ComboBox)sender;

            WebComm api = new WebComm();
            string index = (string)combo.SelectedItem;

            if (index == "1분기")
            {
                if (tb.Text != "")
                {
                    //api.Post2("http://192.168.3.28:5000/insert_CM"); // 결제버튼 클릭 시 매출관리 테이블에 추가
                    start = tb.Text + "-1-1";
                    end = tb.Text + "-3-31";
                }
            }
            else if (index == "2분기")
            {
                if (tb.Text != "")
                {
                    start = tb.Text + "-4-1";
                    end = tb.Text + "-6-30";
                }
            }
            else if (index == "3분기")
            {
                if (tb.Text != "")
                {
                    start = tb.Text + "-7-1";
                    end = tb.Text + "-9-30";
                }

            }
            else if (index == "4분기")
            {
                if (tb.Text != "")
                {
                    start = tb.Text + "-10-1";
                    end = tb.Text + "-12-31";
                }
            }


            Hashtable pcd = new Hashtable();
            pcd.Add("spName", "sel_Rank");
            pcd.Add("start", start);
            pcd.Add("end", end);
            list = api.Select("http://192.168.3.28:5000/sel_date", pcd);

            if (list.Count == 0)
            {
                MessageBox.Show("데이터값이 없습니다.");
            }


            else
            {
                panel_clear();
                get_chart();
                array = api.Cut(list);
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {

                        case 0:
                            chart1.Series["Series1"].Points.Clear();
                            chart1.Titles.Add("파스타");

                            for (int j = 0; j < list.Count; j++)
                            {
                                if (array[j * 3].ToString() == "1")

                                    chart1.Series["Series1"].Points.AddXY(array[(j * 3) + 1].ToString(), array[(j * 3) + 2].ToString());
                            }
                            break;
                        case 1:
                            chart2.Series["Series1"].Points.Clear();
                            chart2.Titles.Add("스테이크");
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (array[j * 3].ToString() == "2")
                                    chart2.Series["Series1"].Points.AddXY(array[(j * 3) + 1].ToString(), array[(j * 3) + 2].ToString());
                            }
                            break;
                        case 2:
                            chart3.Series["Series1"].Points.Clear();
                            chart3.Titles.Add("샐러드");
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (array[j * 3].ToString() == "3")
                                    chart3.Series["Series1"].Points.AddXY(array[(j * 3) + 1].ToString(), array[(j * 3) + 2].ToString());
                            }
                            break;
                        case 3:
                            chart4.Series["Series1"].Points.Clear();
                            chart4.Titles.Add("디저트");
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (array[j * 3].ToString() == "4")
                                    chart4.Series["Series1"].Points.AddXY(array[(j * 3) + 1].ToString(), array[(j * 3) + 2].ToString());
                            }
                            break;
                        case 4:
                            chart5.Series["Series1"].Points.Clear();
                            chart5.Titles.Add("음료");
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (array[j * 3].ToString() == "5")
                                    chart5.Series["Series1"].Points.AddXY(array[(j * 3) + 1].ToString(), array[(j * 3) + 2].ToString());
                            }
                            break;
                        case 5:
                            chart6.Series["Series1"].Points.Clear();
                            chart6.Titles.Add("사이드");
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (array[j * 3].ToString() == "6")
                                    chart6.Series["Series1"].Points.AddXY(array[(j * 3) + 1].ToString(), array[(j * 3) + 2].ToString());
                            }
                            break;
                    }
                }
            }
        }


        private void get_text()
        {
            comm = new Commons();
            tb = new TextBox();
            tbSet tbs = new tbSet(this, "year", 120, 24, 470, 45);
            tb = ct.txtbox(tbs);
            tb.KeyPress += Tb_KeyPress;
            tb.MaxLength = 4;
            tb.TextAlign = HorizontalAlignment.Center;
            tb.MouseClick += Tb_MouseClick;
            tb.Text = "연도";
            tb.ForeColor = Color.Gray;
        }


        private void Tb_MouseClick(object sender, MouseEventArgs e)
        {
            bool init = true;
            TextBox tb = (TextBox)sender;

            if (init)
            {
                tb.Text = "";
                init = false;
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.Black;
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
    }
}
