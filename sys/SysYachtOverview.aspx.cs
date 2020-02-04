using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class SysYachtOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];

                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"]
                    .ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm =
                    new SqlCommand(
                        $"select id,YachtName,OverviewContent,OverviewDimensions, NewBuilding from Yachts where id = {id}",
                        cn);

                cn.Open();

                SqlDataReader rd = cm.ExecuteReader();
                if (rd.Read())
                {
                    tbYachtName.Text = rd["YachtName"].ToString();
                    tbOverviewContent.Text = rd["OverviewContent"].ToString();
                    tbOverviewDimensions.Text = rd["OverviewDimensions"].ToString();
                    rdblNewBuilding.SelectedValue = rd["NewBuilding"].ToString();
                }

                cn.Close();
                btnUploadOverview.Text = "更新內容";
            }
            }

        }

        protected void btnUploadOverview_OnClick(object sender, EventArgs e)
        {

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"]
                .ConnectionString;
            SqlConnection cn = new SqlConnection(config);

            if (Request.QueryString["id"] != null)
            {
                SqlCommand cm =
                    new SqlCommand(
                        $"Update Yachts set YachtName=@YachtName,OverviewContent=@OverviewContent,OverviewDimensions=@OverviewDimensions,NewBuilding=@NewBuilding where id = {Request.QueryString["id"]}",
                        cn);
                cm.Parameters.Add("@YachtName", SqlDbType.NVarChar);
                cm.Parameters["@YachtName"].Value = tbYachtName.Text;
                cm.Parameters.Add("@OverviewContent", SqlDbType.NVarChar);
                cm.Parameters["@OverviewContent"].Value = tbOverviewContent.Text;
                cm.Parameters.Add("@OverviewDimensions", SqlDbType.NVarChar);
                cm.Parameters["@OverviewDimensions"].Value = tbOverviewDimensions.Text;
                cm.Parameters.Add("@NewBuilding", SqlDbType.NVarChar);
                cm.Parameters["@NewBuilding"].Value = rdblNewBuilding.SelectedItem.Value;


                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("SysYacht.aspx");


            }

            if (Request.QueryString["id"] == null)
            {


                        SqlCommand cm =
                            new SqlCommand(
                                $"insert into Yachts (YachtName,OverviewContent,OverviewDimensions,NewBuilding) values (@YachtName,@OverviewContent,@OverviewDimensions,@NewBuilding)",
                                cn);
                        cm.Parameters.Add("@YachtName", SqlDbType.NVarChar);
                        cm.Parameters["@YachtName"].Value = tbYachtName.Text;
                        cm.Parameters.Add("@OverviewContent", SqlDbType.NVarChar);
                        cm.Parameters["@OverviewContent"].Value = tbOverviewContent.Text;
                        cm.Parameters.Add("@OverviewDimensions", SqlDbType.NVarChar);
                        cm.Parameters["@OverviewDimensions"].Value = tbOverviewDimensions.Text;
                        cm.Parameters.Add("@NewBuilding", SqlDbType.NVarChar);
                        cm.Parameters["@NewBuilding"].Value = rdblNewBuilding.SelectedItem.Value;


                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        Response.Redirect("SysYacht.aspx");

            }



        }

        protected void btnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysYacht.aspx");

        }
    }
}