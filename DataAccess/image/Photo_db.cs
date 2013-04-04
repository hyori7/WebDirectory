using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Photo_db
    {
        public bool insert(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert("INSERT INTO image(name, path, caption, profile_id) VALUES (@name, @path, @caption, @profile_id)", data);
            db.close();
            return true;
        }

        public Data select(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT * FROM image WHERE profile_id=@id", data);
            db.close();
            return result;
        }

        public Data selectImage(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT path, caption FROM image WHERE id=@imageId", data);
            db.close();
            return result;
        }
    }
}
