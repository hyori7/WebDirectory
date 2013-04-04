using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class User_db
    {
        public bool register_user(Data data)
        {
            Data db = new Data();
            db.open();
            int result = db.insert("INSERT INTO user(username, password, firstname, lastname) VALUES (@username, @password, @firstname, @lastname)", data);
            db.close();
            return true;
        }

        public Data login(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT username, firstname, lastname FROM user WHERE username = @username AND password = @password", data);
            db.close();
            return result;
        }

        public Data getUserID(Data data)
        {
            Data db = new Data();
            db.open();
            Data result = db.select("SELECT id, username FROM user WHERE username=@username", data);
            db.close();
            return result;
        }
    }
}
