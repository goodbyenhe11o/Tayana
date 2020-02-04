﻿using System;
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
    public partial class NewNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);

                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];
                    SqlCommand cmEdit = new SqlCommand($"Select * from News where id = {id}", cn);
                    cn.Open();
                    SqlDataReader rd = cmEdit.ExecuteReader();
                    if (rd.Read())
                    {
                        txbNewTitle.Text = rd["Title"].ToString();
                        txbNewSummary.Text = rd["Summary"].ToString();
                        txbNewContent.Text = rd["Content"].ToString();
                        if (rd["Top"].ToString().Equals("1"))
                        {
                            rdblTop.SelectedValue="1";
                        }
                    }
                    cn.Close();
                    Submit.Text = "更新新聞";


                }
            }
        }


        protected void Submit_OnClick(object sender, EventArgs e)
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            if (FileUpload1.HasFile)
            {
                string savepath = @"/uploads/";
                string FileName = FileUpload1.FileName;
                string extension = System.IO.Path.GetExtension(FileName);
                //if (extension == ".jpg" || extension == ".png")
                if(FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string GetDate = DateTime.Now.ToString("yyMMddhhmmss");
                    FileName = GetDate + FileName;
                    string pathtocheck = savepath + FileName;
                    FileUpload1.SaveAs(MapPath(pathtocheck));

                    //抓不到id就寫入新聞
                    if (Request.QueryString["id"] == null)
                    {
                        
                            
                    SqlCommand cm =
                        new SqlCommand($"INSERT INTO News (Title,Summary,Content,MainPicture,[Top])VALUES(@Title,@Summary,@Content,@Picture,@Top)", cn);
                    cm.Parameters.Add("@Title", SqlDbType.NVarChar);
                    cm.Parameters["@Title"].Value = txbNewTitle.Text;
                    cm.Parameters.Add("@Summary", SqlDbType.NVarChar);
                    cm.Parameters["@Summary"].Value = txbNewSummary.Text;
                    cm.Parameters.Add("@Content", SqlDbType.NVarChar);
                    cm.Parameters["@Content"].Value = txbNewContent.Text;
                    cm.Parameters.Add("@Picture", SqlDbType.NVarChar);
                    cm.Parameters["@Picture"].Value = pathtocheck;
                    cm.Parameters.Add("@Top", SqlDbType.NVarChar);
                    cm.Parameters["@Top"].Value = rdblTop.SelectedItem.Value;

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    Response.Redirect("SysNews.aspx");

                    }
                    //抓的到id就編輯新聞
                    else
                    {
                        SqlCommand cmUpdate = new SqlCommand($"Update News set Title = @Title,Summary = @Summary,Content=@Content,MainPicture=@Picture ,[Top]=@Top where (id ={Request.QueryString["id"]})", cn);
                        cmUpdate.Parameters.Add("@Title", SqlDbType.NVarChar);
                        cmUpdate.Parameters["@Title"].Value = txbNewTitle.Text;
                        cmUpdate.Parameters.Add("@Summary", SqlDbType.NVarChar);
                        cmUpdate.Parameters["@Summary"].Value = txbNewSummary.Text;
                        cmUpdate.Parameters.Add("@Content", SqlDbType.NVarChar);
                        cmUpdate.Parameters["@Content"].Value = txbNewContent.Text;
                        cmUpdate.Parameters.Add("@Picture", SqlDbType.NVarChar);
                        cmUpdate.Parameters["@Picture"].Value = pathtocheck;
                        cmUpdate.Parameters.Add("@Top", SqlDbType.NVarChar);
                        cmUpdate.Parameters["@Top"].Value = rdblTop.SelectedItem.Value;
                        cn.Open();
                        cmUpdate.ExecuteNonQuery();
                        cn.Close();
                        Response.Redirect("SysNews.aspx");


                    }
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

        protected void Return_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("SysNews.aspx");
        }
    }
}