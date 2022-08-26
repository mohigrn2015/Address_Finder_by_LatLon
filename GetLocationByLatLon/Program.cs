﻿using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace GetLocationByLatLon
{
    class Program
    {
        static void Main(string[] args)
        {
            RootObject rootObject = getAddress(24.738290, 90.405240);
            Console.WriteLine("Full Address " + rootObject.display_name);
            Console.ReadLine();
        }

        public static RootObject getAddress(double lat, double lon)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            webClient.Headers.Add("Referer", "http://www.microsoft.com");
            var jsonData = webClient.DownloadData("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + lat + "&lon=" + lon);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
            RootObject rootObject = (RootObject)ser.ReadObject(new MemoryStream(jsonData));
            webClient.Encoding = System.Text.Encoding.UTF8;
            return rootObject;
        }
    }

}
