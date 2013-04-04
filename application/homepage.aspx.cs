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

public partial class application_homepage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        Search_gl search = new Search_gl();
        string urlString = search.urlSearch(Param);
        go("../search/list.aspx?search=" + Param.getString("search") + "&page=" + 1 + urlString); //dynamic url data
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static String[] searchContent(string prefixText, int count)
    {
        Search_gl search = new Search_gl();
        Data data = new Data();
        data.add("search", prefixText);
        Lucene_gl lucene = new Lucene_gl();
        Data list = lucene.searchLucene(data);
        return search.list(list);
    }
}