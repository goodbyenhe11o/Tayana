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
    public partial class SysYacht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"select id,YachtName,case when NewBuilding=1 then '(New Building)' else ' ' end as N'NewBuilding',initdate from Yachts", cn);
            cn.Open();
            SqlDataReader rd = cm.ExecuteReader();
            gvYacht.DataSource = rd;
            gvYacht.DataBind();
            cn.Close();
            }
        }

        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysYachtOverview.aspx");
        }

        protected void gvYacht_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "btnDel")
            {
                Button btnDel = (Button)e.CommandSource;
                GridViewRow myRow = (GridViewRow)btnDel.NamingContainer;
                //Label lbDel = (Label)GridView1.Rows[myRow.DataItemIndex]
                int num = Int32.Parse(((HiddenField)myRow.FindControl("HiddenFieldDel")).Value);


                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"delete from Yachts where id = {num}", cn);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }

            Response.Redirect("SysYacht.aspx");

        }
    }
}