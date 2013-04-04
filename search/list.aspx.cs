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

public partial class search_list : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Data data = new Data();
            Search_gl search = new Search_gl();
            Paging_gl page = new Paging_gl();
            Profile_gl profile = new Profile_gl();
            Lucene_gl lucene = new Lucene_gl();
            Data list = null;
            data.add("search", search.searchUrlConversion(Param.getString("search")));
            data.add("page", page.getCurrentSearchPage(Param.getString("page")));
            data.add("range", Param.getString("range"));
            data.add("rate", Param.getString("rate"));

            if (data.getString("search") == "")
            {
                list = search.selectAll(data);
            }
            else
            {
                list = lucene.searchLucene(data);
            }
            int count = page.setPage(data);
            for (int i = 1; i <= count; i++)
            {
                dropDownPage.Items.Add(new ListItem(i.ToString()));
            }
            dropDownPage.SelectedValue = Param.getString("page");

            if (page.previousPage(Param.getString("page")) == true)
            {
                previous.Visible = false;
            }

            if (page.nextPage(Param.getString("page"), count) == true)
            {
                next.Visible = false;
            }
            // data.add all values in to same array, pass data array to advance search class in logical lib and split in to multiple search methods.
            if (data.getString("range") != "" && data.getString("search") != "") 
            {
                int range = Convert.ToInt32(data.getString("range"));
                if (range > 0)
                {
                    data.add("address", data.getString("search"));
                    list = search.searchRadius(data); 
                }
            }


            searchView.DataSource = list.Source;
            searchView.DataBind();





        }
    }


    protected void dropDownPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        string page = dropDownPage.SelectedItem.ToString();
        go("../search/list.aspx?search=" + Param.getString("search") + "&page=" + page);
    }

    protected void next_Click(object sender, EventArgs e)
    {
        int page = Int32.Parse(dropDownPage.SelectedItem.ToString()) + 1;
        go("../search/list.aspx?search=" + Param.getString("search") + "&page=" + page);
    }
    protected void previous_Click(object sender, EventArgs e)
    {
        int page = Int32.Parse(dropDownPage.SelectedItem.ToString()) - 1;
        go("../search/list.aspx?search=" + Param.getString("search") + "&page=" + page);
    }
}