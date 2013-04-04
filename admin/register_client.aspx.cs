using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General;
using DataAccess;

public partial class admin_register_client : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Data param = Param;
        Register_client_gl register = new Register_client_gl();
        register.insert(param);
    }
}