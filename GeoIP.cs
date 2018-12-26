using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NonstopCoding.Models;

using System.Net;
using System.IO;
using Newtonsoft.Json;


namespace NonstopCoding
{
    public class GeoIP
    {
        string _ipaddr; 

        public GeoIP(string IPAddress)
        {
            _ipaddr = IPAddress;
        }

        public GeoIPModel GetGeoIP()
        {
            var request = WebRequest.CreateHttp($"http://ip-api.com/json/{_ipaddr}");
            using (var response = request.GetResponse())
            using (var resStream = response.GetResponseStream())
            {
                var reader = new StreamReader(resStream);
                var json = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<GeoIPModel>(json);
            }
        }

    }
}
