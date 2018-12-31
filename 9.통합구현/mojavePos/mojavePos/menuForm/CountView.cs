
using mojavePos.Modal;
using mojavePos.Modules;
using Newtonsoft.Json.Linq;
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

namespace mojavePos
{

    public partial class CountView : Form
    {
        _Create ct = new _Create();
        Panel panel2;
        private Panel panel;
        private ListView lv;
        private WebAPI api;
        private Hashtable ht;
        private string _bNo;
        private string _tNo;
        private ArrayList list;
        private string _mNo;
        private string _mNm;
        private string _oCount;
        ArrayList Orderlist = new ArrayList();
        int Total;
        private TextBox textbox;
        private string Totalresult;


        public CountView()
        {
            InitializeComponent();

        }
        public CountView(string tNo,ArrayList list)
        {
            Load += CountView_Load;
            this._tNo = tNo;
            this.list = list;
        }
       
        private void CountView_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            listView();
            menu_view();
            beforeOrder();
            Orderlist = api.ListView(lv, list);
            ListCommon();
            
        }

        public void listView()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new pnSet(this, 580, 760, 10, 10));
            arr.Add(new lvSet(this, "", 570, 300, 5, 5, list_Click));
            arr.Add(new btnSet(this, "btn1", "+", 130, 70, 12, 310, btn_Click));
            arr.Add(new btnSet(this, "btn2", "현금결제", 230, 100, 320, 520, btn_Click));
            arr.Add(new btnSet(this, "btn3", "주문", 230, 100, 320, 400, btn_Click));
            arr.Add(new btnSet(this, "btn4", "카드결제", 230, 100, 320, 640, btn_Click));
            arr.Add(new btnSet(this, "btn5", "-", 130, 70, 152, 310, btn_Click));
            arr.Add(new btnSet(this, "btn6", "선택 취소", 130, 70, 292, 310, btn_Click));
            arr.Add(new btnSet(this, "btn7", "전체 취소", 130, 70, 432, 310, btn_Click));
            arr.Add(new btnSet(this, "btn8", "주문 수정", 230, 100, 30, 400, btn_Click));
            arr.Add(new lbSet(this, "label1", "Table No. :", 150, 40, 15, 580, 20));
            arr.Add(new lbSet(this, "label2", "총 금 액", 200, 40, 15, 640, 20));
            arr.Add(new tbSet(this, "총금액", 250, 40, 15, 680));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(pnSet) == arr[i].GetType())
                {
                    panel = ct.panel((pnSet)arr[i]);
                    panel.BackColor = Color.Gainsboro;
                    Controls.Add(panel);
                }
                else if (typeof(lvSet) == arr[i].GetType())
                {
                    lv = ct.listview((lvSet)arr[i]);
                    lv.BackColor = Color.WhiteSmoke;
                    panel.Controls.Add(lv);
                    lv.Columns.Add("", 0, HorizontalAlignment.Center);
                    lv.Columns.Add("메뉴명", 250, HorizontalAlignment.Center);
                    lv.Columns.Add("단가", 100, HorizontalAlignment.Center);
                    lv.Columns.Add("수량", 85, HorizontalAlignment.Center);
                    lv.Columns.Add("금액", 130, HorizontalAlignment.Center);
                    lv.Font = new Font("Tahoma", 15, FontStyle.Bold);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    panel.Controls.Add(label);
                }
                else if(typeof(tbSet) == arr[i].GetType())
                {
                    textbox = ct.txtbox((tbSet)arr[i]);
                    textbox.ReadOnly = true;
                    textbox.Font = new Font("Tahoma", 18, FontStyle.Bold);
                   
                    panel.Controls.Add(textbox);
                }
            }
            lbSet lb = new lbSet(this, "tNo", "", 100, 40, 170, 580, 20);
            Label label2 = ct.lable(lb);
            label2.Text = _tNo;
            label2.Font = new Font("Tahoma", 20, FontStyle.Bold);
            panel.Controls.Add(label2);
        }

        /// <summary>
        /// 리스트 클릭 이벤트
        /// </summary>
        private void list_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            
            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                _mNo = item.SubItems[0].Text;
                _mNm = item.SubItems[1].Text;
                _oCount = item.SubItems[3].Text;
            }
        }

        /// <summary>
        ///  예외처리 버튼
        /// </summary>
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            api = new WebAPI();
            ht = new Hashtable();
            switch (btn.Name)
            {
                case "btn1": // 수량 추가
                    for (int j = 0; j < Orderlist.Count; j++)
                    {
                        string[] row = (string[])Orderlist[j];
                        if (_mNo == row[0])
                        {
                            int cnt = Convert.ToInt32(row[3]);
                            //MessageBox.Show(cnt.ToString());
                            cnt++;
                            //MessageBox.Show(cnt.ToString());
                            row[3] = cnt.ToString();
                            row[4] = (Convert.ToInt64(row[2]) * Convert.ToInt64(row[3])).ToString();
                            Orderlist[j] = row;
                            ListCommon();
                            break;
                        }
                    }
                    break;
                case "btn2":
                    Cash cash = new Cash(_tNo, Totalresult);
                    cash.StartPosition = FormStartPosition.CenterParent;
                    cash.Show();
                    this.Visible = false;
                    break;

                case "btn3":
                    api = new WebAPI();
                    ht = new Hashtable();
                    
                    for(int i = 0; i<Orderlist.Count; i++)
                    {
                        ht = new Hashtable();
                        string[] arr = (string[])Orderlist[i];
                        ht.Add("spName", "sp_Order_Insert");
                        ht.Add("tNo", _tNo);
                        ht.Add("mNo", arr[0]);
                        ht.Add("oCount", arr[3]);
                        if (!api.Post("http://192.168.3.28:5000/sp_insert", ht))
                        {
                            MessageBox.Show("주문오류");
                            break;
                        }
                        //MessageBox.Show(arr[1]);
                    }
                    this.Visible = false;
                    break;

                case "btn4":
                    MessageBox.Show("서비스준비중입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "btn5": // 수량 감소
                    for (int j = 0; j < Orderlist.Count; j++)
                    {
                        string[] row = (string[])Orderlist[j];
                        if (_mNo == row[0])
                        {
                            int cnt = Convert.ToInt32(row[3]);
                            if (cnt > 1)
                            {
                                cnt--;
                            }
                            else if (cnt < 0)
                            {
                                cnt = 1;
                            }
                            row[3] = cnt.ToString();
                            row[4] = (Convert.ToInt64(row[2]) * Convert.ToInt64(row[3])).ToString();
                            Orderlist[j] = row;
                            ListCommon();
                            break;
                        }
                    }
                    break;
                case "btn6":
                    for (int i = 0; i < Orderlist.Count; i++)
                    {
                        string[] arr = (string[])Orderlist[i];

                        if (_mNm == arr[1])
                        {
                            Orderlist.RemoveAt(i);
                            ListCommon();
                            break;
                        }
                    }

                    for (int i = 0; i < Orderlist.Count; i++)
                    {
                        ht = new Hashtable();
                        string[] arr = (string[])Orderlist[i];
                        ht.Add("spName", "sp_Delete");
                        ht.Add("tNo", _tNo);
                        ht.Add("mNo", _mNo);
                        if (!api.Post("http://192.168.3.28:5000/sp_list_delete", ht))
                        {
                            MessageBox.Show("주문수정오류");
                            break;
                        }
                    }

                    break;
                case "btn7": //전체 취소
                    for (int i = 0; i < Orderlist.Count; i++)
                    {
                        ht = new Hashtable();
                        ht.Add("spName", "sp_Total_Delete");
                        ht.Add("tNo", _tNo);
                        if (!api.Post("http://192.168.3.28:5000/sp_delete", ht))
                        {
                            MessageBox.Show("전체 취소 오류");
                            break;
                        }
                    }

                    Orderlist = new ArrayList();
                    ListCommon();
                    break;

                case "btn8":
                    for (int i = 0; i < Orderlist.Count; i++)
                    {
                        ht = new Hashtable();
                        string[] arr = (string[])Orderlist[i];
                        ht.Add("spName", "sp_Order_Update");
                        ht.Add("tNo", _tNo);
                        ht.Add("mNo", _mNo);
                        ht.Add("oCount", arr[3]);
                        if (!api.Post("http://192.168.3.28:5000/sp_update", ht))
                        {
                            MessageBox.Show("주문수정오류");
                            break;
                        }
                    }
                    this.Visible = false;
                    break;
            }
        }

     
        /// <summary>
        /// 메뉴 카테고리 뷰 화면
        /// </summary>
        private void menu_view()
        {
            pnSet pn1 = new pnSet(this, 100, 760, 600, 10);
            Panel panel = ct.panel(pn1);
            panel.BackColor = Color.Gainsboro;
            Controls.Add(panel);
            pnSet pn2 = new pnSet(this, 570, 760, 700, 10);
            panel2 = ct.panel(pn2);
            panel2.BackColor = Color.Gainsboro;
            Controls.Add(panel2);

            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "sp_MenuCategory_Select");
            ht.Add("param", "");
            ArrayList list = api.Select("http://192.168.3.28:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button(this, list, Category_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);

                    panel.Controls.Add(button);
                }
            }
        }

        /// <summary>
        /// 카테고리 클릭 버튼 이벤트
        /// </summary>
        private void Category_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _bNo = btn.Name;
            //MessageBox.Show(_bNo);

            ht = new Hashtable();
            ht.Add("spName", "sp_Menu_Select");
            ht.Add("param", "_bNo:" + _bNo);
            panel2.Controls.Clear();
            list = api.Select("http://192.168.3.28:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button2(panel2, list, Menu_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);
                    panel2.Controls.Add(button);
                }
            }
        }

        
        /// <summary>
        ///  메뉴 클릭 버튼 이벤트
        /// </summary>
        private void Menu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string _mName = btn.Name;

            for (int i = 0; i < list.Count; i++)
            {
                JArray ja = (JArray)list[i];
                string[] arr = new string[5];
                //MessageBox.Show(ja.Count.ToString());
                for (int j = 0; j < ja.Count; j++)
                {
                    arr[j] = ja[j].ToString();
                    //MessageBox.Show(j+":"+arr[j].ToString());

                }
                if (_mName == arr[1]) //메뉴넘버와 배열 0번지가 같으면
                {
                    bool add = true;

                    for (int r = 0; r < Orderlist.Count; r++)
                    {
                        string[] d = (string[])Orderlist[r];
                        if (_mName == d[1])
                        {
                            add = false;
                            int 가격 = Convert.ToInt32(d[2]);
                            int 수량 = Convert.ToInt32(d[3]);
                            수량++;
                            d[3] = 수량.ToString();
                            d[4] = (가격 * 수량).ToString();
                            Orderlist[r] = d;
                            break;
                        }
                    }
                    if (add)
                    {
                        arr[4] = (Convert.ToInt32(arr[2]) * Convert.ToInt32(arr[3])).ToString();
                        Orderlist.Add(arr);     //추가
                    }
                    break;
                }
            }
            ListCommon();
        } 

        /// <summary>
        /// 리스트 공통 부분
        /// </summary>
        private void ListCommon()
        {
            lv.Items.Clear();
            for (int i = 0; i < Orderlist.Count; i++)
            {
                string[] row = (string[]) Orderlist[i];
                lv.Items.Add(new ListViewItem(row));
            }
        }

        private void beforeOrder()
        {
            for (int i = 0; i < list.Count; i++)
            {
                JArray ja = (JArray)list[i];
                string[] arr = new string[ja.Count];
                //MessageBox.Show(ja.Count.ToString());
                for (int j = 0; j < ja.Count; j++)
                {
                    arr[j] = ja[j].ToString();
                }
                Total += Convert.ToInt32(arr[4]);
            }
            Totalresult = Total.ToString();
            textbox.Text = Totalresult;
            }
        }
    }

