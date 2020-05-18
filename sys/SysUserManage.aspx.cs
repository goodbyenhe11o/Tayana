using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{

    public partial class SysUserManage : System.Web.UI.Page
    {

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"select id,UserName,Account,MenuAuthority,initdate,case Manage_Id when 1 then '帳號管理員' else '一般使用者' end as Manage_Id from [User]", cn);
                cn.Open();
                SqlDataReader rd = cm.ExecuteReader();
                gvUser.DataSource = rd;
                gvUser.DataBind();
                cn.Close();
            }
        }

        protected void gvUser_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDel")
            {
                Button btnDel = (Button)e.CommandSource;
                GridViewRow myRow = (GridViewRow)btnDel.NamingContainer;
                //Label lbDel = (Label)GridView1.Rows[myRow.DataItemIndex]
                int num = Int32.Parse(((HiddenField)myRow.FindControl("HiddenFieldDel")).Value);

                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"delete from [User] where id = {num}", cn);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }

            Response.Redirect("SysUserManage.aspx");
        }

        protected void btnNewUser_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysUserEdit.aspx");
        }
    }
}