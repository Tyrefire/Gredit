<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="object.aspx.cs" Inherits="Assignment_4._object" %>

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
            text-align: center;
            vertical-align: middle;
        }
        .Content {
            width: 100%;
            padding-top: 5%;
            text-align: left;
            vertical-align: text-top;
        }
    </style>
    <script>
        setInterval(updateData(), 10000);

        function updateData() {
            <%
                updateText();
            %>
        }

        function goBack() {
            window.history.back();
        }

        function setStatusOpen() {
            <%
                obj.setStatus(0);
            %>
        }
    </script>
</head>
<body onunload="setStatusOpen()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <div class="Fixed">
            <table style="width:100%; align-content:stretch;">
                <tr>
                    <td class="child">
                        <asp:ImageButton ID="backBtn" class="btnClass" runat="server" ImageUrl="~/Models/back.png" OnClientClick="goBack()"/>
                    </td>
                    <td class="child">
                        <label>Title: </label>
                        <asp:TextBox ID="titleField" runat="server"></asp:TextBox>
                    </td>
                    <td class="child">
                        <asp:Button ID="btnrefresh" runat="server" Text="Refresh Panel" style="width:130px" />
                    </td>
                </tr>
            </table>
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
