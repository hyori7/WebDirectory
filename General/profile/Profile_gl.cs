using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using DataAccess;

namespace General
{
    public class Profile_gl
    {
        public bool insert(Data data)
        {
            Profile_db profile = new Profile_db();
            GoogleMap_gl google = new GoogleMap_gl();
            data.add("latitude", google.GetLatitudeLongitude(data).Item1.ToString());
            data.add("longitude", google.GetLatitudeLongitude(data).Item2.ToString());
            return profile.insert(data);
        }

        public Data select(Data data)
        {
            Profile_db profile = new Profile_db();
            return profile.select(data);
        }

        public bool update(Data data)
        {
            Profile_db profile = new Profile_db();
            GoogleMap_gl google = new GoogleMap_gl();
            data.add("latitude", google.GetLatitudeLongitude(data).Item1.ToString());
            data.add("longitude", google.GetLatitudeLongitude(data).Item2.ToString());
            return profile.update(data);
        }

        public Data selectInserted(Data data)
        {
            Profile_db profile = new Profile_db();
            return profile.selectInserted(data);
        }

        public Data selectAll(Data data)
        {
            Profile_db profile = new Profile_db();
            return profile.selectAll(data);
        }

    }
}
