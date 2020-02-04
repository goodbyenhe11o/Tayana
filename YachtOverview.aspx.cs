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
    public partial class YachtOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //MENU
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cmMenu = new SqlCommand($"Select id,YachtName,CASE NewBuilding WHEN 1 THEN '(New Building)' ELSE ' '  END as N'NewBuilding' from Yachts where YachtName is not null", cn);
            cn.Open();
            SqlDataReader rd = cmMenu.ExecuteReader();
            rpMenu.DataSource = rd;
            rpMenu.DataBind();
            cn.Close();



            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];
                //抓id顯示overview
                SqlCommand cm = new SqlCommand($"select id,YachtName,OverviewContent,OverviewDimensions from Yachts where id = {Request.QueryString["id"]}", cn);
                cn.Open();
                SqlDataReader rdContent = cm.ExecuteReader();
                if (rdContent.Read())
                {
                    lbYachtName.Text = rdContent["YachtName"].ToString();
                    lrOverviewContent.Text = rdContent["OverviewContent"].ToString();
                    lrOverviewDimensions.Text = ImgMax(rdContent["OverviewDimensions"].ToString());
                    lrYachtLink.Text = rdContent["YachtName"].ToString();
                }
                cn.Close();
                //YachtLink.HRef = $"YachtOverview.aspx?id={Request.QueryString["id"]}";
                //YachtLink.HRef = "#";

                // 點Menu就有對應的船輪播
                SqlCommand cmrpPicTop = new SqlCommand($"Select  * from Album where Yacht_Id = {id}", cn);
                cn.Open();
                SqlDataReader rdPicTop = cmrpPicTop.ExecuteReader();
                rpPicTop.DataSource = rdPicTop;
                rpPicTop.DataBind();

                cn.Close();

                cn.Open();
                SqlDataReader rdPicBottom = cmrpPicTop.ExecuteReader();
                rpPicBottom.DataSource = rdPicBottom;
                rpPicBottom.DataBind();
                cn.Close();



                aOverview.HRef = $"YachtOverview.aspx?id={id}";
                aLayout.HRef = $"YachtLayout.aspx?id={id}";
                aSpecification.HRef = $"YachtSpecification.aspx?id={id}";
            }

            else
            {
            //無id就預設內容
            SqlCommand cmYacht01 = new SqlCommand($"Select top 1 * from Yachts order by id desc", cn);
            cn.Open();
            SqlDataReader rdContent01 = cmYacht01.ExecuteReader();
                if (rdContent01.Read())
                {
                    lbYachtName.Text = rdContent01["YachtName"].ToString();
                    lrOverviewContent.Text = rdContent01["OverviewContent"].ToString();
                    lrOverviewDimensions.Text = ImgMax(rdContent01["OverviewDimensions"].ToString());
                    lrYachtLink.Text = rdContent01["YachtName"].ToString();
                }
                cn.Close();
                //YachtLink.HRef = $"YachtOverview.aspx?id=1";


                //預設船輪播!!!!!!!!!!!!!
                SqlCommand cmrpPicTop = new SqlCommand($"Select top 1  with ties * from Album order by Yacht_Id desc ", cn);
                cn.Open();
                SqlDataReader rdPicTop = cmrpPicTop.ExecuteReader();
                rpPicTop.DataSource = rdPicTop;
                rpPicTop.DataBind();

                cn.Close();

                cn.Open();
                SqlDataReader rdPicBottom = cmrpPicTop.ExecuteReader();
                rpPicBottom.DataSource = rdPicBottom;
                rpPicBottom.DataBind();
                cn.Close();


                aOverview.HRef = "YachtOverview.aspx?id=1";
                aLayout.HRef = "YachtLayout.aspx?id=1";
                aSpecification.HRef = "YachtSpecification.aspx?id=1";
            }





        }

            public static string ImgMax(string result)
            {
                result = result.Replace("width", "max-width");
                result = result.Replace("height", "max-height");
                return result;
            }


    }
}