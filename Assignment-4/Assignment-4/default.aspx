<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Assignment_4._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gredit</title>
</head>
<body>
    <form id="main" runat="server">
        <div>
            <asp:Button ID="btn1" runat="server" Text="+" />
        </div>
        <div>
            <asp:Panel ID="pnldynamic" runat="server" BorderColor="#990000" 
                BorderStyle="Solid" Height="150px"  ScrollBars="Auto" style="width:60%" BackColor="#CCCCFF"  Font-Names="Courier" HorizontalAlign="Center">
     
                This panel shows dynamic control generation:
                <br />
                <br />
            </asp:Panel>
        </div>

        <table style="width: 51%;">
            <tr>
                <td class="style2">No of Labels:</td>
                <td class="style1">
                <asp:DropDownList ID="ddllabels" runat="server">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="style2"> </td>
                <td class="style1"> </td>
            </tr>

            <tr>
                <td class="style2">No of Text Boxes :</td>
                <td class="style1">
                <asp:DropDownList ID="ddltextbox" runat="server">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem Value="4"></asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="style2"> </td>
                <td class="style1"> </td>
            </tr>

            <tr>
                <td class="style2">
                <asp:CheckBox ID="chkvisible" runat="server" 
                    Text="Make the Panel Visible" />
                </td>

                <td class="style1">
                <asp:Button ID="btnrefresh" runat="server" Text="Refresh Panel" 
                    style="width:129px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
