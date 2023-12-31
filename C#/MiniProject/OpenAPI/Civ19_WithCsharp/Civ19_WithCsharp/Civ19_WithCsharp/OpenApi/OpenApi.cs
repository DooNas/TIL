﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Civ19_WithCsharp
{
    public class OpenApi
    {
        static HttpClient client = new HttpClient();
        String results = string.Empty;

        public String Todate() //금일 기준 7일전 날짜
        {
            String date = DateTime.Now.AddDays(-1).ToShortDateString();
            date = String.Join("", date.Split('-'));
            return date;
        }
        public String datebefore(int length) //금일 기준 7일전 날짜
        {
            String date = DateTime.Now.AddDays(-(length+1)).ToShortDateString();
            date = String.Join("",date.Split('-'));
            return date;
        }

        //await는 void, Task, Task<변수형>만 가능하다.
        //Task<변수형>경우 자리를 예약하고 해당 자리에 예약한 손님이 앉기 전까지는 다음으로 진행하지 않는다는 의미를 갖는다.
        public async Task<String> OpenApiGetData(String key, int length)
        {
            //데이터 호출(Xml)
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + key; // Service Key
            url += "&pageNo=1";
            url += "&numOfRows=" + (length + 1).ToString();
            url += "&startCreateDt=" + datebefore(length);
            url += "&endCreateDt=" + Todate();

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            //String results = string.Empty;
            HttpWebResponse response ;
            using(response =request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            return results;
        }
        public void DataToXml(String results)//Make Civ19.xml
        {
            StreamWriter writer;
            writer = File.CreateText("Civ19.xml");
            writer.Write(results);
            writer.Close();
        }

        public void XmlParsing_StringArray(String[] array, int length, int Start, int End, String node)
        {
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?
            XmlDocument xml = new XmlDocument();
            xml.Load("Civ19.xml");

            XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
            int i = length;
            foreach (XmlNode xn in xnList)
            {
                array[i] = xn[node].InnerText.Substring(Start, End); //문자형 node 데이터 추출
                if (i != 0)
                {
                    i--;
                }
            }
        }

        public void decideCnt_today(String[] createDt, int[] decideCnt, int length) //금일 인구수 확인
        {
            for (int index = 0; index < length; index++)
            {
                String D_day = createDt[index + 1];
                int TodaydecideCnt = decideCnt[index + 1] - decideCnt[index];
                if (D_day == null)  //if 더이상 출력할 요소가 없다면 종료.
                {
                    return;
                }
                createDt[index] = D_day;
                decideCnt[index] = TodaydecideCnt;
            }
        }

        public void XmlParsing_IntArray(int[] array, int length, String node)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Civ19.xml");

            XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
            int i = length;
            foreach (XmlNode xn in xnList)
            {
                array[i] = int.Parse(xn[node].InnerText); //정수형 node 데이터 추출
                if(i != 0)
                {
                    i--;
                }
            }
        }

    }
}
