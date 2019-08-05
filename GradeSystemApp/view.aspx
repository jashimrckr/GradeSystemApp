<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="GradeSystemApp.view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grade Details</title>
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" runat="server" />
</head>
<body>
    <form runat="server">

        <div class="gradeSystemBlock">
            <div style="display: flex; margin-bottom:5px">
                <div>
                    <asp:Button runat="server" Text="Home" OnClick="home_Click" />
                </div>

                <div style="margin-left: 10px">
                    <asp:Button runat="server" Text="Add" OnClick="add_Click"/>
                </div>
            </div>
            

            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="false"
                BackColor="#DEBA84" BorderColor="#DEBA84" 
                BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" CellSpacing="2" 
               >
                <Columns>
  
                <asp:BoundField DataField="Min" HeaderText="Min" SortExpression="Min" />
                <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="delete_btn" Text="Delete" runat="server" CommandArgument='<%# Eval("GD_id") %>' OnClick="delete_btn_Click"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />

            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
