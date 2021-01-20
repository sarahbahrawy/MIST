using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISTWebApp
{
    public partial class NewAdv : System.Web.UI.Page
    {

        private SqlConnection Connection;
        private SqlCommand Command;

        private static int CategoryID;
        private static int SubCategoryID;
        private static int BrandID;
        private static int StatusID;
        private static int SellerConnectID;
        private static int AdSerial;
       

        private AdClass NewAd = new AdClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            SellerBtn.Visible = false;
            image.Visible = false;
            SellerAdv.Visible = false;
            details.Visible = false;
            LabelAction.Visible = false;
            Image1.Visible = false;

            NewAd.SellerID = (int)Session["Logined_ID"];

            if (Session["ViewAdsList"].ToString() == "1")
            {
                SellerAdv.Visible = true;
                SavButton.Visible = false;

            }
            

            string constr = ConfigurationManager.ConnectionStrings["MISTDBEntities"].ToString();
            Connection = new SqlConnection(constr);
            if (!IsPostBack)
            {               
                
                getCategories();
                GetSellerAdv();
            }
            else
            {
                if ((Session["ImageFileUpload"] == null && ImageFileUpload.HasFile)|| ImageFileUpload.HasFile)
                {
                    Session["ImageFileUpload"] = ImageFileUpload;
                    ImageName.Text = ImageFileUpload.FileName;
                    StartUpLoad();

                }
                else if (Session["ImageFileUpload"] != null && (!ImageFileUpload.HasFile))
                {
                    ImageFileUpload = (FileUpload)Session["ImageFileUpload"];
                    ImageName.Text = ImageFileUpload.FileName;
                    StartUpLoad();


                }
              
            }

        }



        private void GetSellerAdv()
        {
            Connection.Open();
            Command = new SqlCommand("select *from Adv where SellerID=@SellerID", Connection);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            Command.Parameters.AddWithValue("@SellerID", NewAd.SellerID);
            DataSet ds = new DataSet();
            da.Fill(ds);

            AdvsList.DataTextField = ds.Tables[0].Columns["AdName"].ToString();
            AdvsList.DataValueField = ds.Tables[0].Columns["Serial"].ToString();

            AdvsList.DataSource = ds.Tables[0];
            AdvsList.DataBind();
            Connection.Close();
            AdvsList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        private void getCategories()
        {
            Connection.Open();
            Command = new SqlCommand("select *from Categories", Connection);
            
            SqlDataAdapter da = new SqlDataAdapter(Command);
            DataSet ds = new DataSet();
            da.Fill(ds);  
            
            AdCategoryList.DataTextField = ds.Tables[0].Columns["Category"].ToString();      
            AdCategoryList.DataValueField = ds.Tables[0].Columns["CategoryID"].ToString();
            
            AdCategoryList.DataSource = ds.Tables[0];      
            AdCategoryList.DataBind();
            Connection.Close();
            AdCategoryList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        private void getStatus()
        {
            StatusList.Items.Clear();
            Command = new SqlCommand("select *from Status", Connection);

            SqlDataAdapter da = new SqlDataAdapter(Command);
            DataSet ds = new DataSet();
            da.Fill(ds);

            StatusList.DataTextField = ds.Tables[0].Columns["Name"].ToString();
            StatusList.DataValueField = ds.Tables[0].Columns["ID"].ToString();

            StatusList.DataSource = ds.Tables[0];
            StatusList.DataBind();
            
            StatusList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        private void getSubCategories()
        {
            AdSubCategoryList.Items.Clear();
            Command = new SqlCommand("select *from SubCategories where CategoryID= @CategoryID", Connection);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            Command.Parameters.Add("@CategoryID", SqlDbType.VarChar).Value = CategoryID;
            DataSet ds = new DataSet();
            da.Fill(ds);

            AdSubCategoryList.DataTextField = ds.Tables[0].Columns["SubCategoryName"].ToString();
            AdSubCategoryList.DataValueField = ds.Tables[0].Columns["SubCategoryID"].ToString();

            AdSubCategoryList.DataSource = ds.Tables[0];
            AdSubCategoryList.DataBind();
           
            AdSubCategoryList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        private void getBrands()
        {
            BrandsList.Items.Clear();
            Command = new SqlCommand("select *from Brands where CategoryID= @CategoryID", Connection);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            Command.Parameters.Add("@CategoryID", SqlDbType.VarChar).Value = CategoryID;
            DataSet ds = new DataSet();
            da.Fill(ds);

            BrandsList.DataTextField = ds.Tables[0].Columns["BrandName"].ToString();
            BrandsList.DataValueField = ds.Tables[0].Columns["BrandID"].ToString();

            BrandsList.DataSource = ds.Tables[0];
            BrandsList.DataBind();
            
            BrandsList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        protected void AdCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               CategoryID = int.Parse(AdCategoryList.SelectedValue);
                Update();
                details.Visible = true;
                Connection.Open();
                getSubCategories();
                getBrands();
                getStatus();
                Connection.Close();
            }
            catch
            {
               
            }
        }

        protected void AdSubCategoryLisy_SelectedIndexChanged(object sender, EventArgs e)
        {
            details.Visible = true;

            try
            {
                Update();
                SubCategoryID = int.Parse(AdSubCategoryList.SelectedValue);
                
            }
            catch
            {
              
            }

        }

        protected void BrandsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            details.Visible = true;

            try
            {
                Update();
                BrandID = int.Parse(BrandsList.SelectedValue);
                
            }
            catch
            {
                
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            details.Visible = true;
            Update();
            SellerConnectID = int.Parse(RadioButtonList1.SelectedItem.Value);
        }

        protected void StatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            details.Visible = true;
            try
            {
                Update();
                StatusID = int.Parse(StatusList.SelectedValue);

            }
            catch
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            details.Visible = true;
            SaveData();
        }

        private void GetImage()
        {
            Image1.Visible = true;
            Image1.ImageUrl = "Handler1.ashx?Serial=" + AdSerial;
        }

        private void SendMail(string MessageText)
        {        
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("MIST", "saramist.2210@gmail.com"));
                message.To.Add(new MailboxAddress("User", NewAd.SellerEmail));
                message.Subject = "Confirmation Mail";

                message.Body = new TextPart("plain")
                {
                    Text = MessageText 
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("saramist.2210@gmail.com", "01145462525");
                    client.Send(message);
                    client.Disconnect(true);
                    
                }

        }

        private void AdClassFunction()
        {
            try
            {
                

                NewAd.SellerConnectID = SellerConnectID;

                NewAd.StatusID = StatusID;

                NewAd.BrandID = BrandID;

                NewAd.SubCategoryID = SubCategoryID;

                NewAd.CategoryID = CategoryID;

                NewAd.AdName = Request["AdvertisementNameTxt"];

                NewAd.Price = int.Parse(Request["PriceTxt"]);

                NewAd.AdDescription = Request["Descriptiontxt"];

                NewAd.AdLocation = Request["LocationTxt"];

                NewAd.SellerName = Request["SellerNameTxt"];

                NewAd.SellerMobile = int.Parse(Request["SellerMobileTxt"]);

                NewAd.SellerEmail = Request["SellerMailTxt"];


            }
            catch
            {
                LabelAction.Visible = true;
                LabelAction.Text = "Empty Data";
            }
           
        }

        private void SaveData()
        {

            if (!ImageFileUpload.HasFile)
            {
                image.Visible = true;
                image.Text = "Please Select Image File";    //checking if file uploader has no file selected
            }
            else
            {
                AdClassFunction();
                int length = ImageFileUpload.PostedFile.ContentLength;
                NewAd.AdImage = new byte[length];
                ImageFileUpload.PostedFile.InputStream.Read(NewAd.AdImage, 0, length);

                try
                {
                    Connection.Open();
                    Command = new SqlCommand(@"insert into Adv 
                       (SellerID,SellerName,SellerMobile,SellerEmail,SellerConnectID,
                        AdName,AdDescription,AdLocation,AdImage,Price,CategoryID,SubCategoryID,BrandID,StatusID) values
                        (@SellerID,@SellerName,@SellerMobile,@SellerEmail,@SellerConnectID
                        ,@AdName,@AdDescription,@AdLocation,@AdImage,@Price,@CategoryID,@SubCategoryID,@BrandID,@StatusID)", Connection);
                    
                    Command.Parameters.AddWithValue("@SellerID", NewAd.SellerID);
                    Command.Parameters.AddWithValue("@SellerName", NewAd.SellerName);
                    Command.Parameters.AddWithValue("@SellerMobile", NewAd.SellerMobile);
                    Command.Parameters.AddWithValue("@SellerEmail", NewAd.SellerEmail);
                    Command.Parameters.AddWithValue("@SellerConnectID", NewAd.SellerConnectID);
                    Command.Parameters.AddWithValue("@AdName", NewAd.AdName);
                    Command.Parameters.AddWithValue("@AdDescription", NewAd.AdDescription);
                    Command.Parameters.AddWithValue("@AdLocation", NewAd.AdLocation);
                    Command.Parameters.AddWithValue("@AdImage", NewAd.AdImage);
                    Command.Parameters.AddWithValue("@Price", NewAd.Price);
                    Command.Parameters.AddWithValue("@CategoryID", NewAd.CategoryID);
                    Command.Parameters.AddWithValue("@SubCategoryID", NewAd.SubCategoryID);
                    Command.Parameters.AddWithValue("@BrandID", NewAd.BrandID);
                    Command.Parameters.AddWithValue("@StatusID", NewAd.StatusID);
                    Command.ExecuteNonQuery();
                    string Text = @" Welcome " + NewAd.SellerName + " , You Have Added New Advertisement in Our WebSite";
                    SendMail(Text);
                    SavButton.Visible = false;
                    Response.Redirect("HomePage.aspx");

                }
                catch
                {
                    LabelAction.Visible = true;
                    LabelAction.Text = "Empty Data";
                }
                finally
                {
                    Connection.Close();

                }
                
            }
        }

        protected void AdvsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AdSerial = int.Parse(AdvsList.SelectedValue);
                details.Visible = true;
                GetTheSelectedAd();
            }
            catch
            {
               
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            
            Connection.Open();
            Command = new SqlCommand("delete from Adv where Serial = " + AdSerial, Connection);
            try
            {
                NewAd = new AdClass();
                NewAd.SellerName = Request["SellerNameTxt"];
                NewAd.SellerEmail = Request["SellerMailTxt"];
                string Text = @" Welcome " + NewAd.SellerName + " , You Have Deleted An Advertisement in Our WebSite";
                Command.ExecuteNonQuery();
                SendMail(Text);
                LabelAction.Visible = true;
                LabelAction.Text = "Deleted";
                
                Response.Redirect("HomePage.aspx");

            }
            catch (Exception x)
            {
                
            }
            finally
            {
                Connection.Close();
                
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            AdClassFunction();
            Connection.Open();
            Command=new SqlCommand(@"update Adv set SellerName=@SellerName, SellerMobile=@SellerMobile,
                SellerEmail=@SellerEmail,SellerConnectID=@SellerConnectID,AdName=@AdName,AdDescription=@AdDescription,
                AdLocation=@AdLocation,Price=@Price,CategoryID=@CategoryID,SubCategoryID=@SubCategoryID,
                BrandID=@BrandID,StatusID=@StatusID
                where Serial =@Serial", Connection);
            Command.Parameters.AddWithValue("@Serial", AdSerial);
            Command.Parameters.AddWithValue("@SellerName", NewAd.SellerName);
            Command.Parameters.AddWithValue("@SellerMobile", NewAd.SellerMobile);
            Command.Parameters.AddWithValue("@SellerEmail", NewAd.SellerEmail);
            Command.Parameters.AddWithValue("@SellerConnectID", NewAd.SellerConnectID);
            Command.Parameters.AddWithValue("@AdName", NewAd.AdName);
            Command.Parameters.AddWithValue("@AdDescription", NewAd.AdDescription);
            Command.Parameters.AddWithValue("@AdLocation", NewAd.AdLocation);
            Command.Parameters.AddWithValue("@Price", NewAd.Price);
            Command.Parameters.AddWithValue("@CategoryID", NewAd.CategoryID);
            Command.Parameters.AddWithValue("@SubCategoryID", NewAd.SubCategoryID);
            Command.Parameters.AddWithValue("@BrandID", NewAd.BrandID);
            Command.Parameters.AddWithValue("@StatusID", NewAd.StatusID);
            Command.ExecuteNonQuery();
            string Text = @" Welcome " + NewAd.SellerName + " , You Have Updated An Advertisement in Our WebSite";
            SendMail(Text);
            Connection.Close();
           
            
            if (ImageFileUpload.HasFile)
            {
                int length = ImageFileUpload.PostedFile.ContentLength;
                NewAd.AdImage = new byte[length];
                ImageFileUpload.PostedFile.InputStream.Read(NewAd.AdImage, 0, length);

                try
                {
                    Connection.Open();
                    Command = new SqlCommand(@"update Adv set AdImage=@AdImage where Serial =@Serial", Connection);

                    Command.Parameters.AddWithValue("@Serial", AdSerial);
                    Command.Parameters.AddWithValue("@AdImage", NewAd.AdImage);
                    Command.ExecuteNonQuery();
                 

                }
                finally
                {
                    Connection.Close();

                }
            }

            GetSellerAdv();
            details.Visible = true;
        }

        private void GetTheSelectedAd()
        {
            SellerBtn.Visible = true;

            Connection.Open();
            Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "Select * from Adv where Serial= @Serial ";
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add("@Serial", SqlDbType.Int).Value = AdSerial;
            SqlDataReader dreader = Command.ExecuteReader();
            try
            {
                if (dreader.Read())
                {
                    SellerNameTxt .Value= dreader[2].ToString();
                    string Mobile = "0"+ dreader[3].ToString();

                    SellerMobileTxt.Value = Mobile;


                    SellerMailTxt.Value = dreader[4].ToString();
                    
                    RadioButtonList1.Items.FindByValue(dreader[5].ToString()).Selected=true ;
                    SellerConnectID = int.Parse(dreader[5].ToString());
                    
                    AdvertisementNameTxt.Value = dreader[6].ToString();
                    
                    Descriptiontxt.Value = dreader[7].ToString();
                    
                    LocationTxt.Value = dreader[8].ToString();
                    
                    PriceTxt.Value = dreader[10].ToString();
                    
                    AdCategoryList.SelectedValue =dreader[11].ToString();
                    CategoryID = int.Parse(dreader[11].ToString());
                    
                    getSubCategories();
                    getBrands();
                    getStatus();
                    
                    AdSubCategoryList.SelectedValue = dreader[12].ToString();
                    SubCategoryID = int.Parse(dreader[12].ToString());
                    
                    BrandsList.SelectedValue= dreader[13].ToString();
                    BrandID = int.Parse(dreader[13].ToString());
                    
                    StatusList.SelectedValue = dreader[14].ToString();
                    StatusID = int.Parse(dreader[14].ToString());
                }
                else
                {
                    LabelAction.Visible = true;
                    LabelAction.Text = "inValid";
                }
                
            }
            catch (Exception)
            {
                LabelAction.Visible = true;
                LabelAction.Text = "inValid";
            }
            finally
            {
                Connection.Close();
                GetImage();
            }

        }

        private void StartUpLoad()
        {
            string imgName = string.Empty;
            
            string imgPath = string.Empty;

            if (ImageFileUpload.PostedFile != null && ImageFileUpload.PostedFile.FileName != "")
            {
                         
                imgName = ImageFileUpload.PostedFile.FileName;
                        
                imgPath = "ImageStorage/" + imgName;
                
                ImageFileUpload.SaveAs(Server.MapPath(imgPath));
                Image1.Visible = true;
                Image1.ImageUrl = "~/" + imgPath;
            }
        }

        private void Update()
        {
            if (Session["ViewAdsList"].ToString() == "1")
            {
                SellerBtn.Visible = true;
                Image1.Visible = true;

            }
        }


    }
}