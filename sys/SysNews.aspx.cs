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

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"select id,Title,initdate from News", cn);
            
            cn.Open();

            SqlDataReader reader = cm.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            cn.Close();
        }



        protected void EditNews_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysEditNews.aspx");
        }
    }
}