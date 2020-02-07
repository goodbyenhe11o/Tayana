using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            //遊艇由後台寫入使用者，不用寫註冊頁
            string password = tbPassword.Text;
            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            string getconfig = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(getconfig);
            SqlCommand cm = new SqlCommand($"INSERT INTO [User] (UserName,Account,Password,Manage_Id) VALUES(@UserName,@Account,@Password,2)", cn);

            cm.Parameters.Add("@UserName", SqlDbType.NVarChar);
            cm.Parameters["@UserName"].Value = tbName.Text;
            cm.Parameters.Add("@Account", SqlDbType.NVarChar);
            cm.Parameters["@Account"].Value = tbAccount.Text;
            cm.Parameters.Add("@Password", SqlDbType.NVarChar);
            cm.Parameters["@Password"].Value = password;

            cn.Open();
            cm.ExecuteNonQuery();
                    //Session["Login"] = "OK";
                    //Session["id"] = rd["id"].ToString();
                    //Session["Manage_Id"] = 2;
                    //Session["UserName"] = rd["UserName"].ToString();
                    //Session["MenuAuthority"] = rd["MenuAuthority"].ToString();
                cn.Close();
                //Response.Redirect("SysHome.aspx");


        }
    }
}