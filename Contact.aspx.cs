using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Reflection;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Configuration;

namespace TayanaSystem
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*for RequiredFieldValidator
             * 解決 RequiredFieldValidator 發生的錯誤訊息
             * WebForms UnobtrusiveValidationMode 需要 'jquery' 的 ScriptResourceMapping。
             * 請加入 ScriptResourceMapping 命名的 jquery (區分大小寫)。
             */
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                SetCountry();
                SetYacht();
            }


        }

        protected void btnSubmit_OnClick(object sender, ImageClickEventArgs e)
        {
            bool SendStatus = SendEmail(tbName.Text);
            if (SendStatus)
            {
                //如果發送都有值，就顯示成功
                Response.Write("<script>alert('發送成功')</script>");
                tbName.Text = "";
                tbPhone.Text = "";
                tbMail.Text = "";
                tbComment.Text = "";
            }
            else
            {
                //寄信失敗
                Response.Write("<script>alert('發送失敗')</script>");

            }


        }

        public bool SendEmail(string subject)
        {

            string MessageBody = "Name:" + tbName.Text + "<br>" +
                                 "Email:" + tbMail.Text + "<br>" +
                                 "Phone:" + tbPhone.Text + "<br>" +
                                 "Country:" + ddlCountry.Text + "<br>" +
                                 "船的型號:" + ddlYachtName.Text + "<br>" + 
                                 "意見內容:"+ tbComment.Text + "<br>";
            try
            {
                //寄件者及名稱，可隨便填
                MailAddress from = new MailAddress("wendy199288@gmail.com", "寄件人名稱測試");
                //收件者，可寫多人，用逗號隔開
                MailAddress to = new MailAddress("wendy199288@gmail.com");
                MailMessage message = new MailMessage(from, to);

                message.Subject = $"來自大洋遊艇{tbName.Text}的信";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = MessageBody;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true; //是否為html信件
                //msg.Attachments.Add(new Attachment(@"D:\test2.docx"));  //附件
                //msg.Priority = MailPriority.High;//郵件優先級 

                //設定smtp sever及port
                SmtpClient myMail = new SmtpClient("smtp.gmail.com", 587);
                myMail.Credentials = new System.Net.NetworkCredential("wendy199288@gmail.com", "*****"); //填入帳密
                myMail.EnableSsl = true; //ssl打開，寄信時加密(gmail預設開啟驗證)

                myMail.Send(message); //寄信
                myMail.Dispose(); //傳送結束訊息給smtp
                message.Dispose(); //釋放Mailmessage所使用的所有資源

                return true; //成功


            }
            catch (Exception ex)
            {
                return false;
            }


        }


        void SetCountry()
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"select * from DealersArea",cn);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt =new DataTable();
            da.Fill(dt);//將adapter存入datatable
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            cn.Close();
        }

        void SetYacht()
        {
            string config = WebConfigurationManager.ConnectionStrings["TayanaConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);
            SqlCommand cm = new SqlCommand($"select id,YachtName from Yachts where YachtName is not null", cn);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);//將adapter存入datatable
            ddlYachtName.DataSource = dt;
            ddlYachtName.DataBind();
            cn.Close();
        }



    }
}