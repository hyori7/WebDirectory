using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General;
using DataAccess;

public partial class client_photo : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Photo_gl photo = new Photo_gl();
            User_gl user = new User_gl();
            Data data = new Data(); 
            Data list = photo.select(Param);
            profileName.Value = Param.getString("profile");
            profileID.Value = Param.getString("id");
            photoView.DataSource = list.Source;
            photoView.DataBind();
            data.add("imageId", Param.getString("image"));
            Data imageList = photo.selectImage(data);
            imagePop.ImageUrl = imageList.getString("path");
            checkImage.Value = imageList.getString("path");
            caption.Text = imageList.getString("caption");
            setPageTypeSession(Session, "photo");
            //set a size for photo album, set overflowhidden, fixed small images and top/left with minus fixed pixels
        }
    }

    protected void photo_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "photoCall")
        {
            DataListItem item = (DataListItem)(((ImageButton)(e.CommandSource)).NamingContainer);
            string id = ((HiddenField)item.FindControl("imageId")).Value;
            go("../client/photo.aspx?profile=" + Param.getString("profileName") + "&id=" + Param.getString("profileID") + "&image=" + id);
        }

    }
}