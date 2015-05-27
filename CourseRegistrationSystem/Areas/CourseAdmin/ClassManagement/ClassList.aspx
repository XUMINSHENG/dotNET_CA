﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement.ClassList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style="height: 424px">
    <form id="form1" runat="server">
    <div>
                <asp:Panel ID="SelectPanel" runat="server" Width="1141px">
            <asp:Table ID="SelectTable" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="20%">
                        <label>
                            Select Category:
                        </label>
                    </asp:TableCell>
                    <asp:TableCell Width="80%">
                        <asp:DropDownList ID="DropDownCategory" runat="server" Width="220px"
                            OnSelectedIndexChanged="DropDownCategory_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem>Select All</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Record:
                    </asp:TableCell>
                    <asp:TableCell>
                        <label id="LblRecNo" runat="server"></label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%" HorizontalAlign="Right">
                        <asp:Button ID="BtnCreate" runat="server" Text="Create Course" OnClick="BTNCREATE_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>

         <asp:Panel ID="Panel1" runat="server" >
            <asp:GridView ID="GridView1" runat="server" Width="1141px" CellPadding="4" ForeColor="#333333" 
                AllowPaging="True" 
                AutoGenerateColumns="False"
                AllowSorting="True"
                
                OnRowCommand="GridView1_RowCommand"
                OnPageIndexChanging="GridView1_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="30px" />
                
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" Height="30px" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:TemplateField HeaderText="No." ControlStyle-Width="30px" ItemStyle-Width="30px">
                        <ItemTemplate>
                        <asp:Label ID="LblRecordNo" runat="server" Text='<%# Container.DataItemIndex+1%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
       
                    <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            Class ID
                        </HeaderTemplate>
                        <ItemTemplate >
                            <asp:LinkButton runat="server" Text='<%# Eval("ClassId") %>' style="display:block;text-align:left"
                                CommandArgument='<%#Eval("ClassId") %>' OnClick="BTNVIEW_Click" ></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" ControlStyle-Width="100px" ItemStyle-Width="100px" DataFormatString="{0:dd-MMM-yyyy}" >
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="EndDate" HeaderText="End Date" ControlStyle-Width="100px" ItemStyle-Width="100px" DataFormatString="{0:dd-MMM-yyyy}" >
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="isOpenForRegister" HeaderText="Open For Register" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Status" HeaderText="Status" ControlStyle-Width="100px" ItemStyle-Width="100px">
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="70px" HorizontalAlign="Right" />
                    </asp:BoundField>

                    <asp:BoundField DataField="IsDeleted" HeaderText="Deleted" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                    </asp:BoundField>
                      
                        
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            Opeation
                        </HeaderTemplate>
                        <ItemTemplate >
                            <asp:Button ID="BtnEdit" runat="server" Font-Size="9pt" Text="Edit" 
                                OnClick="BTNEDIT_Click" 
                                CommandArgument='<%# Bind("ClassId") %>' Width="50px" />

                            <asp:Button ID="BtnViewDetail" runat="server" Font-Size="9pt" Text="Delete" 
                                OnClick="BTNViewDetail_Click" 
                                CommandArgument='<%# Bind("ClassId") %>' 
                                Width="50px" />

                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
