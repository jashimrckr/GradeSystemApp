<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GradeSystemApp.Home" EnableEventValidation="true" %>

<head runat="server">
    <title>Grade Details</title>
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" runat="server" />
</head>
<body>
    <form runat="server">
        <div class="gradeSystemBlock">
            <p>
                <asp:Label ID="data_status" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <asp:Button ID="add" runat="server" OnClick="addGradeSystem_Click" Style="float: right;" Text="Add new Grade System" />
            <br />

            <asp:Repeater ID="gradeSystemRepeater" runat="server">
                <HeaderTemplate>Grade Systems: </HeaderTemplate>
                <ItemTemplate>
                    <table style="border: 1px solid #A55129; background-color: #FFF7E7">
                        <tr>
                            <td style="width: 200px">
                                <asp:Label ID="gradeSystemName" runat="server" Text='<%#Eval("GradeSystemName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="viewGrade" runat="server" Text="View" CommandArgument='<%#Eval("GS_id")%>' onClick="view_Click" />
                            </td>
                            <td>
                                <asp:Button ID="manage" runat="server" Text="Manage" CommandArgument='<%#Eval("GS_id")%>' onClick="manage_Click" />
                            </td>
                            <td>
                                <asp:Button ID="delete" runat="server" Text="Delete" CommandArgument='<%#Eval("GS_id")%>' OnClick="DeleteRow" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
