using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using DataAccess;

namespace General
{
    public class GoogleMap_gl
    {
        public Double northLongitude(int range, double longitude)
        {
            double sumRange = range * (double)0.02252127;
            double total = longitude + sumRange;
            return total;
        }

        public Double southLongitude(int range, double longitude)
        {
            double sumRange = range * (double)0.02252127;
            double total = longitude - sumRange;
            return total;
        }

        public Double eastLatitude(int range, double latitude)
        {
            double sumRange = range * (double)0.00899928;
            double total = latitude + sumRange;
            return total;
        }

        public Double westLatitude(int range, double latitude)
        {
            double sumRange = range * (double)0.00899928;
            double total = latitude - sumRange;
            return total;
        }

        public Tuple<String, String> GetLatitudeLongitude(Data data)
        {
            string address = data.getString("address");
            string url = "http://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&sensor=false";
            string result = string.Empty;
            //Get geocode response
            WebClient Client = new WebClient();
            using (Stream strm = Client.OpenRead(url))
            {
                StreamReader sr = new StreamReader(strm);
                result = sr.ReadToEnd();
            }
            //Deserialize into .Net object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            MyGeoCodeResponse _MyGeoCodeResponse = ser.Deserialize<MyGeoCodeResponse>(result);

            string _latitude = _MyGeoCodeResponse.results[0].geometry.location.lat;
            string _longitude = _MyGeoCodeResponse.results[0].geometry.location.lng;
            return new Tuple<string, string>(_latitude, _longitude);
        }

        public class MyGeoCodeResponse
        {
            public string status { get; set; }
            public results[] results { get; set; }
        }

        public class results
        {
            public string formatted_address { get; set; }
            public _geometry geometry { get; set; }
            public string[] types { get; set; }
            public _address_component[] address_components { get; set; }
        }

        public class _geometry
        {
            public string location_type { get; set; }
            public _location location { get; set; }
            public _bounds bounds { get; set; }
        }

        public class _location
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class _bounds
        {
            public _northeast northeast { get; set; }
            public _southwest southwest { get; set; }
        }

        public class _northeast
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class _southwest
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class _address_component
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
    }
}
