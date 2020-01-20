using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    }
                    cn.Close();


                }
            }
        }


        protected void Submit_OnClick(object sender, EventArgs e)
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            
            //抓不到id就寫入新聞
            if (Request.QueryString["id"] == null)
            {
                
                SqlCommand cm =
                    new SqlCommand($"INSERT INTO News (Title,Summary,Content)VALUES(@Title,@Summary,@Content)", cn);
                cm.Parameters.Add("@Title", SqlDbType.NVarChar);
                cm.Parameters["@Title"].Value = txbNewTitle.Text;
                cm.Parameters.Add("@Summary", SqlDbType.NVarChar);
                cm.Parameters["@Summary"].Value = txbNewSummary.Text;
                cm.Parameters.Add("@Content", SqlDbType.NVarChar);
                cm.Parameters["@Content"].Value = txbNewContent.Text;

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("SysNews.aspx");
            }
            //抓的到id就編輯新聞
            else
            {
                SqlCommand cmUpdate = new SqlCommand($"Update News set Title = @Title,Summary = @Summary,Content=@Content where (id ={Request.QueryString["id"]})",cn);
                cmUpdate.Parameters.Add("@Title", SqlDbType.NVarChar);
                cmUpdate.Parameters["@Title"].Value = txbNewTitle.Text;
                cmUpdate.Parameters.Add("@Summary", SqlDbType.NVarChar);
                cmUpdate.Parameters["@Summary"].Value = txbNewSummary.Text;
                cmUpdate.Parameters.Add("@Content", SqlDbType.NVarChar);
                cmUpdate.Parameters["@Content"].Value = txbNewContent.Text;
                cn.Open();
                cmUpdate.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("SysNews.aspx");


            }



        }

        protected void Return_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("News.aspx");
        }
    }
}