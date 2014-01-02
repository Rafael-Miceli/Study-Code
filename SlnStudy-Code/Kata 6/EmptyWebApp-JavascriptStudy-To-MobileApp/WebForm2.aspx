<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="EmptyWebApp_JavascriptStudy_To_MobileApp.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="header">
                <h1>Notas</h1>
        </div>

        <div role="main" class="ui-content">
            <a href="#registergrade" class="ui-btn ui-corner-all ui-shadow ui-icon-plus ui-btn-icon-left ui-btn-a ui-btn-inline">cadastrar nota</a>
        </div>

        <div data-role="footer" data-position="fixed" >
            <div data-role="navbar">
                <ul>
                    <li>
                        <a href="#materials" data-icon="bullets">Matérias</a>
                    </li>
                    <li>
                        <a href="#grades" style="background-color: #3388cc; border-color: #3388cc; color: #fff; text-shadow: 0 1px oldlace #005599;" data-icon="check">Notas</a>
                    </li>
                    <li>
                        <a href="#Cr" data-icon="recycle">Cálculo</a>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
