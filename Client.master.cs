using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General;
using DataAccess;

public partial class Client : MasterBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            profileID.Value = Param.getString("id");
            profileName.Value = Param.getString("profile");

            pageType.Value = getPageType(Session);

            User_gl user = new User_gl();
            if (user.getCheckLogin(Session) != null)
            {
                login_error.Text = "Incorrect username or password";
                loginErrorStatus.Value = "error";
            }
            if (user.getCheckLogin(Session) == null)  
            {
                loginErrorStatus.Value = "noError";
            }
            if (user.getUsername(Session) != null)
            {
                username_m.Text = user.getUsername(Session).ToString();
                loginStatus.Value = "login";
            }
            if (user.getUsername(Session) == null)
            {
                loginStatus.Value = "default";
            }
            user.clearSessionError(Session);
        }
    }

    protected void register_Click(object sender, EventArgs e)
    {
        User_gl user = new User_gl();
        user.register(Param);
    }

    protected void login_Click(object sender, EventArgs e)
    {
        Data data = new Data();
        User_gl user = new User_gl();
        Data result = user.login(Param, Session);
        if (result == null)
        {
            user.checkLogin(Session);
            go("../client/profile.aspx?profile=" + Param.getString("profileName") + "&id=" + Param.getString("profileID"));
        }
        user.clearSessionError(Session);
        go("../client/profile.aspx?profile=" + Param.getString("profileName") + "&id=" + Param.getString("profileID"));

    }
}
