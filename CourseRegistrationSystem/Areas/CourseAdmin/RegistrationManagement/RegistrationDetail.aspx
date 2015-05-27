<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationDetail.aspx.cs" MasterPageFile="~/Areas/CourseAdmin/CourseAdmin.Master" Inherits="CourseRegistrationSystem.Areas.CourseAdmin.RegistrationManagement.RegistrationDetail" %>

<asp:Content ID="Content1" runat="server" contentPlaceHolderID="ContentPlaceHolder1">
    <div>
    <asp:Panel ID="Panel3" runat="server" >
            <asp:Label ID="LblMessage" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Height="566px" Width ="768px">

            <asp:Table ID="Table1" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top" Width="15%">
                        <asp:label runat="server">RegistrationId</asp:label>
                    </asp:TableCell>
                    <asp:TableCell Width="85%">
                        <asp:TextBox ID="TxtRegistrationId" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                        <asp:HiddenField ID="HidTimestamp" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">CourseCategory:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCategory" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">CourseCode:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCourseCode" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">CourseTitle:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtCourseTitle" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        ClassStartTime:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownClass" runat="server" Width="250px" DataTextFormatString="{0:dd-MMM-yyyy}"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Participant:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtParticipant" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        Status:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtStatus" runat="server" Width="250px" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">Sponsorship:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtSponsorship" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">DietaryRequirement:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtDietaryRequirement" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">OrganizationSize:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtOrganizationSize" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">BillingAddress:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtBillingAddress" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">BillingPersonName:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtBillingPersonName" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">BillingAddressCountry:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtBillingAddressCountry" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        <asp:label runat="server">BillingAddressPostalCode:</asp:label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TxtBillingAddressPostalCode" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top">
                        CreateDate:
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="TxtCreateDate" runat="server" Enabled="false" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Panel ID="BtnPanel" runat="server" >
                <asp:Panel ID="EditPanel" runat="server" HorizontalAlign="Center">
                    <asp:Button runat="server" Text="Edit" ID="BtnEdit" OnClick="BtnEdit_Click" Width="80px" ValidationGroup="ValidGroup" />
                    <asp:Button runat="server" Text="Back" OnClick="BtnBack_Click"  Width="80px"/>
                </asp:Panel>
                <asp:Panel ID="ViewPanel" runat="server" HorizontalAlign="Center">
                    <asp:Button runat="server" Text="Back" OnClick="BtnBack_Click" Width="80px" />
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </div>
</asp:Content>
