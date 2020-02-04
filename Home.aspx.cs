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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"Select top 3 id,Title,MainPicture,initdate from News ORDER BY initdate desc ", cn);
            cn.Open();
            SqlDataReader rd = cm.ExecuteReader();
            rpNews.DataSource = rd;
            rpNews.DataBind();
            cn.Close();

            string sqlPic = "select *, case when RN = 1 then  'info on' else 'info' end as Show_On\n"
                            + "from(select a.id, Yacht_Id, Picture,Yachts.NewBuilding, Yachts.YachtName,"
                            + "ROW_NUMBER() Over(order by Yacht_Id desc) as RN from\n"
                            + "(Select id, Yacht_Id, Picture,\n"
                            + "ROW_NUMBER() Over(Partition By Yacht_Id Order By id) As Sort From Album) a\n"
                            + "inner join Yachts on Yachts.id = a.Yacht_Id\n"
                            + "where a.Sort = 1) T1";

            SqlCommand cmPicTop = new SqlCommand(sqlPic, cn);
            cn.Open();
            SqlDataReader rdPicTop = cmPicTop.ExecuteReader();
            rpPicTop.DataSource = rdPicTop;
            rpPicTop.DataBind();
            cn.Close();


            SqlCommand cmPicBottom = new SqlCommand(sqlPic, cn);
            cn.Open();
            SqlDataReader rdPicBottom = cmPicBottom.ExecuteReader();
            rpPicBottom.DataSource = rdPicBottom;
            rpPicBottom.DataBind();
            cn.Close();



            }
        }
    }
}