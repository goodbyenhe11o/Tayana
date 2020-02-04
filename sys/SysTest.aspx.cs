using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class SysTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"Select id,YachtName from Yachts where YachtName is not null", cn);
                cn.Open();
                SqlDataReader rd = cm.ExecuteReader();
                ddlYachtName.DataSource = rd;
                ddlYachtName.DataTextField = "YachtName";
                ddlYachtName.DataValueField = "id";
                ddlYachtName.DataBind();
                
                cn.Close();


                //以下為在BINDING後加入第一筆資料
                ListItem li00 = new ListItem();
                li00.Text = "--------請選擇--------";
                li00.Value = "0";
                ddlYachtName.Items.Insert(0,li00);
                ddlYachtName.SelectedIndex = 0;

            }

        }
    }
}