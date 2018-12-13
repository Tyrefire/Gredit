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
        setInterval(updateObjects, 10000);

        function updateObjects() {
            
        }

        function editWork() {
            var title = prompt("Enter Object Title: ", "Title");

            if (title == null || title == "") {
                alert("must have a title");
                editWork();
                return;
            }

            document.getElementById("callServer").value = title;
        }

        function goBack() {
            window.location = "default.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="callServer" runat="server" />
        
        <div class="Fixed">
            <table style="width:100%; align-content:stretch;">
                <tr>
                    <td class="child">
                        <asp:Button ID="addObj" class="btnClass" runat="server" Text="+" Font-Size="Larger" Font-Bold="true" OnClick="makeNewObj" />
                        <asp:ImageButton ID="backBtn" class="btnClass" runat="server" ImageUrl="~/Models/back.png" OnClientClick="goBack()"/>
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
