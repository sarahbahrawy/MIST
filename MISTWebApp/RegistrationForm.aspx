<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="MISTWebApp.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
     <style type="text/css">
        .auto-style1 {
            width: 562px;
            margin-top:10px;
        }
        .auto-style5 {
            margin-left: 0px;
        }
        .auto-style7 {
            width: 467px;
            margin-left: 0px;
            height: 30px;
        }
        .auto-style8 {
            width: 462px;
            height: 35px;
        }
    </style>
</head>
<body >
    <form  id="form1" runat="server" >
       <div>
            <table style="width: 100%; height: 100%; text-align: center; vertical-align: middle; margin-top:250px;">
                 <tr style="width: 50%; height: 100%; text-align: center; vertical-align: middle; ">
                  
                     <td class="auto-style1">
                         <input id="UsernameTxt" placeholder="Your Username :-" name="UsernameTxt"  type="text" runat="server" class="auto-style8" />
                     </td>
                </tr> 
                <tr style="width: 50%; height: 100%; text-align: center; vertical-align: middle; ">
                    
                      
                    <td class="auto-style1">
                        <input id="PasswordTxt" placeholder="Your Password :-" name="Passwordtxt" runat="server" type="password" class="auto-style7"   /></td>
                </tr>
            </table>
        </div>
        <div style="margin-left:650px; margin-top:10px;" >
            <asp:Button ID="Button2" runat="server" Text="Register"  onclick="Button1_Click1" Width="178px" />
        </div>
        <div style="margin-left:430px; margin-top:10px;" >
            <asp:Label ID="Label5" runat="server" ></asp:Label>
            
        </div>
     </form>
</body>
</html>
