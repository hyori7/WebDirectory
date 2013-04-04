using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General;
using DataAccess;

public partial class client_profile_panel : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Data data = new Data();
            Profile_gl profile = new Profile_gl();
            User_gl user = new User_gl();
            data.add("username", user.getUsername(Session));
            Data list = profile.select(Param);
            name.Text = list.getString("name");
            trading_hour.Text = list.getString("trading_hour");
            phone.Text = list.getString("phone");
            address.Text = list.getString("address");
            email.Text = list.getString("email");
            summary.Text = list.getString("summary");
            profileID.Value = list.getString("id");
            
        }

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Lucene_gl lucene = new Lucene_gl();
        Data data = new Data();
        Profile_gl profile = new Profile_gl();
        profile.update(Param);
        lucene.addLucene(data);
        go("../client/profile.aspx?profile=" + Param.getString("name") + "&id=" + Param.getString("profileID"));

    }
}