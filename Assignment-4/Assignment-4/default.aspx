﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Assignment_4._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gredit</title>
    <style>
        .Fixed {
            position: fixed;
            width: 100%;
            background: #555;
            color: #f1f1f1;
            padding: 1%;
            text-align: center;
            vertical-align: middle;
        }
        .Content {
            padding-top: 5%;
        }
        .child {
            vertical-align: middle;
        }
        .btnClass {
            width: 35px;
            height: 35px;
        }
    </style>
    <script>
        function getObjects() {
            window.location = "objects.aspx";
        }
    </script>
</head>
<body>
    <form id="main" runat="server">
        <div class="Fixed">
            <table style="width:100%; align-content:stretch;">
                <tr>
                    <td class="child">
                        <asp:Button ID="addObj" class="btnClass" runat="server" Text="+" Font-Size="Larger" Font-Bold="true" />
                        <asp:ImageButton ID="backBtn" class="btnClass" runat="server" ImageUrl="~/Models/back.png"/>
                    </td>
                    <td class="child">
                        <label>Objects per row</label>
                        <asp:DropDownList ID="ddlColCount" runat="server">
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="child">
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
