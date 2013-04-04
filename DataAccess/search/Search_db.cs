using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Search_db
    {
        public Data search(Data data, String[] item)
        {
            Data db = new Data();
            string items = "";
            db.open();
            string query = queryType(data);
            for (int i = 0; i < item.Count(); i++)
            {
                int count = item.Count();
                if (i == count - 1)
                {
                    items = items + item[i];
                }
                else
                {
                    items = items + item[i] + ",";
                }
            }
            query = query.Replace("<SEARCH>", items);
            Data result = db.select(query, data);
            db.close();
            return result;
        }

        private string queryType(Data data)
        {
            if (data.get("page") == null)
            {
                return "SELECT * FROM profile WHERE id IN(<SEARCH>)";
            }
            else
            {
                return "SELECT * FROM profile WHERE id IN(<SEARCH>) ORDER BY name ASC LIMIT @page, 10";
            }
        }

        public Data selectAll(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM profile ORDER BY name ASC LIMIT @page, 10", data);
            db.close();
            return result;
        }

        public Data getSearchForIndex(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM profile", data);
            db.close();
            return result;
        }

        public Data searchAll(Data data)
        {
            rating rating = new Rating_db();
            Data db = new Data();
            db.open();
            Data result = db.select(@"SELECT * FROM profile WHERE latitude<@eastLatitude AND latitude>@westLatitude 
                                    AND longitude<@northLongitude AND longitude>@southLongitude", data);
            result.getString("averageRating", rating.
            db.close();
            return result;
        }

    }
}
