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
    public partial class YachtLayout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                //如果有點選Menu船!!!!!!!!!!!
                if (Request.QueryString["id"] != null)
                {

                    string id = Request.QueryString["id"];
                    SqlCommand cmContent = new SqlCommand($"Select * from LayoutPic where Yacht_Id = {id}", cn);
                    cn.Open();
                    SqlDataReader rdContent = cmContent.ExecuteReader();
                    rpContent.DataSource = rdContent;
                    rpContent.DataBind();
                    cn.Close();

                    //小標題
                    SqlCommand cmTitle = new SqlCommand($"select id,YachtName from Yachts where id = {id}", cn);
                    cn.Open();
                    SqlDataReader rdTitle = cmTitle.ExecuteReader();
                    if (rdTitle.Read())
                    {
                        lbYachtName.Text = rdTitle["YachtName"].ToString();
                        lrYachtLink.Text = rdTitle["YachtName"].ToString();

                    }

                    cn.Close();

                    //點Menu就有對應的船輪播
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
                    //預設Layout內容!!!!!!!!!!!!!!!
                    SqlCommand cmContent = new SqlCommand($"Select top 1 * from LayoutPic order by Yacht_Id desc", cn);
                    cn.Open();
                    SqlDataReader rdContent = cmContent.ExecuteReader();
                    rpContent.DataSource = rdContent;
                    rpContent.DataBind();
                    cn.Close();

              

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

                    //預設標題跟小標!!!!!!!!!!!!!
                    SqlCommand cmTitle11 = new SqlCommand($"select top 1 id,YachtName from Yachts order by id desc", cn);
                    cn.Open();
                    SqlDataReader rdTitle11 = cmTitle11.ExecuteReader();
                    if (rdTitle11.Read())
                    {
                        lbYachtName.Text = rdTitle11["YachtName"].ToString();
                        lrYachtLink.Text = rdTitle11["YachtName"].ToString();
                    }
                    cn.Close();


                    aOverview.HRef = $"YachtOverview.aspx?id=1";
                    aLayout.HRef = $"YachtLayout.aspx?id=1";
                    aSpecification.HRef = $"YachtSpecification.aspx?id=1";


                }



            }

        }
    }
}