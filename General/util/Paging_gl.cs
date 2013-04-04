using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace General
{
    public class Paging_gl
    {

        public int setPage(Data data)
        {
            int count = findTotalPost(data);
            int intCount = count / 10;
            double doubleCount = (double)count / 10;
            if (doubleCount > intCount)
            {
                return intCount + 1;
            }
            else return intCount;
        }

        public int findTotalPost(Data data)
        {
            Lucene_gl lucene = new Lucene_gl();
            Profile_gl profile = new Profile_gl();
            if (data.getString("search") == "")
            {
                return profile.selectAll(data).Count;
            }
            else
            {
                return lucene.searchLucene(data).Count;
            }
            
        }

        public int getCurrentSearchPage(string page)
        {
            return (Int32.Parse(page) - 1) * 10;
        }

        public bool previousPage(string page)
        {
            if (Int32.Parse(page) == 1)
            {
                return true;
            }

            else return false;
        }

        public bool nextPage(string page, int count)
        {
            if (Int32.Parse(page) == count)
            {
                return true;
            }

            else return false;
        }
    }
}
