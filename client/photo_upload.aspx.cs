using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using General;

public partial class client_photo_upload : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Data data = new Data();
        Profile_gl profile = new Profile_gl();
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

        //resize photo in album with top/left negative px value with fixed size image.
    }
    protected void upload_Click(object sender, EventArgs e)
    {
        Data data = new Data();
        ImageReformat format = new ImageReformat();
        Stream imgStream = photo_upload.PostedFile.InputStream;
        string name = photo_upload.FileName.ToString();
        string path = "../image/client/" + name;
        string _path = Server.MapPath("../image/client/" + name);
        format.uploadImage(imgStream, _path);
        Photo_gl photo = new Photo_gl();
        data.add("caption", Param.getValue("caption"));
        data.add("profile_id", Param.getValue("profileID"));
        data.add("path", path);
        data.add("name", name);
        photo.insert(data);
        go("../client/photo_upload.aspx?profile=" + Param.getString("profileName") + "&id=" + Param.getString("profileID"));
    }

}