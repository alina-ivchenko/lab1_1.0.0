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

namespace lab1_vk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string urlBegin = "http://www.nbrb.by/API/ExRates/Rates/";
            string[] urlCode = new string[] { "840", "978", "643" };
            string urlEnd = "?ParamMode=1";

            //var curList = new List<CurInfo>();
            var curItem = new CurInfo();
            //bool flag = true;
            while(true)
            {
                tBInfo.Clear();
                for (int i = 0; i < urlCode.Length; i++)
                {
                    string url = urlBegin + urlCode[i] + urlEnd;
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    string response;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        response = streamReader.ReadToEnd();
                    }
                    //curList.Add(JsonConvert.DeserializeObject<CurInfo>(response));
                    curItem = JsonConvert.DeserializeObject<CurInfo>(response);
                    tBInfo.AppendText(curItem.Cur_Abbreviation + "   " + curItem.Cur_OfficialRate + Environment.NewLine);
                }
                Thread.Sleep(10000);
            }
        }
    }
}
