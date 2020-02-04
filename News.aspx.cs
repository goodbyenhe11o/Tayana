using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace TayanaSystem
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




            if (!IsPostBack)
            {

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"Select * from News ORDER BY [Top] desc ,initdate DESC", cn);
            cn.Open();
            SqlDataReader rd = cm.ExecuteReader();
            rpContnet.DataSource = rd;
            rpContnet.DataBind();
            cn.Close();
            Show();
            }

        }
        //宣告一頁有幾個項目
        private const int PageSize = 10;

        private void Show()
        {
            ListNumber dl = new ListNumber();
            //int totaleItems = dl.GetPublishListCount("N01", "", "", txtSearch.Text, "", DataLayer.SortMethed.OrderByInitDate, true);
            int totaleItems = dl.GetDataCount();//計算總共有幾筆
            Pagination1.totalitems = totaleItems;
            Pagination1.limit = PageSize;
            Pagination1.targetpage = "News.aspx";
            //技巧:利用這種方式才可以呼叫usercontrol裡的public method
            UserControl_Pagination uc = Pagination1;
            uc.showPageControls();
            DataTable dt = dl.GetMyDataList("", "", "", "", "", PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
            rpContnet.DataSource = dt;
            rpContnet.DataBind();

        }


    }

    
}