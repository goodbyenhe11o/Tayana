using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"Select * from DealersArea",cn);
            cn.Open();
            SqlDataReader rd = cm.ExecuteReader();
            rpMenu.DataSource = rd;
            rpMenu.DataBind();
            cn.Close();
            //內容標題的地區
            SqlCommand cmAreaNameUSA = new SqlCommand($"Select * from DealersArea where id = 1", cn);
            cn.Open();
            SqlDataReader rdAreaNameUSA = cmAreaNameUSA.ExecuteReader();
            if (rdAreaNameUSA.Read())
            {
                lbDealerTitle.Text = rdAreaNameUSA["Area"].ToString();
                lrAreaName.Text = rdAreaNameUSA["Area"].ToString();
            }
            cn.Close();

            if (!IsPostBack)
            {
                SqlCommand cmUSA = new SqlCommand($"Select * from Dealers where Area_Id =1", cn);
                cn.Open();
                SqlDataReader rdUSA = cmUSA.ExecuteReader();
                rpContent.DataSource = rdUSA;
                rpContent.DataBind();
                cn.Close();

            }
            if (Request.QueryString["id"] != null)
            {

                SqlCommand cmContent = new SqlCommand($"Select * from Dealers where Area_id = {Request.QueryString["id"]}", cn);
                cn.Open();
                SqlDataReader rdContent = cmContent.ExecuteReader();
                rpContent.DataSource = rdContent;
                rpContent.DataBind();

                cn.Close();

                //內容標題的地區
                SqlCommand cmAreaName = new SqlCommand($"Select * from DealersArea where id = {Request.QueryString["id"]}", cn);
                cn.Open();
                SqlDataReader rdAreaName = cmAreaName.ExecuteReader();
                if (rdAreaName.Read())
                {
                    lbDealerTitle.Text = rdAreaName["Area"].ToString();
                    lrAreaName.Text = rdAreaName["Area"].ToString();
                }
                cn.Close();
            }
        }
        public static string Symbol(string result)
        {
            result = result.Replace("\r\n", "<br>");
            return result;
        }
    }
}