<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement.CourseDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="566px" Width ="40%">

            <asp:Table ID="Table1" runat="server" Width="480px">
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Code:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCourseCode" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Title:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCourseTitle" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Category:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownCategory" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Description:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtDescription" runat="server" TextMode="multiline" Rows="5" Width="480px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Fee:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtFee" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Duration:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtNumberOfDays" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow Height="100px">
                    <asp:TableCell VerticalAlign="Top">
                        Instructors:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Panel ID="Panel2" runat="server" Height="100px" ScrollBars="Vertical" BorderWidth="1px">
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
                    <asp:TableCell VerticalAlign="Top">
                        Enabled:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ChkBoxEnabled" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        CreateDate:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCreateDate" runat="server" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <br />

            <asp:Panel ID="BtnPanel" runat="server" >
                <asp:Panel ID="NewPanel" runat="server" HorizontalAlign="Center">
                    <asp:Button runat="server" Text="Create" OnClick="BtnCreate_Click" />
                    <asp:Button runat="server" Text="Back" OnClick="BtnBack_Click" />
                </asp:Panel>
                <asp:Panel ID="EditPanel" runat="server" HorizontalAlign="Center">
                    <asp:Button runat="server" Text="Edit" ID="BtnEdit" OnClick="BtnEdit_Click" />
                    <asp:Button runat="server" Text="Back" OnClick="BtnBack_Click" />
                </asp:Panel>
                <asp:Panel ID="ViewPanel" runat="server" HorizontalAlign="Center">
                    <asp:Button runat="server" Text="Back" OnClick="BtnBack_Click" />
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
