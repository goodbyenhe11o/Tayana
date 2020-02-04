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
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            //SqlConnection cn = new SqlConnection(config);
            //SqlCommand cm = new SqlCommand($"select * from Dealers where Area_Id = @id ", cn);
            //cm.Parameters.Add("@id", SqlDbType.NVarChar);
            //cm.Parameters["@id"].Value = Request.QueryString["id"];
            //cn.Open();
            //SqlDataReader rd = cm.ExecuteReader();
            //rp.DataSource = rd;
            //rp.DataBind();
            //cn.Close();

        }
        public static string Symbol(string result)
        {

            result = result.Replace("\r\n", "<br>");


            return result;

        }
    }
}