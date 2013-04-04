using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class Rating_db
    {
        public bool insert(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert("INSERT INTO rating(value, profile_id, user_id) VALUES (@value, @profile_id, @user_id)", data);
            db.close();
            return true;
        }

        public Data getRatingOne(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT value FROM rating WHERE value=5 AND profile_id=@profile_id", data);
            db.close();
            return result;
        }

        public Data getRatingTwo(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT value FROM rating WHERE value=4 AND profile_id=@profile_id", data);
            db.close();
            return result;
        }

        public Data getRatingThree(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM rating WHERE value=3 AND profile_id=@profile_id", data);
            db.close();
            return result;
        }

        public Data getRatingFour(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT value FROM rating WHERE value=2 AND profile_id=@profile_id", data);
            db.close();
            return result;
        }

        public Data getRatingFive(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT value FROM rating WHERE value=1 AND profile_id=@profile_id", data);
            db.close();
            return result;
        }

        public Data getTotalRating(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT value FROM rating WHERE profile_id=@profile_id", data);
            db.close();
            return result;
        }

        public Data checkUserRating(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT id FROM rating WHERE profile_id=@profile_id AND user_id=@user_id", data);
            db.close();
            return result;
        }

        public bool update(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert(@"UPDATE rating SET value=@value WHERE profile_id=@profile_id AND user_id=@user_id", data);
            db.close();
            return true;
        }

        public Data totalRating(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT sum(value) FROM rating WHERE profile_id=@profile_id", data);
            data.add("sum_rating", result.getString("sum(value)"));
            Data total = db.select("SELECT value FROM rating WHERE profile_id=@profile_id", data);
            db.close();
            return total;
        }

        public Data numPerRate(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT id FROM rating WHERE profile_id=@profile_id AND value=@value", data);
            db.close();
            return result;
        }
    }
}
