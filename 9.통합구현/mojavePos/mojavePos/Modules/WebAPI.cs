using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos.Modules
{
    class WebAPI
    {
        /// <summary>
        /// Select API 작성
        /// </summary>
        public ArrayList Select(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] results = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(results);
               
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(resultStr);
                                
                return list;
            }
            catch
            {
                
                return null;
            }
        }

        /// <summary>
        ///  공통 WebAPI 리스트뷰 
        /// </summary>
        public ArrayList ListView(ListView listView, ArrayList list)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                listView.Items.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(arr);
                }
                return arrayList;
            }
            catch
            {
                //MessageBox.Show("실패");
                return null;
            }
        }

        /// <summary>
        /// 카테고리 버튼 생성 api
        /// </summary>
        public ArrayList Button(Form form, ArrayList list, EventHandler eh_btn)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(new btnSet(form, arr[0], arr[1], 100, 100, 0, (100 * i), eh_btn));
                }
                return arrayList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 메뉴 버튼 생성 api
        /// </summary>
        public ArrayList Button2(Control control, ArrayList list, EventHandler eh_btn)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];

                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(new btnSet(control, arr[1], arr[1], 190, 100, 190 * (i % 3), 100 * (i / 3), eh_btn));
                    string Price = arr[2];
                    string Count = arr[3];
                    // MessageBox.Show(Price);
                    //MessageBox.Show(Count);
                }
                return arrayList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///  식당 테이블 생성 api
        /// </summary>
        public ArrayList Button3(Control control, ArrayList list, EventHandler eh_btn)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(new btnSet(control, arr[1], arr[2], Convert.ToInt32(arr[3]), Convert.ToInt32(arr[4]), Convert.ToInt32(arr[5]), Convert.ToInt32(arr[6]), eh_btn));
                }
                return arrayList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///  NonQuery
        /// </summary>
        /// <returns></returns>
        /// 
        public bool Post2(string url, Hashtable ht)
        {
            WebClient client = new WebClient(); // 웹 접속 객체 생성
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); // 웹 호출 시 보낸쪽 정보 설정
            client.Encoding = Encoding.UTF8; // UTF-8 설정 하여 한글 처리하기




            NameValueCollection param = new NameValueCollection();
            byte[] result = client.UploadValues(url, "POST", param);
            string strResult = Encoding.UTF8.GetString(result);
            ArrayList strJ = JsonConvert.DeserializeObject<ArrayList>(strResult);
            for (int i = 0; i < strJ.Count; i++)
            {

                JObject jo = (JObject)strJ[i];
                //listView.Items.Add((string)jp.Value);
                string[] arr = new string[jo.Count];
                foreach (JProperty jp in jo.Properties())
                {//jp.Name,jp.Value

                    //Console.WriteLine("{0} : {1}", jp.Name, jp.Value); 
                    if (jp.Name == "m_bNo")
                    {
                        arr[0] = (string)jp.Value;
                    }
                    else if (jp.Name == "c_Menu")
                    {
                        arr[1] = (string)jp.Value;
                    }
                    else if (jp.Name == "sum(cm.c_Count)")
                    {
                        arr[2] = (string)jp.Value;
                    }

                }
            }
            return true;
        }

        public bool Post(string url, Hashtable ht)
        {
            //MessageBox.Show(url);
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    //MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] result = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(result);
                //MessageBox.Show(resultStr);
                if ("1" == resultStr)
                {
                    //MessageBox.Show("결제가 완료 되었습니다.!");
                }
                else
                {
                    //MessageBox.Show("결제 실패!!");
                }

                return true;
            }
            catch
            {
                MessageBox.Show("실패");
                return false;
            }
        }

    }
}