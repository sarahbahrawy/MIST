using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MISTWebApp
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");

            try
            {
                string id = context.Request.QueryString["Serial"].ToString();
                // string id = "1";
                string sConn = ConfigurationManager.ConnectionStrings["MISTDBEntities"].ToString();
                SqlConnection objConn = new SqlConnection(sConn);
                objConn.Open();
                string sTSQL = "select AdImage from Adv where Serial=@Serial";
                SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.AddWithValue("@Serial", id.ToString());
                object data = objCmd.ExecuteScalar();
                objConn.Close();
                objCmd.Dispose();
                context.Response.BinaryWrite((byte[])data);
            }
            catch
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}