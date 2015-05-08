<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAdminHomePage.aspx.cs" MasterPageFile="~/Areas/CourseAdmin/CourseAdmin.Master" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.CourseAdminIndex" %>


    <asp:Content runat="server" contentPlaceHolderID="head">
        
    </asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CellPadding="4"
            OnRowCommand="GridView1_RowCommand" AllowPaging="True" BorderStyle="None" 
            Font-Size="16pt" Height="320px" Width="1200px" 
            OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" >
        <AlternatingRowStyle BackColor="Black" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#2461BF" ForeColor="Blue" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <Columns>
               <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                  <ControlStyle Width="100px"></ControlStyle>
                  <ItemStyle Width="100px"></ItemStyle>
               </asp:BoundField>
                
                <asp:BoundField DataField="CourseTitle" HeaderText="CourseTitle" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
               </asp:BoundField>
               
                <asp:BoundField DataField="CourseDescription" HeaderText="CourseDescription" ControlStyle-Width="500px" ItemStyle-Width="500px" >
                  <ControlStyle Width="500px"></ControlStyle>
                  <ItemStyle Width="500px"></ItemStyle>
                </asp:BoundField>
                   <asp:BoundField DataField="Fee" HeaderText="Fee" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                  <ControlStyle Width="100px"></ControlStyle>
                  <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="NumberOfDays" HeaderText="NumberOfDays" ControlStyle-Width="100px" ItemStyle-Width="100px" >
                  <ControlStyle Width="100px"></ControlStyle>
                  <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Category.CategoryName" HeaderText="Cateory" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                <HeaderTemplate>
                  Opeation
                </HeaderTemplate>
                <ItemTemplate >
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("CourseCode") %>' CommandName="Del" Width="100px">Del</asp:LinkButton>
    
    
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("CourseCode") %>' CommandName="Edit" Width="100px">Edit</asp:LinkButton>
   
                </ItemTemplate>
               </asp:TemplateField>
        </Columns>
                        <PagerStyle BackColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#3333CC" />
                        <HeaderStyle BackColor="#666699" />
                        <AlternatingRowStyle BackColor="#CCFFFF" />
        </asp:GridView>
</asp:Content>


