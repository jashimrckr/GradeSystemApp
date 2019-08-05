<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="GradeSystemApp.manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grade Details</title>
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
</head>
<body>
    <form runat="server">
        <div class="gradeSystemBlock">
            
            <div style="display: flex">
                <div>
                    <asp:Button runat="server" Text="Home" OnClick="home_Click" />
                </div>

                <div style="margin-left: 10px">
                    <asp:Button runat="server" Text="View" OnClick="view_Click" />
                </div>
            </div>
            
            <p>
                <asp:ValidationSummary ID="ValidationSummaryErrors" HeaderText="Validation Errors" runat="server" ForeColor="Red" />
            </p>

            <p>
                <asp:Label ID="data_status" runat="server" ForeColor="Red"></asp:Label>
            </p>

            <p><asp:Label runat="server" ID="heading"></asp:Label></p>

            <table>

                <tr>
                    <td class="data-cells">

                        <asp:Label ID="minLabel" runat="server" Text="Min"></asp:Label>
                        <asp:TextBox ID="min" runat="server" ToolTip="Enter Minimum Mark"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidatorMin" runat="server"
                            ControlToValidate="min"
                            OnServerValidate="MinValidation"
                            ValidateEmptyText="true">*</asp:CustomValidator>
                    </td>

                    <td class="data-cells">
                        <asp:Label ID="maxLabel" runat="server" Text="Max"></asp:Label>
                        <asp:TextBox ID="max" runat="server" ToolTip="Enter Maximum Mark"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidatorMax" runat="server"
                            ControlToValidate="max"
                            OnServerValidate="MaxValidation"
                            ValidateEmptyText="true">*</asp:CustomValidator>
                        <asp:CompareValidator ID="CompareMinMax" runat="server"
                            ErrorMessage="Maximum mark should be greater than Minimum Mark"
                            ControlToValidate="max"
                            ControlToCompare="min"
                            Operator="GreaterThan"
                            Type="Integer">*</asp:CompareValidator>
                    </td>

                    <td class="data-cells">
                        <asp:Label ID="gradeLabel" runat="server" Text="Grade"></asp:Label>
                        <asp:TextBox ID="grade" runat="server" ToolTip="Enter Grade"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidatorGrade" runat="server"
                            ControlToValidate="grade"
                            OnServerValidate="GradeValidation"
                            ValidateEmptyText="true">*</asp:CustomValidator>
                    </td>

                </tr>

            </table>


            <p>
                <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
            </p>

        </div>
    </form>
</body>
</html>
