using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace General
{
    public class Register_client_gl
    {
        public bool insert(Data data)
        {
            Register_client_db client = new Register_client_db();
            return client.insert(data);
        }
    }
}
