using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using DataAccess;

namespace General
{
    public class Photo_gl
    {
        public bool insert(Data data)
        {
            Photo_db photo = new Photo_db();
            return photo.insert(data);
        }

        public Data select(Data data)
        {
            Photo_db photo = new Photo_db();
            return photo.select(data);
        }

        public Data selectImage(Data data)
        {
            Photo_db photo = new Photo_db();
            return photo.selectImage(data);
        }
    }
}
