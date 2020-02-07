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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {

            string getconfig = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(getconfig);
            string password = tbPassword.Text;
            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            //建立對sql的指令
            SqlCommand cm =
                new SqlCommand(
                    $"SELECT  * FROM [User] WHERE (Password = @Password and Account = @Account)",cn);

            cm.Parameters.Add("@Account", SqlDbType.NVarChar);
            cm.Parameters["@Account"].Value = tbAccount.Text;
            cm.Parameters.Add("@Password", SqlDbType.NVarChar);
            cm.Parameters["@Password"].Value = password;


            cn.Open();

            SqlDataReader reader = cm.ExecuteReader();
            if (reader.HasRows)
            {
                //cm.Cancel();
                //reader.Close();
                if (reader.Read())
                {
                    //Session["Login"] = "OK";
                    //Session["id"] = reader["id"].ToString();
                    //Session["Manage_Id"] = reader["Manage_Id"].ToString();
                    //Session["UserName"] = reader["UserName"].ToString();
                    //Session["MenuAuthority"] = reader["MenuAuthority"].ToString();

                    string UserData = reader["id"].ToString()
                                      +";" + reader["Manage_Id"].ToString()
                                      +";" + reader["MenuAuthority"].ToString();

                    SetAuthenTicket(UserData, reader["UserName"].ToString());

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
        //驗證函數
        //要去web.config新增的system.web裡面加入mode="Forms"
        void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);

        }
    }
}