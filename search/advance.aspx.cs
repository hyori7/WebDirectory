using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Version = Lucene.Net.Util.Version;
using General;
using DataAccess;
using System.IO;

public partial class search_advance : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        go("../search/list.aspx?search=" + Param.getString("search") + "&page=" + 1 + "&range=" + 5 + "&type=" + 1);
    }
}