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
            </asp:Table>
                    
                
            <asp:Panel ID="Panel3" runat="server">
                <asp:Button runat="server" Text="Create" />
            </asp:Panel>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
