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
    public partial class SysYachtFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                    SqlConnection cn = new SqlConnection(config);
                    SqlCommand cm = new SqlCommand($"select * from  Download where Yacht_Id = {Request.QueryString["id"]}", cn);
                    cn.Open();
                    SqlDataReader rd = cm.ExecuteReader();
                    rpLayout.DataSource = rd;
                    rpLayout.DataBind();
                    cn.Close();
                }


            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            if (fuFile.HasFile)
            {
                foreach (var postedFile in fuFile.PostedFiles)
                {
                    
                    //if (postedFile.ContentType == "image/jpeg" )

                        string savepath = @"/uploads/";
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string GetDate = DateTime.Now.ToString("yyMMddhhmmss");
                        fileName = GetDate + fileName;
                        string pathtocheck = savepath + fileName;
                        postedFile.SaveAs(Server.MapPath(pathtocheck));


                        SqlCommand cm =
                            new SqlCommand($"INSERT INTO Download (Yacht_Id,FileName,FileRoot)VALUES(@Yacht_Id,@FileName,@FileRoot)", cn);
                        cm.Parameters.Add("@Yacht_Id", SqlDbType.Int);
                        cm.Parameters["@Yacht_Id"].Value = id;
                        cm.Parameters.Add("@FileName", SqlDbType.NVarChar);
                        cm.Parameters["@FileName"].Value = fileName;
                        cm.Parameters.Add("@FileRoot", SqlDbType.NVarChar);
                        cm.Parameters["@FileRoot"].Value = pathtocheck;
                        
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();

                 

                }

                Response.Redirect($"SysYachtFile.aspx?id={id}");
            }
            else
            {
                lbUploadResult.Text = "請記得上傳檔案";
                lbUploadResult.ForeColor = Color.Crimson;
            }

        }

        protected void btnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SysYacht.aspx");
        }

        protected void rpLayout_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("delCmd"))
            {

                foreach (RepeaterItem item in rpLayout.Items)
                {
                    if (((CheckBox)item.FindControl("cb")).Checked)
                    {
                        int num = Int32.Parse(((HiddenField)item.FindControl("HiddenField1")).Value);
                        string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                        SqlConnection cn = new SqlConnection(config);
                        SqlCommand cm = new SqlCommand($"delete from LayoutPic where id = {num}", cn);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                Response.Redirect($"SysYachtFile.aspx?id={Request.QueryString["id"]}");
            }
        }
    }
}