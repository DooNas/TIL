﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Civ19_WithCsharp
{
    public class OpenApi_GetXml
    {
        static HttpClient client = new HttpClient();
        
        public async Task<String> OpenApiGetFile(int day, String key)
        {
            //데이터 호출(Xml)
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + key; // Service Key
            url += "&numOfRows=7";
            url += "&startCreateDt=" + day.ToString();
            //url += "&endCreateDt=20211124";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            String results = string.Empty;
            HttpWebResponse response ;
            using(response =request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            return results;
        }

    }
}
