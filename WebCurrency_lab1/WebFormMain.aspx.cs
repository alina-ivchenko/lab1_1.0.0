using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Globalization;

namespace WebCurrency_lab1
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        private const string localTime = "ru-RU";
        private const string urlBegin = "http://www.nbrb.by/API/ExRates/Rates/";
        private string[] urlCode = new string[] { "840", "978", "643", "980" };
        private const string urlEnd = "?ParamMode=1";

        //private int cellCnt = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Update(urlBegin, urlCode, urlEnd, localTime);
        }

        private void GetCur(string urlBegin, string[] urlCode, string urlEnd)
        {

          
            var curItem = new CurInfo();
            
            //tBInfo.Clear();
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
               
                curItem = JsonConvert.DeserializeObject<CurInfo>(response);
                //tBInfo.AppendText(curItem.Cur_Scale + " " + curItem.Cur_Abbreviation + "   " + curItem.Cur_OfficialRate + Environment.NewLine);

                TableRow tRow = new TableRow();
      TableCur.Rows.Add(tRow);
      for (int cellCtr = 1; cellCtr <= 2; cellCtr++)
      {
          // Create a new cell and add it to the row.
          TableCell tCell = new TableCell();
          //tCell.Text = "Row " + (i + 1) + ", Cell " + cellCtr;
          if (cellCtr == 1)
          {
              tCell.Text = curItem.Cur_Scale + " " + curItem.Cur_Abbreviation + ":   ";
          }
          else
          {
              tCell.Text = curItem.Cur_OfficialRate;
          }
           
          tRow.Cells.Add(tCell);
      }
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
            //lblTimeUpdate.Text = GetTime(localTime);
            LabelTimeUpdate.Text = GetTime(localTime);
        }
    }
}

/*<td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td></td>*/