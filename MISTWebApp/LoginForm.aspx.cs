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
    public partial class LoginForm1 : System.Web.UI.Page
    {
        private SqlConnection Connection;
        private SqlCommand Command;
        private int LoginedID;
        private string LoginedUsername; 
        private string LoginedPassword;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Visible = false;
            string constr = ConfigurationManager.ConnectionStrings["MISTDBEntities"].ToString();
            Connection = new SqlConnection(constr);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var Username = Request["UsernameTxt"];
            var Password = Request["Passwordtxt"];
            Connection.Open();
            Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "Select * from Users where Username= @Username ";
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
            SqlDataReader r = Command.ExecuteReader();
            while (r.Read())
            {
                LoginedID = int.Parse( r[0].ToString());
                LoginedUsername = r[1].ToString();
                LoginedPassword = r[2].ToString();

            }
            Connection.Close();

            if(LoginedUsername==Username && LoginedPassword == Password )
            {
                Session["Logined_ID"] = LoginedID;
                Session["Logined_Username"] = LoginedUsername;
                Label5.Visible = true;
                Label5.Text = "Welcome Back";
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "Invalid Login Username or Password not correct";
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationForm.aspx");
        }
    }
}