<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="GradeSystemApp.manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grade Details</title>
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
    <script src="JavaScript.js" type="text/javascript"></script>
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
                <asp:Label ID="validation_status" runat="server" ForeColor="Red"></asp:Label>
            </p>

            <p>
                <asp:Label ID="data_status" runat="server" ForeColor="Red"></asp:Label>
            </p>

            <p>
                <asp:Label runat="server" ID="heading"></asp:Label>
            </p>

            <div>
                <table id="tblPets" class="custom-tablePopup">
                    <tr>
                        <th>Min</th>
                        <th>Max</th>
                        <th>Grade</th>
                        <th></th>
                    </tr>

                    <tr>
                        <td><input type="number" id="min0" name="minInput" /></td>
                        <td><input type="number" id="max0" name="maxInput" /></td>
                        <td><input type="text" id="grade0" name="gradeInput" /></td> 
                        <td><input type="button" id="addButton0" value="+" onclick="addRow('tblPets')" /></td>       
                    </tr>
                </table>
            </div>

            <div>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
</body>
</html>
