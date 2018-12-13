<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Assignment_4._default" %>

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
    
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    
    <script>
        setInterval(updateProjects, 10000);

        function updateProjects(id) {

            myData = JSON.stringify({ s: id });

            $.ajax({
                type: "POST",
                url: "default.aspx/updateGroups",
                data: myData,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            });
        }

        function editGroup() {
            var title = prompt("Enter Project Title: ", "Title");
            var desc = prompt("Project Description", "Descritption")

            if (title == null || title == "" || desc == null) {
                alert("Must have a title/description");
                editGroup();
                return;
            }

            document.getElementById("callServer1").value = title;
            document.getElementById("callServer2").value = desc;

            

            //var myData = JSON.stringify({ t: title, d: desc });

            $.ajax({
                type: "POST",
                url: "default.aspx/editProject",
                data: "",
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            });
        }
        
        function goToNextPage() {
            $.ajax({
                type: "POST",
                url: "default.aspx/goToNextPage",
                data: "",
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            });
        }
    </script>
</head>
<body>
    <form id="main" runat="server">
        <asp:HiddenField ID="callServer1" runat="server" />
        <asp:HiddenField ID="callServer2" runat="server" />

        <div class="Fixed">
            <table style="width:100%; align-content:stretch;">
                <tr>
                    <td class="child">
                        <asp:Button ID="addObj" class="btnClass" runat="server" Text="+" Font-Size="Larger" Font-Bold="true" OnClick="makeNewGroup" />
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
        
        <div id="content2" class="Content">
            <asp:Panel ID="pnldynamic" runat="server" BorderColor="#646464" 
                BorderStyle="Solid" Height="150px" ScrollBars="Auto" style="width:100%; height:auto"
                BackColor="#C8C8C8" Font-Names="Courier" HorizontalAlign="Center" >
            </asp:Panel>
        </div>
    </form>
</body>
</html>
