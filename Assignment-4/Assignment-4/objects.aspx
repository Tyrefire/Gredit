<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="objects.aspx.cs" Inherits="Assignment_4.objects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Fixed {
            position: fixed;
            width: 100%;
            background: #555;
            color: #f1f1f1;
            padding: 1%;
        }
        .Content {
            padding-top: 5%;
        }
        .btnClass {
            width: 45px;
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Fixed">
            <table style="width:100%; align-content:stretch;">
                <tr>
                    <td>
                        <asp:Button ID="addObj" CssClass="btnClass" runat="server" Text="+" Font-Size="Larger" Font-Bold="true" />
                        <asp:ImageButton ID="backBtn" class="btnClass" runat="server" ImageUrl="~/Models/back.png"/>
                        <asp:Label ID="checker" runat="server"></asp:Label>
                    </td>
                    <td>
                        <label>Objects per row</label>
                        <asp:DropDownList ID="ddlColCount" runat="server">
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnrefresh" runat="server" Text="Refresh Panel" style="width:130px" />
                    </td>
                </tr>
            </table>
            <input type="hidden" id="loadProjects" value="1" runat="server"/>
            <input type="hidden" id="loadObjects" value="0" runat="server"/>
            <input type="hidden" id="loadSingleObject" value="0" runat="server"/>
        </div>

        <div class="Content">
            <asp:Panel ID="pnldynamic" runat="server" BorderColor="#646464" 
                BorderStyle="Solid" Height="150px" ScrollBars="Auto" style="width:100%; height:auto"
                BackColor="#C8C8C8" Font-Names="Courier" HorizontalAlign="Center" >
            </asp:Panel>
        </div>
    </form>
</body>
</html>
