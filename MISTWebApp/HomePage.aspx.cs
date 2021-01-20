using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISTWebApp
{
    public partial class HomePage : System.Web.UI.Page
    {
        private SqlConnection Connection;
        private SqlCommand Command;
        private int SellerAdCount;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            MaxAd.Visible = false;
            string constr = ConfigurationManager.ConnectionStrings["MISTDBEntities"].ToString();
            Connection = new SqlConnection(constr);
            SellerAdCount = GetSellerAdv();
            Session["ImageFileUpload"] = null;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(SellerAdCount>=3)
            {
                MaxAd.Visible = true;
                MaxAd.Text = "Can't Add More Advertisements you reached the max ";
               
            }
            else
            {
                Session["ViewAdsList"] = "0";
                Response.Redirect("NewAdv.aspx");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["ViewAdsList"] = "1";
            Response.Redirect("NewAdv.aspx");
        }
        private int GetSellerAdv()
        {
            int Countresult=0;
            Connection.Open();
            Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "select count (*) from Adv where SellerID = @SellerID ";
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add("@SellerID", SqlDbType.VarChar).Value = int.Parse(Session["Logined_ID"].ToString());
            SqlDataReader r = Command.ExecuteReader();
            while (r.Read())
            {
                 Countresult = int.Parse(r[0].ToString());

            }

            Connection.Close();
            return Countresult;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["ViewAdsList"] = null; 
            Session["Logined_ID"] = null;
            Session["Logined_Username"] =null;
            Response.Redirect("LoginForm.aspx");
            
        }
    }
}