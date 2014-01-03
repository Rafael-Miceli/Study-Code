<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmptyWebApp_JavascriptStudy_To_MobileApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.8.2.js"></script>
    <script>
        var Subject = function() {
            var Name = Name,
                Weight = Weight;

            return {
                Name: Name,
                Weight: Weight
            };
        };

        $(function () {
            var subjectDip = new Subject();
            subjectDip.Name = "DIP";
            subjectDip.Weight = 2;
            
            var subjectEda = new Subject();
            subjectEda.Name = "EDA";
            subjectEda.Weight = 2;
            
            var subjectDipr = new Subject();
            subjectDipr.Name = "DIPR";
            subjectDipr.Weight = 4;


            var Subjects = [subjectDip, subjectDipr, subjectEda];
            

            document.write(JSON.stringify(Subjects))


            //$('#cadastrar').click(
            //    function() {

            //    });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" id="txtName"/>
        <input type="text" id="txtWeight"/>
        <button id="cadastrar" value="Cadastrar"></button>
    </div>
    </form>
</body>
</html>
