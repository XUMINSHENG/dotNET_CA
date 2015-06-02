﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassDetail.aspx.cs" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement.ClassDetail" %>


<body>
    <form id="form1" runat="server">
    <asp:Table ID="table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Class ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID ="tb_ClassID"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Start Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox runat="server" ID ="tb_startDate"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="End Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox runat="server" ID ="tb_endDate"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Register Status"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddl_RegisterStatus" runat="server" >
                    <asp:ListItem Text="Open"></asp:ListItem>
                    <asp:ListItem Text="Closed"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Class Status"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddt_ClassStatus" runat="server" >
                    <asp:ListItem Text="Pending"></asp:ListItem>
                    <asp:ListItem Text="Confirm"></asp:ListItem>
                    <asp:ListItem Text ="Cancel"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Course"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownCourse" runat="server" Width="220px"
                            AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
        
    </form>
</body>