using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {

            string getconfig = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(getconfig);

            //建立對sql的指令
            SqlCommand cm =
                new SqlCommand(
                    $"SELECT  * FROM [User] WHERE (Password = @Password and Account = @Account)",cn);

            cm.Parameters.Add("@Account", SqlDbType.NVarChar);
            cm.Parameters["@Account"].Value = tbAccount.Text;
            cm.Parameters.Add("@Password", SqlDbType.NVarChar);
            cm.Parameters["@Password"].Value = tbPassword.Text;


            cn.Open();

            SqlDataReader reader = cm.ExecuteReader();
            if (reader.HasRows)
            {
                //cm.Cancel();
                //reader.Close();
                if (reader.Read())
                {
                    Session["Login"] = "OK";
                    Session["id"] = reader["id"].ToString();
                    Session["Manage_Id"] = reader["Manage_Id"].ToString();
                    Session["UserName"] = reader["UserName"].ToString();
                    Session["MenuAuthority"] = reader["MenuAuthority"].ToString();
                }

                cn.Close();
                Response.Redirect("SysHome.aspx");

            }

            else
            {
                //cm.Cancel();
                //reader.Close();
                lbWarn.Text = "帳號或密碼錯誤";
                cn.Close();
                //return;
            }




        }
    }
}