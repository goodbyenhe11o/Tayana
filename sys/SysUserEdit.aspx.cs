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

namespace TayanaSystem.sys
{
    public partial class SysUserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.QueryString["id"] != null)
                {
                    lbPwdOld.Visible = false;
                    tbPwdOld.Visible = false;

                    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                    SqlConnection cn = new SqlConnection(config);
                    SqlCommand cm = new SqlCommand($"select * from [User] where id = {Request.QueryString["id"]}", cn);
                    cn.Open();
                    SqlDataReader rd = cm.ExecuteReader();
                    if (rd.Read())
                    {

                        tbName.Text = rd["UserName"].ToString();
                        tbAccount.Text = rd["Account"].ToString();
                        rdblUserManage.SelectedValue = rd["Manage_Id"].ToString();
                        hidden_authority.Value = rd["MenuAuthority"].ToString();
                    }
                    
                    cn.Close();

                    btnSubmit.Text = "更新用戶資料";
                }


            }
        }


        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string password = tbPwdOld.Text;
            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            string getconfig = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(getconfig);
            
            //如果無id就為新增頁面
            if (Request.QueryString["id"] == null)
            {

                SqlCommand cm = new SqlCommand($"INSERT INTO [User] (UserName,Account,Password,Manage_Id,MenuAuthority) VALUES(@UserName,@Account,@Password,@Manage_Id,@MenuAuthority)", cn);
                cm.Parameters.Add("@UserName", SqlDbType.NVarChar);
                cm.Parameters["@UserName"].Value = tbName.Text;
                cm.Parameters.Add("@Account", SqlDbType.NVarChar);
                cm.Parameters["@Account"].Value = tbAccount.Text;
                cm.Parameters.Add("@Password", SqlDbType.NVarChar);
                cm.Parameters["@Password"].Value = password;
                cm.Parameters.Add("@Manage_Id", SqlDbType.Int);
                cm.Parameters["@Manage_Id"].Value = rdblUserManage.SelectedValue;
                cm.Parameters.Add("@MenuAuthority", SqlDbType.NVarChar);
                cm.Parameters["@MenuAuthority"].Value = hidden_authority.Value;

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("SysUserManage.aspx");

            }

            //如果有id就是更新
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];
                
                SqlCommand cm = new SqlCommand($"Update [User] set UserName = @UserName,Account=@Account,Manage_Id = @Manage_Id,MenuAuthority = @MenuAuthority where (id ={id})", cn);
                cm.Parameters.Add("@UserName", SqlDbType.NVarChar);
                cm.Parameters["@UserName"].Value = tbName.Text;
                cm.Parameters.Add("@Account", SqlDbType.NVarChar);
                cm.Parameters["@Account"].Value = tbAccount.Text;
                //cm.Parameters.Add("@Password", SqlDbType.NVarChar);
                //cm.Parameters["@Password"].Value = password;
                cm.Parameters.Add("@Manage_Id", SqlDbType.Int);
                cm.Parameters["@Manage_Id"].Value = rdblUserManage.SelectedValue;
                cm.Parameters.Add("@MenuAuthority", SqlDbType.NVarChar);
                cm.Parameters["@MenuAuthority"].Value = hidden_authority.Value;
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("SysUserManage.aspx");


            }

        }
        protected void btnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysUserManage.aspx");
        }



    }
}