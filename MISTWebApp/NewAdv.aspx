<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAdv.aspx.cs" Inherits="MISTWebApp.NewAdv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Advertisement</title>
    <style>
        .center{
             vertical-align: middle;
             text-align: center;
             height: 100%;
             width: 100%;
        }
        .auto-style1 {
            width: 511px;
        }
        .auto-style2 {
            width: 120px;
        }
        .auto-style3 {
            width: 301px;
        }
        .auto-style4 {
            width: 304px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">

           <div id="SellerAdv" runat="server" style="margin-bottom:20px;" >
            <table>
                  <tr >
                    <td >
                        <asp:Label ID="Label14" runat="server" Text="Your Advertisements" 
                            ></asp:Label>   
                    </td>
                    <td>
                        <asp:DropDownList ID="AdvsList" runat="server" Width="333px"  AutoPostBack="True" 
                            OnSelectedIndexChanged="AdvsList_SelectedIndexChanged"  >
                        </asp:DropDownList>
                       
                    </td>
                </tr>
            </table>
            
       
            <hr />
        </div>
       
        <div style="margin-bottom:20px;" >
            
            <table >
                <tr style="margin-bottom:25px;" >
                    
                    <td >
                        
                        <asp:Label ID="Label1" runat="server" Text="Advertisement Name"></asp:Label>   
                    </td>
                    <td>
                        <input id="AdvertisementNameTxt" name="AdvertisementNameTxt" required="required"  type="text" runat="server" class="auto-style1" />
                    </td>
                </tr>

                 <tr style="margin-bottom:25px;">
                    <td >
                        <asp:Label ID="Label2" runat="server" Text="Classify Your Advertisement"></asp:Label>   
                    </td>
                    <td>
                        <asp:DropDownList ID="AdCategoryList" runat="server" Width="333px" AppendDataBoundItems="True"  AutoPostBack="True" 
                            OnSelectedIndexChanged="AdCategoryList_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="AdCategoryList"
                ErrorMessage="Value Required!" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr> 
                

               
            </table>
            
        </div>
        <hr />
        <div id="details" runat="server" >
            <table style="margin-bottom:20px;">
                 <tr style="margin-bottom:25px;" >
                    <td >
                        <asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>   
                    </td>
                    <td>
                        <asp:DropDownList ID="AdSubCategoryList" runat="server" 
                            AppendDataBoundItems="True" Width="333px"  AutoPostBack="True" 
                            OnSelectedIndexChanged="AdSubCategoryLisy_SelectedIndexChanged" >
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="AdSubCategoryList"
                ErrorMessage="Value Required!" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                 <tr style="margin-bottom:25px;" >
                    <td >
                        <asp:Label ID="Label4" runat="server" Text="Brand"></asp:Label>   
                    </td>
                    <td>
                        <asp:DropDownList ID="BrandsList"  AppendDataBoundItems="True" runat="server" Width="333px"  AutoPostBack="True" 
                            OnSelectedIndexChanged="BrandsList_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="BrandsList"
                ErrorMessage="Value Required!" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr> 

                 <tr style="margin-bottom:25px;" >
                    <td >
                        <asp:Label ID="Label13" runat="server" Text="Status"></asp:Label>   
                    </td>
                    <td>
                        <asp:DropDownList ID="StatusList" runat="server"   AppendDataBoundItems="True" Width="333px"  AutoPostBack="True" 
                            OnSelectedIndexChanged="StatusList_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="StatusList"
                ErrorMessage="Value Required!" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr> 
                <tr style="margin-bottom:25px;" >
                    <td >
                        <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label>   
                    </td>
                    <td>
                       <input id="PriceTxt" type="number" required="required"  runat="server" class="auto-style2" />
                        </td>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  
                        ControlToValidate="PriceTxt" ErrorMessage="Value must be greater than zero." 
                        ValidationExpression="^[1-9][0-9]*$"></asp:RegularExpressionValidator>  

                    
                </tr> 
            </table>
        </div>
        <div>
            <table style="margin-bottom:20px;">
                <tr>
                    <td> <asp:Label ID="Label6" runat="server" Text="Advertisement Description"></asp:Label>    </td>
                    <td class="auto-style4"> <textarea id="Descriptiontxt" runat="server" rows="5"  required="required"  class="auto-style3" ></textarea></td>
                </tr>

                 <tr>
                    <td> <asp:Label ID="Label7" runat="server" Text="Advertisement Image"></asp:Label>    </td>


                    <%-- 
                     <td>
                         <input id="File1" type="file"  />
                     </td>--%>

                    <td class="auto-style4"> <asp:FileUpload ID="ImageFileUpload" runat="server" Width="297px"
                        accept=".png,.jpg,.jpeg,.gif" /></td>

                     <td> <asp:Label ID="ImageName" runat="server" ></asp:Label> </td>
                     <td >
                         <asp:Image ID="Image1" runat="server" Width="146px" />
                     </td>
                     <td> <asp:Label ID="image"  runat="server" ></asp:Label> </td>
                     

                     
                     
                </tr>
            </table>
        </div>
        <hr />
        <div>
            <table style="margin-bottom:20px;">
                <tr>
                     <td >
                        
                        <asp:Label ID="Label8" runat="server" Text="Advertisement Location"></asp:Label>   
                    </td>
                    <td>
                        <input id="LocationTxt" type="text" required="required"  runat="server" class="auto-style1" />
                    </td>
                </tr>
            </table>
        </div>
        <hr />
        <div>
            <table style="margin-bottom:20px;">
                  <tr style="margin-bottom:25px;">
                     <td >
                        
                        <asp:Label ID="Label9" runat="server" Text="Seller Name"></asp:Label>   
                    </td>
                    <td>
                        <input id="SellerNameTxt" type="text" required="required"  runat="server"   class="auto-style1" />
                    </td>
                </tr>
                  <tr style="margin-bottom:25px;">
                     <td >
                        
                        <asp:Label ID="Label10" runat="server" Text="Seller Mobile"></asp:Label>   
                    </td>
                    <td>
                        <input id="SellerMobileTxt" type="tel"  required="required" runat="server"  class="auto-style1" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
                        ControlToValidate="SellerMobileTxt" ErrorMessage="Enter a valid Mobile No. 01xxxxxxxx"  
                        ValidationExpression="^01[0-2][0-9]{8}$"></asp:RegularExpressionValidator>  
                        
                    </td>
                </tr>
                  <tr style="margin-bottom:25px;">
                     <td >
                        
                        <asp:Label ID="Label11" runat="server" Text="Seller E-mail"></asp:Label>   
                    </td>
                    <td>
                        <input id="SellerMailTxt" type="email" required="required"  runat="server"  class="auto-style1" />
                        
                    </td>
                </tr>
                <tr style="margin-bottom:25px;">
                     <td >
                        
                        <asp:Label ID="Label12" runat="server" Text="Contact me via"></asp:Label>   
                    </td>
                    <td>

                         <asp:RadioButtonList ID="RadioButtonList1"  runat="server" RepeatDirection="Horizontal" AutoPostBack="True" 
                             RepeatLayout="Table" CellSpacing="5" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" >
                        <asp:ListItem  Value="1" Text="Phone"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Msgs"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Both"></asp:ListItem>
                    </asp:RadioButtonList>

                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                           ControlToValidate="RadioButtonList1"
                             ErrorMessage="Value Required!"   ></asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
        </div>

        <p  style="text-align: center">
            <asp:Button ID="SavButton" runat="server" Text="Save Your Advertisement" Width="359px" OnClick="Button1_Click" />
        </p>

        <div id="SellerBtn"  runat="server" style="text-align: center">
            
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" Width="243px" OnClick="UpdateBtn_Click" />
             &nbsp;
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" Width="267px" OnClick="DeleteBtn_Click" />
        </div>
        <div style="text-align: center">
            <asp:Label ID="LabelAction"  runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
