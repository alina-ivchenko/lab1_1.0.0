using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Globalization;

namespace lab1_vk
{
    public partial class Form1 : Form
    {
        private const string localTime = "ru-RU";
        private const string urlBegin = "http://www.nbrb.by/API/ExRates/Rates/";
        private string[] urlCode = new string[] { "840", "978", "643", "980" };
        private const string urlEnd = "?ParamMode=1";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Update(urlBegin, urlCode, urlEnd, localTime);
        }

        private async void GetCur(string urlBegin, string[] urlCode, string urlEnd)
        {
            //var curItem = new CurInfo();
            string response;// = new string[urlCode.Length];
            
            tBInfo.Clear();

            try
            {
                for (int i = 0; i < urlCode.Length; i++)
                {
                    string url = urlBegin + urlCode[i] + urlEnd;
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                     
                    //HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //var httpWebResponse = await httpWebRequest.GetRequestStreamAsync();
                    var httpWebResponse = await httpWebRequest.GetResponseAsync();
                    //string response;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        response = streamReader.ReadToEnd();
                    }

                    /*var newThread = new Thread(new ParameterizedThreadStart(DeserializeResponce));
                    newThread.Start(response);*/

                    var curItem = new CurInfo(); 
                    curItem = JsonConvert.DeserializeObject<CurInfo>(response);
                    tBInfo.AppendText(curItem.Cur_Scale + " " + curItem.Cur_Abbreviation + "   " + curItem.Cur_OfficialRate + Environment.NewLine);
                }
            }
            catch
            {
                MessageBox.Show("OOPS!");
            }
        }

       /* private void DeserializeResponce(Object obj)
        {
            string response = (string)obj;
            var curItem = new CurInfo();
            curItem = JsonConvert.DeserializeObject<CurInfo>(response);
            //tBInfo.AppendText(curItem.Cur_Scale + " " + curItem.Cur_Abbreviation + "   " + curItem.Cur_OfficialRate + Environment.NewLine);
            //return (curItem.Cur_Scale + " " + curItem.Cur_Abbreviation + "   " + curItem.Cur_OfficialRate);
        }*/

        private string GetTime(string localTime)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo(localTime);
            return localDate.ToString(culture);
        }

        private void Update(string urlBegin, string[] urlCode, string urlEnd, string localTime)
        {
            GetCur(urlBegin, urlCode, urlEnd);
            lblTimeUpdate.Text = GetTime(localTime);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update(urlBegin, urlCode, urlEnd, localTime);
        }
    }
}
