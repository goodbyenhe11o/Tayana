using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"Select Title,Content from News where id = {Request.QueryString["id"]}", cn);
            
            cn.Open();
            SqlDataReader rd = cm.ExecuteReader();

            if (rd.Read())
            {
                lrTitle.Text = rd["Title"].ToString();
                lrContent.Text = rd["Content"].ToString();
            }
            cn.Close();
            }
            

        }

        protected void btnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("News.aspx");
        }
    }
}