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
            
            function subjectExists(subjectName) {
                var subjects = this.Subjects;
                for (var subjectIndex in subjects) {
                    if (subjects[subjectIndex].Name === subjectName) {
                        return true;
                    }
                }
            }
            
            function ListSubjects() {
                var subjectList = this,
                mytable = $('<table data-role="table" class="ui-responsive table-stroke ui-table ui-table-reflow"></table>').attr({ id: "gradeTable" }),
                mybody = $('<tbody></tbody>'),
                myheader = $('<thead></thead>');

                myheader.appendTo(mytable);
                mybody.appendTo(mytable);

                $('#gradeTable').remove();

                var rows = new Number(subjectList.Subjects.length);
                var cols = new Number(3);
                
                if (rows < 1) {
                    $('<span>Nenhuma nota cadastrada</span><br />');
                    return;
                }

                $('<tr><th>Materia</th><th>Nota</th><th></th></tr>').appendTo(myheader);

                for (var i = 0; i < rows; i++) {
                    var row = $('<tr></tr>').appendTo(mybody);
                    for (var j = 0; j < cols; j++) {
                        if (j == 0) {
                            $('<td></td>').text(subjectList.Subjects[i].Name).appendTo(row);
                        }
                        if (j == 1) {
                            $('<td></td>').text(subjectList.Subjects[i].Weight).appendTo(row);
                        }
                        if (j == 2) {
                            $('<td field="' + subjectList.Subjects[i].Name + '" class="delete"><img src="logo.png" /></td>').appendTo(row);
                        }
                    }
                }
                mytable.appendTo("#subjectGrid");
                
                $('.delete').click(function () {
                    var field = this.getAttribute('field');

                    subjectList.Remove(field);
                    subjectList.Listar();
                });
            }

            return {
                Subjects: Subjects,
                Add: addSubject,
                Remove: removeSubject,
                Find: findSubject,
                List: listSubjects,
                Listar: ListSubjects,
                Exists: subjectExists
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

            _subjectList.Listar();
            
            //$('.delete').click(function () {
            //    var field = this.getAttribute('field');

            //    alert(field);

            //    _subjectList.Remove(field);
            //    _subjectList.Listar();
            //});

            //if (_subjectList.Remove('DIP')) {
            //    alert('Removido');
            //} else {
            //    alert('Não removido');
            //}

            //if (_subjectList.Exists('EPA')) {
            //    alert('Matéria EDA existe');
            //}

            //_subjectList.Listar();

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
        <div id="subjectGrid">
        </div>
    </form>
</body>
</html>
