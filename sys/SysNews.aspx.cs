using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"select id,Title,initdate,case [Top] when 1 then '是' else '否' end as N'Top'from News order by initdate desc", cn);
            cn.Open();

            SqlDataReader reader = cm.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            cn.Close();
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
    }
}