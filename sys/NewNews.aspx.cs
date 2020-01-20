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
    public partial class NewNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Submit_OnClick(object sender, EventArgs e)
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"INSERT INTO News (Title,Summary,Content)VALUES(@Title,@Summary,@Content)", cn);
            cm.Parameters.Add("@Title", SqlDbType.NVarChar);
            cm.Parameters["@Title"].Value = txbNewTitle.Text;
            cm.Parameters.Add("@Summary", SqlDbType.NVarChar);
            cm.Parameters["@Summary"].Value = txbNewSummary.Text;
            cm.Parameters.Add("@Content", SqlDbType.NVarChar);
            cm.Parameters["@Content"].Value = txbNewContent.Text;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("News.aspx");
        }

        protected void Return_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("News.aspx");
        }
    }
}