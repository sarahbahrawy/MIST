<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MISTWebApp.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <style>
        .margin{
            margin-top:10px;
            margin-left:5px;
        }
        .marginEnd{
           
            margin-left:95%;
            font-size:x-large;
        }
    </style>

   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="margin">
                <asp:Button ID="Button1" runat="server" Height="37px" Text="Add Aew Advertisement." Width="229px" OnClick="Button1_Click" />
                <asp:Label ID="MaxAd" runat="server"></asp:Label>
                 
           <asp:LinkButton class="marginEnd" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Width="55px">Logout</asp:LinkButton>
                 
            </div>

            <div class="margin">
                <asp:Button ID="Button2" runat="server" Height="37px" Text="View Your Advertisement" Width="229px" OnClick="Button2_Click" />
            </div>
            
            <table style="width: 100%; height: 100%; text-align: center; vertical-align: middle; margin-top:250px;">
                <tr>
                    <td style="width: 100%; height: 100%; text-align: center; vertical-align: middle;">
                            <asp:Label ID="WelcomLabel" runat="server" Text="Welcome to MIST" Font-Size="70px" Font-Bold="true" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
