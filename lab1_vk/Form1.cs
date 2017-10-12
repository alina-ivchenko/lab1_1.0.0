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
        public delegate void InputStrDelegate(string InputStr);

        private const string localTime = "ru-RU";
        private const string urlBegin = "http://www.nbrb.by/API/ExRates/Rates/";
        private string[] urlCode = new string[] { "840", "978", "643", "980" };
        private const string urlEnd = "?ParamMode=1";
        bool flagColorChanged = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Green;
            Update(urlBegin, urlCode, urlEnd, localTime);
        }

        private async void GetCur(string urlBegin, string[] urlCode, string urlEnd)
        {
            string response;
            
            tBInfo.Clear();
            btnUpdate.Enabled = false;

            try
            {
                for (int i = 0; i < urlCode.Length; i++)
                {
                    string url = urlBegin + urlCode[i] + urlEnd;
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                    var httpWebResponse = await httpWebRequest.GetResponseAsync();
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        response = streamReader.ReadToEnd();
                    }

                    var newThread = new Thread(new ParameterizedThreadStart(DeserializeResponce));
                    newThread.Start(response);
                    timerUpdate.Start();
                }
            }
            catch
            {
                MessageBox.Show("OOPS!");
            }
            btnUpdate.Enabled = true;
        }

        private void DeserializeResponce(Object obj)
        {
            string response = (string)obj;
            var curItem = new CurInfo();
            curItem = JsonConvert.DeserializeObject<CurInfo>(response);
            PrintInfo(curItem.Cur_Scale + " " + curItem.Cur_Abbreviation + "   " + curItem.Cur_OfficialRate + "\n");
        }

        public void PrintInfo(string inputStr)
        {
            if (InvokeRequired)
            {
                Invoke(new InputStrDelegate(PrintInfo), inputStr);
            }
            else
            {
                tBInfo.AppendText(inputStr);
            }
        }

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

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            if (!flagColorChanged)
            {
                this.BackColor = System.Drawing.Color.DarkBlue;
                flagColorChanged = true;
            }
            else
            {
                this.BackColor = System.Drawing.Color.Green;
                flagColorChanged = false;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            Update(urlBegin, urlCode, urlEnd, localTime);
        }
    }
}
