﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace xml_parsing_Test
{
    public static class OpneApi
    {
        public static string OpenApiGetFile()
        {
            //데이터 호출(Xml)
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + ApiKey.Getkey(); // Service Key
                                                     //url += "&pageNo=1";
                                                     //url += "&numOfRows=10";
            url += "&startCreateDt=20211124";
            //url += "&endCreateDt=20211124";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            String results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            //Xml 파일처리
            StreamWriter writer;
            writer = File.CreateText("Civ19.Xml");
            writer.Write(results);
            writer.Close();

            return results;
        }
    }
}
