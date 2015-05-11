<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement.CourseDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="566px">

            <asp:Table ID="Table1" runat="server" Height="312px" Width="480px">
                <asp:TableRow>
                    <asp:TableCell>
                        Code:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCourseCode" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Title:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCourseTitle" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Category:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownCategory" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Description:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtDescription" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Fee:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtFee" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Duration:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtNumberOfDays" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow Height="100px">
                    <asp:TableCell>
                        Instructors:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Panel ID="Panel2" runat="server" Height="100px" ScrollBars="Vertical">
                            <asp:CheckBoxList ID="ChkBoxListInstructors" runat="server" >
                                <asp:listitem text="checkbox1"/> 
                                <asp:listitem text="checkbox2"/> 
                                <asp:listitem text="checkbox3"/> 
                                <asp:listitem text="checkbox4"/> 
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>
                        Enabled:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ChkBoxEnabled" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
                    
                
            <asp:Panel ID="Panel3" runat="server">
                <asp:Button runat="server" Text="Create" OnClick="Unnamed1_Click" />
                <asp:Button runat="server" Text="Edit" ID="BtnEdit" OnClick="BtnEdit_Click" />
            </asp:Panel>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
