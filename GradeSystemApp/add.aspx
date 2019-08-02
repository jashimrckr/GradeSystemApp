<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="GradeSystemApp.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grade Details</title>
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="gradeSystemBlock">
         <p>
            <asp:ValidationSummary ID="ValidationSummaryErrors" HeaderText="Validation Errors" runat="server" ForeColor="Red" />
        </p>
        <p>
            <asp:Label ID="data_status" runat="server" ForeColor="Red"></asp:Label>
        </p>
        <table>
            <tr>
                <td>
                    <asp:Label ID="title" runat="server" Text="Title"></asp:Label>
                    <asp:TextBox ID="gradeTitle" runat="server" style="margin-left:80px;"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidatorTitle" runat="server"
                        ControlToValidate="gradetitle"
                        OnServerValidate="TitleValidation"
                        ValidateEmptyText="true">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="data-cells">
                    <asp:Label ID="maxMarkLabel" runat="server" Text="Maximum Mark"></asp:Label>
                    <asp:TextBox ID="maxMark" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidatorMaxMark" runat="server"
                        ControlToValidate="maxMark"
                        OnServerValidate="MaxMarkValidation"
                        ValidateEmptyText="true">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="save" runat="server" Text="Save" OnClick="SaveGradeSystem_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
