using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISTWebApp
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private SqlConnection Connection;
        private SqlCommand Command;

        private List<string> Users = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Visible = false;
            string constr = ConfigurationManager.ConnectionStrings["MISTDBEntities"].ToString();
            Connection = new SqlConnection(constr);

            Connection.Open();
            Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "Select Username from Users ";
            Command.CommandType = CommandType.Text;
            SqlDataReader r = Command.ExecuteReader();
            while (r.Read())
            {
                Users.Add(r[0].ToString());

            }
            Connection.Close();

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
           
            var Username = Request["UsernameTxt"]; 
            var Password = Request["PasswordTxt"];   

            if (!Users.Contains(Username))
            {

                string insertSQL = ("INSERT INTO Users (" + " UserName, Password " + ") VALUES" +
                    " (" + "  @UserName, @Password" + ")");

                Command = new SqlCommand(insertSQL, Connection);

                Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Username;
                Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();

                ////////////////////////////////

                Connection.Open();
                Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "Select ID from Users where Username= @Username ";
                Command.CommandType = CommandType.Text;
                Command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                SqlDataReader r = Command.ExecuteReader();
                while (r.Read())
                {
                    Session["Logined_ID"] = int.Parse(r[0].ToString());
                    Session["Logined_Username"] = Username;
                }

                Connection.Close();
                Label5.Visible = true;
                Label5.Text = "Done";
                Response.Redirect("HomePage.aspx");

            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "This User is Already Exists";
            }
           
        }
    }
}