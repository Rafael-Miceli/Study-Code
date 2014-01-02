<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DownloadTextFileFromGridView.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True">
        </asp:GridView>
        
        <asp:Button ID="Button1" runat="server" Text="Gerar Csv" OnClick="Button1_Click" />
    </div>
    </form>
    
</body>
</html>
