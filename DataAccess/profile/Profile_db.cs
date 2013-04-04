using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class Profile_db
    {
        public bool insert(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert(@"INSERT INTO profile(name, trading_hour, phone, address, email, summary, latitude, longitude) 
                                   VALUES (@name, @trading_hour, @phone, @address, @email, @summary, @latitude, @longitude)", data);
            db.close();
            return true;
        }

        public Data select(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM profile WHERE id=@id", data);
            db.close();
            return result;
        }

        public bool update(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert(@"UPDATE profile SET name=@name, trading_hour=@trading_hour, phone=@phone, address=@address, 
                                   email=@email, summary=@summary, latitude=@latitude, longitude=@longitude WHERE id=@profileID", data);
            db.close();
            return true;
        }

        public bool checkProfile(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM profile WHERE id=@profile_id", data);
            db.close();
            if (result.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Data selectInserted(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM profile WHERE name=@name AND address=@address AND email=@email AND phone=@phone", data);
            db.close();
            return result;
        }

        public Data selectAll(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM profile ORDER BY name ASC LIMIT 1000", data);
            db.close();
            return result;
        }
    }
}
