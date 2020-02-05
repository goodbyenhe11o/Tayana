using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Manage_Id"].ToString().Contains("1"))
            {
                lrUserManage.Text = "<li><a href='SysUserManage.aspx'>系統權限設定</a></li>";

            }
            
                            
                            
            StringBuilder sbMenu = new StringBuilder();
            string AuthorityNumber = Session["MenuAuthority"].ToString();
            if (AuthorityNumber.Contains("01"))
            {
                sbMenu.Append("<li><a href='SysYacht.aspx'>遊艇管理</a></li>");
            }
            if (AuthorityNumber.Contains("02"))
            {
                sbMenu.Append("<li><a href='SysNews.aspx'>新聞管理</a></li>");
            }
            if (AuthorityNumber.Contains("03"))
            {
                sbMenu.Append("<li><a href='SysDealers.aspx'>代理商管理</a></li>");
            }

            lrMenu.Text = sbMenu.ToString();

        }
    }
}