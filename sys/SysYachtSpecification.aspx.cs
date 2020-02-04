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
    public partial class SysYachtSpecification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                //如果抓的到id就顯示
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];
                    SqlCommand cmEdit = new SqlCommand($"Select Specification from Yachts where id = {id}", cn);
                    cn.Open();
                    SqlDataReader rd = cmEdit.ExecuteReader();
                    if (rd.Read())
                    {
                        tbSpecification.Text = rd["Specification"].ToString();
                    }

                    cn.Close();

                }

            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand c = new SqlCommand($"insert into Yachts (Specification) values (@Specification)", cn);
            
            SqlCommand cmUpdate =
                new SqlCommand(
                    $"Update Yachts set Specification = @Specification where (id ={Request.QueryString["id"]})",
                    cn);
            cmUpdate.Parameters.Add("@Specification", SqlDbType.NVarChar);
            cmUpdate.Parameters["@Specification"].Value = tbSpecification.Text;

            cn.Open();
            cmUpdate.ExecuteNonQuery();
            cn.Close();

            Response.Redirect("SysYacht.aspx");

        }

        protected void btnReturn_OnClick(object sender, EventArgs e)
            {
                Response.Redirect("SysYacht.aspx");
            }

        

    }
}