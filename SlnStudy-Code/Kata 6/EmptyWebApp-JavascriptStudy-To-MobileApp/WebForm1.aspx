<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmptyWebApp_JavascriptStudy_To_MobileApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.8.2.js"></script>
    <script>

        var _subjects = 'DIP';

        var Subject = function() {
            var Name = Name,
                Weight = Weight;

            return {
                Name: Name,
                Weight: Weight
            };
        };

        var SubjectList = function() {
            var Subjects = [];

            function addSubject(subject) {
                Subjects.push(subject);
                _subjects = JSON.stringify(Subjects);
            }

            function findSubject(subjectName) {
                for (var subjectIndex in Subjects) {
                    if (Subjects[subjectIndex].Name === subjectName) {
                        return subjectIndex;
                    }
                }
            }

            function removeSubject(subjectName) {
                var subjectIndex = findSubject(subjectName);
                if (subjectIndex) {
                    Subjects.splice(subjectIndex, 1);
                    _subjects = JSON.stringify(Subjects);
                    return true;
                }
            }
            
            function listSubjects() {
                var subjects = JSON.parse(_subjects);
                for (var subjectIndex in subjects) {
                    document.writeln(subjects[subjectIndex].Name);
                }
            }

            return {
                Subjects: Subjects,
                Add: addSubject,
                Remove: removeSubject,
                Find: findSubject,
                List: listSubjects
            };
        };

        var subjectList = new SubjectList();

        function tryParseLocalValue() {
            try {
                subjectList.Subjects = JSON.parse(_subjects);
            } catch (e) {
                _subjects = '[]';
                subjectList.Subjects = JSON.parse(_subjects);
            }
        }    

        $(function () {

            var subjectDip = new Subject();
            subjectDip.Name = 'DIP';
            subjectDip.Weight = 2;
            
            var subjectDipr = new Subject();
            subjectDipr.Name = 'DIPR';
            subjectDipr.Weight = 2;
            
            var subjectEda = new Subject();
            subjectEda.Name = 'EDA';
            subjectEda.Weight = 4;
            
            tryParseLocalValue();

            subjectList.Add(subjectDip);
            subjectList.Add(subjectDipr);
            subjectList.Add(subjectEda);

            subjectList.List();

            if (subjectList.Remove('DIP')) {
                document.writeln('Removido');
            } else {
                document.writeln('Não removido');
            }
            
            subjectList.List();
            

           
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
