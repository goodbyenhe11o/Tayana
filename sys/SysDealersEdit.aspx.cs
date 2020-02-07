using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaSystem.sys
{
    public partial class SysDealersEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }





        protected void Submit_OnClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string savepath = @"/uploads/";
                string FileName = FileUpload1.FileName;
                string extension = System.IO.Path.GetExtension(FileName);
                if(FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/png")
                {


                    string GetDate = DateTime.Now.ToString("yyMMddhhmmss");
                    FileName = GetDate + FileName;
                    string pathtocheck = savepath + FileName;
                    FileUpload1.SaveAs(MapPath(pathtocheck));


                    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                    SqlConnection cn = new SqlConnection(config);
                    SqlCommand cm = new SqlCommand($"insert into Dealers (Area_Id,Picture,Title,Content) values ({ddlArea.Text},@Picture,@Title,@Content)", cn);
                    cm.Parameters.Add("@Picture", SqlDbType.NVarChar);
                    cm.Parameters["@Picture"].Value = pathtocheck;
                    cm.Parameters.Add("@Title", SqlDbType.NVarChar);
                    cm.Parameters["@Title"].Value = txbNewTitle.Text;
                    cm.Parameters.Add("@Content", SqlDbType.NVarChar);
                    cm.Parameters["@Content"].Value = txbNewContent.Text;
             

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();

                    Response.Redirect("SysDealers.aspx");
                }

                else
                {
                    lbPictureResult.Text = "請上傳正確圖片格式";
                    lbPictureResult.ForeColor = Color.Crimson;
                }


            }
            else
            {
                lbPictureResult.Text = "請記得上傳檔案";
                lbPictureResult.ForeColor = Color.Crimson;

            }

        }


        protected void Returm_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysDealers.aspx");
        }
    }
}