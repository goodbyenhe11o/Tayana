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
    public partial class SysUserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Session["id"].ToString();
                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"Select UserName,Account,MenuAuthority from [User] where id = {id}",cn);
                cn.Open();
                SqlDataReader rd = cm.ExecuteReader();
                if (rd.Read())
                {
                    lbName.Text = rd["UserName"].ToString();
                    lbAccount.Text = rd["Account"].ToString();
                    lbAuthority.Text = rd["MenuAuthority"].ToString();
                }
                cn.Close();
                lbAuthority.Text = Authority(lbAuthority.Text);
            }

        }

        protected void btnReturn_OnClick(object sender, EventArgs e)
        {

            Response.Redirect("SysHome.aspx");

        }
        public static string Authority(string result)
        {
            result = result.Replace("01", "遊艇管理");
            result = result.Replace("02", "新聞管理");
            result = result.Replace("03", "代理商管理");

            return result;

        }

    }
}