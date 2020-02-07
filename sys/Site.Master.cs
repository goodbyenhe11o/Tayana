using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //驗證身份
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("Login.aspx");
            }
            //string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            //if (strUserData.Length < 20)
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            string UserName = ((FormsIdentity) (HttpContext.Current.User.Identity)).Ticket.Name;
            lbWelcome.Text = "Welcome " + UserName;
            string[] UserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData.Split(';');
            //string id = UserData[1];

            if (UserData[1].Contains("1"))
            {
                lrUserManage.Text = "<li><a href='SysUserManage.aspx'>系統權限設定</a></li>";

            }
            else
            {
                lrUserManage.Text = null;
            }



            StringBuilder sbMenu = new StringBuilder();
            string AuthorityNumber = UserData[2];
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