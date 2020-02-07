using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //因為分頁裡已經有抓command跟gridview結合了
                //string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                //SqlConnection cn = new SqlConnection(config);
                //SqlCommand cm = new SqlCommand($"select id,Title,initdate,case TopNews when 1 then '是' else '否' end as TopNews from News order by initdate desc", cn);
                //cn.Open();

                //SqlDataReader reader = cm.ExecuteReader();
                //GridView1.DataSource = reader;
                //GridView1.DataBind();
                //cn.Close();


                if (Session.Count > 1)
                {
                    tbDateFrom.Text = Session["From"].ToString();
                    tbDateTo.Text = Session["To"].ToString();
                }
                Show();
            }

            
        }



        protected void EditNews_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysEditNews.aspx");
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDel")
            {
                Button btnDel = (Button) e.CommandSource;
                GridViewRow myRow = (GridViewRow) btnDel.NamingContainer;
                //Label lbDel = (Label)GridView1.Rows[myRow.DataItemIndex]
                int num = Int32.Parse(((HiddenField) myRow.FindControl("HiddenFieldDel")).Value);

                
                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"delete from News where id = {num}", cn);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }

                Response.Redirect("SysNews.aspx");


        }

        //宣告一頁有幾個項目
        private const int PageSize = 5;

        private void Show()
        {
                ListNumber dl = new ListNumber();
                //int totaleItems = dl.GetPublishListCount("N01", "", "", txtSearch.Text, "", DataLayer.SortMethed.OrderByInitDate, true);
                int totaleItems = dl.GetListCount(tbDateFrom.Text,tbDateTo.Text);//計算總共有幾筆
                Pagination1.totalitems = totaleItems;
                Pagination1.limit = PageSize;
                Pagination1.targetpage = "SysNews.aspx";
                //技巧:利用這種方式才可以呼叫usercontrol裡的public method
                UserControl_Pagination uc = Pagination1;
                uc.showPageControls();
                DataTable dt = dl.GetMyDataList("", "", tbDateFrom.Text, tbDateTo.Text, "", PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
                GridView1.DataSource = dt;
                GridView1.DataBind();
        }


        protected void btnSearchDate_OnClick(object sender, EventArgs e)
        {

            DateTime dt = Convert.ToDateTime(tbDateTo.Text).AddDays(1);
            Session["From"] = tbDateFrom.Text;
            Session["To"] = tbDateTo.Text;
            Show();
            
        
        }

        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SysNews.aspx");
        }
    }
}