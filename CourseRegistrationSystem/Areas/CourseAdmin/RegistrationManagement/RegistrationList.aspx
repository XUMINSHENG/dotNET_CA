﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.RegistrationManagement.RegistrationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="SelectPanel" runat="server" Width="1250px">
            <asp:Table ID="SelectTable" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="10%">
                        <label>
                            Category:
                        </label>
                    </asp:TableCell>
                    <asp:TableCell Width="25%">
                        <asp:DropDownList ID="DropDownCategory" runat="server" Width="220px"
                            OnSelectedIndexChanged="DropDownCategory_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem>Select All</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell Width="10%">
                        <label>
                            Course:
                        </label>
                    </asp:TableCell>
                    <asp:TableCell Width="25%">
                        <asp:DropDownList ID="DropDownCourse" runat="server" Width="220px"
                            OnSelectedIndexChanged="DropDownCourse_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem>Select All</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell Width="10%">
                        <label>
                            ClassStartDate:
                        </label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:DropDownList ID="DropDownClass" runat="server" Width="220px"
                            OnSelectedIndexChanged="DropDownClass_SelectedIndexChanged"
                            AutoPostBack="true"  DataTextFormatString="{0:dd-MMM-yyyy}">
                            <asp:ListItem>Select All</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>

                </asp:TableRow>
            </asp:Table>

            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="30%">
                        Record:
                    </asp:TableCell>
                    <asp:TableCell Width="70%">
                        <label id="LblRecNo" runat="server"></label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%" HorizontalAlign="Right">
                        <asp:Button ID="BtnCreate" runat="server" Text="Create Course" OnClick="BTNCREATE_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>

        <asp:Panel ID="Panel1" runat="server" >
            <asp:GridView ID="GridView1" runat="server" Width="1250px" CellPadding="4" ForeColor="#333333" 
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
                    
                    <asp:BoundField DataField="CourseClass.Course.Category.CategoryName" HeaderText="Category" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="CourseClass.Course.CourseCode" HeaderText="CourseCode" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            CourseTitle
                        </HeaderTemplate>
                        <ItemTemplate >
                            <asp:LinkButton runat="server" Text='<%# Eval("CourseClass.Course.CourseTitle") %>' style="display:block;text-align:left"
                                CommandArgument='<%#Eval("CourseClass.Course.CourseCode") %>' OnClick="BTNVIEW_Click" ></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="CourseClass.StartDate" HeaderText="StartDate" ControlStyle-Width="100px" ItemStyle-Width="100px" 
                        DataFormatString="{0:dd-MMM-yyyy}" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="CourseClass.EndDate" HeaderText="EndDate" ControlStyle-Width="100px" ItemStyle-Width="100px" 
                        DataFormatString="{0:dd-MMM-yyyy}" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
               
                    <asp:BoundField DataField="Participant.Fullname" HeaderText="Participant" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>

                        <asp:BoundField DataField="Status" HeaderText="Status" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" ControlStyle-Width="100px" ItemStyle-Width="100px" 
                        DataFormatString="{0:dd-MMM-yyyy}" >
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                        
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            Opeation
                        </HeaderTemplate>

                        <ItemTemplate >
                            <asp:Button ID="BtnEdit" runat="server" Font-Size="9pt" Text="Edit" 
                                OnClick="BTNEDIT_Click" 
                                CommandArgument='<%# Bind("RegistrationId") %>' Width="50px" />
                            <asp:Button ID="BtnDelete" runat="server" Font-Size="9pt" Text="Delete" 
                                OnClick="BTNDELETE_Click" 
                                CommandArgument='<%# Bind("RegistrationId") %>' 
                                OnClientClick='javascript:return confirm("This record will be deleted?");'
                                Width="50px" />
                            <asp:Button ID="BtnClass" runat="server" Font-Size="9pt" Text="View Class" 
                                OnClick="BTNCLASS_Click" 
                                CommandArgument='<%# Bind("RegistrationId") %>' Width="90px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="250px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
