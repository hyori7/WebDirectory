using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using DataAccess;

namespace General
{
    public class User_gl : BasePage
    {
        public bool register(Data data)
        {
            User_db user = new User_db();
            string password = Cryptopraphy.Encryption(data.getString("password"));
            data.add("password", password);
            return user.register_user(data);
        }

        public Data login(Data data, HttpSessionState session)
        {
            User_db user = new User_db();
            string password = Cryptopraphy.Encryption(data.getString("password_l"));
            data.add("username", data.getString("username_l"));
            string username = data.getString("username");
            data.add("password", password);
            Data result = user.login(data);

            if (result.Count == 0)
            {
                data.add("loginError", "Invalid Input");
                return null;
            }
            setSession(session, result);
            return result;
        }

        public void setSession(HttpSessionState session, Data data)
        {
            session["username"] = data.getString("username");
        }

        public Object getUsername(HttpSessionState session)
        {
            return session["username"];
        }

       

        public Data getUserID(Data data)
        {
            User_db user = new User_db();
            return user.getUserID(data);
        }


        public void checkLogin(HttpSessionState session)
        {
            session["login"] = "error";
        }

        public Object getCheckLogin(HttpSessionState session)
        {
            return session["login"];
        }

        public void clearSessionError(HttpSessionState session)
        {
            if (session["login"] != null)
            {
                session.Remove("login");
            }
        }

        public bool isLogin(HttpSessionState session)
        {
            if (getUsername(session) == null)
            {
                return false;
            }

            else return true;
        }
    }
}
