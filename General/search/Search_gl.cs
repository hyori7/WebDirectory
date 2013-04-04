using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace General
{
    public class Search_gl
    {
        public Data search(Data data, String[] item)
        {
            Search_db search = new Search_db();
            if (item.Count() == 0)
            {
                return search.selectAll(data);
            }
            return search.search(data, item);
        }

        public String[] list(Data data)
        {
            Data listItem = data;
            List<string> item = new List<string>();
            for (int i = 0; i < listItem.Count; i++)
            {
                //item.Add(listItem.getValue(i, "name").ToString() + " " + listItem.getValue(i, "address").ToString());
                item.Add(listItem.getValue(i, "name").ToString());
            }

            return item.ToArray();
        }

        public String searchUrlConversion(string stringUrl)
        {
            return stringUrl.Replace("%", " ");
        }

        public Data getSearchForIndex(Data data)
        {
            Search_db search = new Search_db();
            return search.getSearchForIndex(data);
        }

        public Data selectAll(Data data)
        {
            Search_db search = new Search_db();
            return search.selectAll(data);
        }

        public Data searchRadius(Data data)
        {
            Search_db search = new Search_db();
            GoogleMap_gl google = new GoogleMap_gl();
            double latitude = Convert.ToDouble(google.GetLatitudeLongitude(data).Item1);
            double longitude = Convert.ToDouble(google.GetLatitudeLongitude(data).Item2);
            int range = Convert.ToInt32(data.getString("range"));
            data.add("northLongitude", google.northLongitude(range, longitude));
            data.add("southLongitude", google.southLongitude(range, longitude));
            data.add("eastLatitude", google.eastLatitude(range, latitude));
            data.add("westLatitude", google.westLatitude(range, latitude));
            return data;
        }

        public Data advanceSearch(Data data)
        {
            Data radius = searchRadius(data);
            if (data.getString("search") != "" && data.getString("range") !="" && data.getString("rate") != "")
            {
                
            }

        }

        public String urlSearch(Data data)
        {
            string urlData = range(data) + sortRating(data);
            return urlData;
        }

        protected String range(Data data)
        {
            string range = data.getString("rangeDropDownList");
            if (range == "0")
            {
                return "";
            }
            else
            {
                return "&range=" + range;
            }
        }

        protected String sortRating(Data data)
        {
            string sort = data.getString("sortRateDropDownList");
            if (sort == "0")
            {
                return "";
            }
            else
            {
                return "&rate=" + sort;
            }
        }
    }
}
