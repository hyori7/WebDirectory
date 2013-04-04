using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General;
using DataAccess;

public partial class client_new_profile : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Data data = new Data();
            User_gl user = new User_gl();
            if (user.isLogin(Session) == true)
            {
                data.add("username", user.getUsername(Session));
                profileID.Value = Param.getString("id");
                profileName.Value = Param.getString("profile");
            }
            else
            {
                go("../client/profile.aspx?profile=" + Param.getString("profile") + "&id=" + Param.getString("id"));
            }
            setPageTypeSession(Session, "new_profile");
        }


    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Lucene_gl lucene = new Lucene_gl();
        Data data = new Data();
        Profile_gl profile = new Profile_gl();
        profile.insert(Param);
        Data list = profile.selectInserted(Param);
        lucene.addLucene(list);
        go("../client/profile.aspx?profile=" + list.getString("name") + "&id=" + list.getString("id"));

    }
}