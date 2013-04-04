using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using DataAccess;

namespace General
{
    public class Rating_gl
    {
        public bool insert(Data data)
        {
            Rating_db rating = new Rating_db();
            return rating.insert(data);
        }

        public bool update(Data data)
        {
            Rating_db rating = new Rating_db();
            return rating.update(data);
        }

        public Double getRatingOne(Data data)
        {
            Rating_db rating = new Rating_db();
            if (Convert.ToInt32(data.getString("totalRating")) > 0)
            {
                return (double)rating.getRatingOne(data).Count / (double)Convert.ToDouble(data.getString("totalRating")) * 100;
            }
            else
            {
                return 0;
            }
        }

        public Double getRatingTwo(Data data)
        {
            Rating_db rating = new Rating_db();
            if (Convert.ToInt32(data.getString("totalRating")) > 0)
            {
                return (double)rating.getRatingTwo(data).Count / (double)Convert.ToDouble(data.getString("totalRating")) * 100;
            }
            else
            {
                return 0;
            }
        }

        public Double getRatingThree(Data data)
        {
            Rating_db rating = new Rating_db();
            if (Convert.ToInt32(data.getString("totalRating")) > 0)
            {
                return (double)rating.getRatingThree(data).Count / (double)Convert.ToDouble(data.getString("totalRating")) * 100;
            }
            else
            {
                return 0;
            }
        }

        public Double getRatingFour(Data data)
        {
            Rating_db rating = new Rating_db();
            if (Convert.ToInt32(data.getString("totalRating")) > 0)
            {
                return (double)rating.getRatingFour(data).Count / (double)Convert.ToDouble(data.getString("totalRating")) * 100;
            }
            else
            {
                return 0;
            }
        }

        public Double getRatingFive(Data data)
        {
            Rating_db rating = new Rating_db();
            if (Convert.ToInt32(data.getString("totalRating")) > 0)
            {
                return (double)rating.getRatingFive(data).Count / (double)Convert.ToDouble(data.getString("totalRating")) * 100;
            }
            else
            {
                return 0;
            }
        }

        public int getTotalRating(Data data)
        {
            Rating_db rating = new Rating_db();
            return rating.getTotalRating(data).Count;
        }

        public bool checkUserRating(Data data)
        {
            Rating_db rating = new Rating_db();
            if (rating.checkUserRating(data).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public String rateStatus(HttpSessionState session, Data data)
        {
            User_gl user = new User_gl();
            Rating_gl rating = new Rating_gl();

            if (user.isLogin(session) == false)
            {
                return "2";
            }

            else
            {
                if (rating.checkUserRating(data) == true)
                {
                    return "3";
                }

                else
                {
                    return "1";
                }
            }
        }

        public Double averageRating(Data data)
        {
            Rating_db rating = new Rating_db();
            int total = rating.totalRating(data).Count;
            if (total == 0)
            {
                return 0;
            }
            else
            {
                int value = Convert.ToInt32(data.getString("sum_rating"));
                double average = ((double)value / (double)(total * 5)) * 5;
                return average;
            }
        }

        public int numPerRate(Data data, String value)
        {
            Rating_db rating = new Rating_db();
            data.add("value", value);
            return rating.numPerRate(data).Count;
        }
    }
}
