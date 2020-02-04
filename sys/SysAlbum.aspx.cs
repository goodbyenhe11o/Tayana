using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class SysAlbum : System.Web.UI.Page
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
                    SqlCommand cm = new SqlCommand($"select * from Album where Yacht_Id = {id}",
                        cn);
                    cn.Open();
                    SqlDataReader rd = cm.ExecuteReader();
                    rpPic.DataSource = rd;
                    rpPic.DataBind();
                    cn.Close();
                    
                    //抓遊艇名字
                    SqlCommand cmYachtName = new SqlCommand($"Select id,YachtName from Yachts where id = {id}", cn);
                    cn.Open();
                    SqlDataReader rdName = cmYachtName.ExecuteReader();
                    if (rdName.Read())
                    {
                        lbYachtName.Text = rdName["YachtName"].ToString();
                    }
                    cn.Close();

                }


            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            if (fuLayout01.HasFile)
            {
                foreach (var postedFile in fuLayout01.PostedFiles)
                {
                    if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/png")
                    {

                        string savepath = @"/uploads/";
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string extension = System.IO.Path.GetExtension(fileName);
                        string GetDate = DateTime.Now.ToString("yyMMddhhmmss");
                        fileName = GetDate + fileName;
                        string pathtocheck = savepath + fileName;
                        postedFile.SaveAs(Server.MapPath(pathtocheck));


                        SqlCommand cm =
                            new SqlCommand($"INSERT INTO Album (Yacht_Id,Picture)VALUES(@Yacht_Id,@Picture)", cn);
                        cm.Parameters.Add("@Yacht_Id", SqlDbType.NVarChar);
                        cm.Parameters["@Yacht_Id"].Value = id;
                        cm.Parameters.Add("@Picture", SqlDbType.NVarChar);
                        cm.Parameters["@Picture"].Value = pathtocheck;

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();

                    }
                    else
                    {
                        lbPictureResult.Text = "請上傳正確圖片格式";
                        lbPictureResult.ForeColor = Color.Crimson;
                    }


                }

                Response.Redirect($"SysAlbum.aspx?id={Request.QueryString["id"]}");
            }
            else
            {
                lbPictureResult.Text = "請記得上傳檔案";
                lbPictureResult.ForeColor = Color.Crimson;

            }
        }

        protected void btnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysYacht.aspx");
        }

        protected void rpPic_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("delCmd"))
            {

                foreach (RepeaterItem item in rpPic.Items)
                {
                    if (((CheckBox) item.FindControl("cb")).Checked)
                    {
                        int num = Int32.Parse(((HiddenField) item.FindControl("HiddenField1")).Value);
                        string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"]
                            .ConnectionString;
                        SqlConnection cn = new SqlConnection(config);
                        SqlCommand cm = new SqlCommand($"delete from Album where id = {num}", cn);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                }

                Response.Redirect($"SysAlbum.aspx?id={Request.QueryString["id"]}");
            }
        }
    }
}