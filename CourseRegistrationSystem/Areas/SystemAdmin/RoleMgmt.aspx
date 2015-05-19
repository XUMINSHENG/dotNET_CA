<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleMgmt.aspx.cs" Inherits="CourseRegistrationSystem.Areas.SystemAdmin.RoleMgmt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 196px;
        }
        .auto-style4 {
            width: 40px;
        }
        .auto-style5 {
            width: 349px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>List of Users:</td>
                <td class="auto-style3">Roles of Selected User</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">List of other available Roles for Selected User</td>
                <td class="auto-style5">&nbsp;Create Role&nbsp;</td>
            </tr>
            <tr>
                <td rowspan="6">
                    <asp:ListBox ID="lstBoxUser" runat="server" AutoPostBack="True" Height="245px" OnSelectedIndexChanged="lstBoxUser_SelectedIndexChanged" style="margin-right: 70px" Width="200px"></asp:ListBox>
                </td>
                <td class="auto-style3" rowspan="6">
                    <asp:ListBox ID="lstBoxUserRoles" runat="server" AutoPostBack="True" Height="245px" Width="200px"></asp:ListBox>
                </td>
                <td class="auto-style4" rowspan="2">&nbsp;</td>
                <td class="auto-style5" rowspan="6">
                    <asp:ListBox ID="lstBoxRoles" runat="server" AutoPostBack="True" Height="245px" Width="200px"></asp:ListBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblRoleName" runat="server" Text="Enter Role Name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="vertical-align: middle; text-align: center">
                    <asp:Button ID="btnCreateRole" runat="server" OnClick="btnCreateRole_Click" Text="Create Role" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="btnAddUserRole" runat="server" OnClick="btnAddUserRole_Click" Text="&lt;-----" />
                </td>
                <td class="auto-style5">&nbsp;Delete Role&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="btnRemoveUserRole" runat="server" OnClick="btnRemoveUserRole_Click" Text="-----&gt;" />
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblRoleName0" runat="server" Text="Select Role: "></asp:Label>
&nbsp;
                    <asp:DropDownList ID="drpdwnlstRoles" runat="server" AutoPostBack="True" Height="19px" Width="133px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5" style="vertical-align: middle; text-align: center">
                    <asp:Button ID="btnDeleteRole" runat="server" OnClick="btnDeleteRole_Click" Text="Delete Role" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="lblStatusMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
