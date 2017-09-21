using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace lab1_vk_1._0._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlBegin = "http://www.nbrb.by/API/ExRates/Rates/";
            string[] urlCode = new string[] { "840", "978", "643" };
            string urlEnd = "?ParamMode=1";

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
            }
            
        }
    }
}
