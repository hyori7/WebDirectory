using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General;
using DataAccess;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

public partial class client_profile : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Profile_gl profile = new Profile_gl();
            User_gl user = new User_gl();
            Data data = new Data();
            if (user.isLogin(Session) == true)
            {
                data.add("username", user.getUsername(Session));
                data.add("user_id", user.getUserID(data).getString("id"));
                edit.Visible = true;
            }
            
            Data list = profile.select(Param);
            nameLbl.Text = list.getString("name");
            trading_hour.Text = Server.HtmlDecode(list.getString("trading_hour"));
            phone.Text = Server.HtmlDecode(list.getString("phone"));
            address.Text = list.getString("address");
            email.Text = list.getString("email");
            summary.Text = Server.HtmlDecode(list.getString("summary"));
            profile_name.Value = list.getString("name");
            profile_id.Value = list.getString("id");
            data.add("profile_id", list.getString("id"));

            //rating in percentage
            Rating_gl rating = new Rating_gl();
            data.add("totalRating", rating.getTotalRating(data).ToString());
            rating1.Value = rating.getRatingOne(data).ToString();
            rating2.Value = rating.getRatingTwo(data).ToString();
            rating3.Value = rating.getRatingThree(data).ToString();
            rating4.Value = rating.getRatingFour(data).ToString();
            rating5.Value = rating.getRatingFive(data).ToString();
            setPageTypeSession(Session, "profile");
            
            //number of rated users
            numRated1.Text = rating.numPerRate(data, "5").ToString();
            numRated2.Text = rating.numPerRate(data, "4").ToString();
            numRated3.Text = rating.numPerRate(data, "3").ToString();
            numRated4.Text = rating.numPerRate(data, "2").ToString();
            numRated5.Text = rating.numPerRate(data, "1").ToString();
            double totalRating = rating.averageRating(data);
            totalRatingLbl.Text = string.Format("{0:0.##}", totalRating);
            rating_status.Value = rating.rateStatus(Session, data);
            
        }
       
    }
    protected void edit_Click(object sender, EventArgs e)
    {
        go("../client/profile_panel.aspx?profile=" + Param.getString("profile_name") + "&id=" + Param.getString("profile_id"));
    }

    protected void rateClick(object sender, EventArgs e)
    {
        Data data = new Data();
        User_gl user = new User_gl();
        Rating_gl rating = new Rating_gl();
        data.add("username", user.getUsername(Session));
        data.add("value", radioRate.SelectedValue);
        data.add("profile_id", Param.getString("profile_id"));
        data.add("user_id", user.getUserID(data).getString("id"));
        if (Param.getString("rating_status") == "3")
        {
            rating.update(data);
        }
        else if(Param.getString("rating_status") == "1")
        {
            rating.insert(data);
        }

        go("../client/profile.aspx?profile=" + Param.getString("profile_name") +"&id=" + data.getString("profile_id"));
    }

}