﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement.CourseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 424px">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="1158px">
            <asp:GridView ID="GridView1" runat="server" Height="346px" Width="1141px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                AllowPaging="True" 
                AutoGenerateColumns="False"
                AllowSorting="True"
                OnRowCommand="GridView1_RowCommand"
                OnPageIndexChanging="GridView1_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" ControlStyle-Width="100px" ItemStyle-Width="100px" />
                
                    <asp:HyperLinkField DataTextField="CourseTitle" HeaderText="Title" ControlStyle-Width="300px" ItemStyle-Width="300px"/>
                
                    <asp:BoundField DataField="Category.CategoryName" HeaderText="Cateory" ControlStyle-Width="200px" ItemStyle-Width="200px" />
               
                    <asp:BoundField DataField="NumberOfDays" HeaderText="Duration" ControlStyle-Width="100px" ItemStyle-Width="100px" />

                    <asp:BoundField DataField="Fee" HeaderText="Fee" ControlStyle-Width="100px" ItemStyle-Width="100px" />
                        
                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" ControlStyle-Width="100px" ItemStyle-Width="100px" />
                        
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Opeation
                        </HeaderTemplate>


                        <ItemTemplate >
                            <asp:Button ID="BtnEdit" runat="server" Font-Size="9pt" Text="Edit" OnClick="BTNEDIT_Click" CommandArgument='<%# Bind("CourseCode") %>' />
                            <asp:Button ID="BtnDelete" runat="server" Font-Size="9pt" Text="Delete" OnClick="BTNDELETE_Click" CommandArgument='<%# Bind("CourseCode") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>