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

namespace mojavePos.Han
{
    class WebComm
    {
        /// <summary>
        /// Select API 작성
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool SelectListView(string url, ListView listView)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                //출력
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                listView.Items.Clear();

                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        //MessageBox.Show(list.Count.ToString());
                        //MessageBox.Show(ja[j].ToString());
                        arr[j] = ja[j].ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///  NonQuery
        /// </summary>
        /// <returns></returns>
        /// 
        public string[] str(ArrayList list)
        {

            string[] arr = null;
            ArrayList arry = new ArrayList();
            try
            {

                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                }
             

                return arr;
            }
            catch
            {
                
                return null; 
            }
        }
        public ArrayList Cut(ArrayList list)
        {
            
            //string[] arr = null;
            ArrayList arry = new ArrayList();
            try
            {

                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    //arr = new string[ja.Count];

                    for (int j = 0; j < ja.Count; j++)
                    {
                        arry.Add(ja[j].ToString());
                    }

                }
                MessageBox.Show("성공!");

                return arry;
            }
            catch
            {
                MessageBox.Show("실패!");
                return new ArrayList();
            }
        }

        public bool Post2(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                Stream st = wc.OpenRead(url);

                StreamReader sr = new StreamReader(st);
                string str = sr.ReadToEnd();
                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Post(string url, Hashtable ht)
        {
            MessageBox.Show(url);
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] result = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(result);
                MessageBox.Show(resultStr);
                if ("1" == resultStr)
                {
                    MessageBox.Show("성공");
                }
                else
                {
                    MessageBox.Show("실패");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }



        public ArrayList Select(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();

                foreach (DictionaryEntry data in ht)
                {
                    //MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] results = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(results);
                //MessageBox.Show(resultStr);

                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(resultStr);


                return list;
            }
            catch
            {

                return null;
            }
        }

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
                        //MessageBox.Show(list.Count.ToString());
                        //MessageBox.Show(ja[j].ToString());
                        arr[j] = ja[j].ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                }
                
                return arrayList;
            }
            catch
            {
                
                return null;
            }
        }
    }
}
