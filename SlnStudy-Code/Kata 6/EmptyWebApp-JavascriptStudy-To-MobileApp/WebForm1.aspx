<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmptyWebApp_JavascriptStudy_To_MobileApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.8.2.js"></script>
    <script>

        var _subjectsStorage = '[{"Name" : "ECA", "Weight" : 1}]';

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
                this.Subjects.push(subject);
                _subjectsStorage = JSON.stringify(Subjects);
            }

            function findSubject(subjectName, object) {
                for (var subjectIndex in object.Subjects) {
                    if (object.Subjects[subjectIndex].Name === subjectName) {
                        return subjectIndex;
                    }
                }
            }

            function removeSubject(subjectName) {
                var subjectIndex = findSubject(subjectName, this);
                if (subjectIndex) {
                    this.Subjects.splice(subjectIndex, 1);
                    _subjectsStorage = JSON.stringify(this.Subjects);
                    return true;
                }
            }
            
            function listSubjects() {
                var subjects = this.Subjects; //JSON.parse(_subjects);
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

        function tryParseLocalValue(subjectList) {
            try {
                subjectList.Subjects = JSON.parse(_subjectsStorage);
                return subjectList.Subjects;
            } catch (e) {
                _subjectsStorage = '[]';
                subjectList.Subjects = JSON.parse(_subjectsStorage);
                return subjectList.Subjects;
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
            
            var _subjectList = new SubjectList();
            
            _subjectList.Subjects = tryParseLocalValue(_subjectList);

            _subjectList.Add(subjectDip);
            _subjectList.Add(subjectDipr);
            _subjectList.Add(subjectEda);

            _subjectList.List();

            if (_subjectList.Remove('DIP')) {
                document.writeln('Removido');
            } else {
                document.writeln('Não removido');
            }
            
            _subjectList.List();
           
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
