using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class Register_client_db
    {
        public bool insert(Data data)
        {
            Data db = new Data();
            db.open();
            int result_business = db.insert("INSERT INTO business (company, owner, phone, address, email) VALUES (@company, @owner, @phone, @address, @email)", data);
            Object select_id = db.select("SELECT id AS business_id FROM business ORDER BY id DESC LIMIT 1", data).getValue("business_id");
            data.add("business_id", select_id);
            int result_profile = db.insert("INSERT INTO profile(business_id) VALUES (@business_id)", data);
            db.close();
            return true;
        }
    }
}
