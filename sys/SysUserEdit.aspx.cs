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
    public partial class SysUserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            string getconfig = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(getconfig);
            SqlCommand cm = new SqlCommand($"INSERT INTO [User] (UserName,Account,Password,Manage_Id,MenuAuthority) VALUES(@UserName,@Account,@Password,@Manage_Id,@MenuAuthority)", cn);

            cm.Parameters.Add("@UserName", SqlDbType.NVarChar);
            cm.Parameters["@UserName"].Value = tbName.Text;
            cm.Parameters.Add("@Account", SqlDbType.NVarChar);
            cm.Parameters["@Account"].Value = tbAccount.Text;
            cm.Parameters.Add("@Password", SqlDbType.NVarChar);
            cm.Parameters["@Password"].Value = tbPassword.Text;
            cm.Parameters.Add("@Manage_Id", SqlDbType.Int);
            cm.Parameters["@Manage_Id"].Value = rdblUserManage.SelectedValue;
            cm.Parameters.Add("@MenuAuthority", SqlDbType.NVarChar);
            cm.Parameters["@MenuAuthority"].Value = hidden_authority.Value;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("SysUserManage.aspx");



        }
        protected void btnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysUserManage.aspx");
        }



    }
}