using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Linq;
using System.Text;
using DataAccess;

namespace General
{
    public class MasterBasePage : MasterPage
    {
        private Data param = null;
        private Data paramUrl = null;

        protected Data Param
        {
            get
            {
                param = RequestPage.Form(Request);
                if (param.Count == 0)
                {
                    param = RequestPage.Query(Request);
                }
                if (param.Count == 0)
                {
                    param = RequestPage.Param(Request);
                }
                return param;
            }
        }

        protected Data ParamUrl
        {
            get
            {
                paramUrl = RequestPage.Query(Request);
                return paramUrl;
            }
        }

        protected void go(string url)
        {
            Response.Redirect(url);
        }

        protected string replace(string content)
        {
            if (content.IndexOf("Quote") != -1)
            {
                string ct = content.Replace("[Quote]", "<div class=\"quote-style\">").Replace("[/Quote]", "</div>");
                return ct;
            }

            if (content.IndexOf("div") != -1)
            {
                string ct = content.Replace("<div class=\"quote-style\">", "[Quote]").Replace("</div>", "[/Quote]");
                return ct;
            }
            else return content;
        }

        protected string deletePost(string content)
        {
            return content = "Post has been removed by User!";
        }

        protected void setPageTypeSession(HttpSessionState session, string page)
        {
            session["pageType"] = page;
        }

        protected String getPageType(HttpSessionState session)
        {
            return session["pageType"].ToString();
        }

    }
}
