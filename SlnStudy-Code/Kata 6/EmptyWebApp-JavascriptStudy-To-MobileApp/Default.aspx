<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmptyWebApp_JavascriptStudy_To_MobileApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Default.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="header">
                <h1>Matérias</h1>
        </div>
            
        <div role="main" class="ui-content">
            <a href="#registermaterial" class="ui-btn ui-corner-all ui-shadow ui-icon-plus ui-btn-icon-left ui-btn-a ui-btn-inline">cadastrar matéria</a>
            
            <div id="registermaterial" data-role="page">
            <div data-role="header">
                <a class="ui-btn-left ui-btn ui-btn-inline ui-mini ui-corner-all ui-btn-icon-left ui-icon-delete" href="#materials">Cancelar</a>
                <h1></h1>
                <button id="saveMaterial" class="ui-btn-right ui-btn ui-btn-a ui-btn-inline ui-mini ui-corner-all ui-btn-icon-right ui-icon-check">Cadastrar</button>
            </div>
            <br/>
            <form>
                <label for="materialName">Nome da Matéria</label>
                <input name="materialName" id="materialName" type="text" value="" data-clear-btn="true">
                <label for="weight">Peso</label>
                <input name="weight" id="weight" type="number" pattern="[1-9]*" value="1" data-clear-btn="true">
            </form>
        </div>
        </div>

        <div data-role="footer" data-position="fixed">
            <div data-role="navbar">
                <ul>
                    <li>
                        <a href="#materials" style="background-color: #3388cc; border-color: #3388cc; color: #fff; text-shadow: 0 1px oldlace #005599;" data-icon="bullets">Matérias</a>
                    </li>
                    <li>
                        <a href="#grades" data-icon="check">Notas</a>
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
