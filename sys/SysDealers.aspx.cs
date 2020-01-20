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
    public partial class SysDealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            if (Request.QueryString["id"] != null)
            {
                string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                SqlConnection cn = new SqlConnection(config);
                SqlCommand cm = new SqlCommand($"select * from Dealers where Area_Id = @id ", cn);
                cm.Parameters.Add("@id", SqlDbType.NVarChar);
                cm.Parameters["@id"].Value = Request.QueryString["id"];
                cn.Open();
                SqlDataReader rd = cm.ExecuteReader();
                rp.DataSource = rd;
                rp.DataBind();
                cn.Close();

                }

            }
        }
        protected void rp_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName.Equals("delCmd"))
            {
         
                foreach (RepeaterItem item in rp.Items)
                {
                    if (((CheckBox)item.FindControl("cb")).Checked)
                    {
                        int num = Int32.Parse(((HiddenField) item.FindControl("HiddenField1")).Value); 
                        string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
                        SqlConnection cn = new SqlConnection(config);
                        SqlCommand cm = new SqlCommand($"delete from Dealers where id = {num}", cn);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                        Response.Redirect($"SysDealers.aspx?id={Request.QueryString["id"]}");
            }
        }





        protected void btnNewDealer_OnClick(object sender, EventArgs e)
        {
            //Response.Redirect("~/test.aspx?id=1");
            Response.Redirect("SysDealersEdit.aspx");
        }

        public static string Symbol(string result)
        {
            result = result.Replace("\r\n", "<br>");
            return result;
        }



        //protected void btnDelete_OnClick(object sender, EventArgs e)
        //{
        //}

        //protected void rp_OnItemCommand(object source, RepeaterCommandEventArgs e)
        //{
            //    Label lb = (Label)rp.FindControl("Label3");
            //    lb.Text = "the button had been clicked";
        
        //}



    }
}