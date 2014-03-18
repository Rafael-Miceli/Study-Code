var Subject = function () {
    var Name = Name,
    Weight = Weight;

    return {
        Name: Name,
        Weight: Weight
    };
};

var SubjectsList = function () {
    var Subjects = [];

    function Add(subject) {
        var subjects = this.Subjects;
        
        subjects.push(subject);
        window.localStorage.SubjectsList = JSON.stringify(subjects);
    }

    function Delete(subjectName) {
        var subjects = this.Subjects;
        var subjectIndex = Find(subjectName, subjects);

        if (subjectIndex > -1) {
            subjects.splice(subjectIndex, 1);
            window.localStorage.SubjectsList = JSON.stringify(subjects);
        }
    }

    function Find(subjectName, subjects) {
        
        for (var subjectIndex in subjects) {
            if (subjects[subjectIndex].Name === subjectName) {
                return subjectIndex;
            }
        }

        return -1;
    }

    function subjectExists(subjectName) {
        var subjects = this.Subjects;
        for (var subjectIndex in subjects) {
            if (subjects[subjectIndex].Name === subjectName) {
                return true;
            }
        }
    }

    function ListSubjects(gradeList) {
        var subjectList = this,
        mytable = $('<table data-role="table" data-mode="columntoggle" class="ui-responsive table-stroke ui-table ui-table-columntoggle"></table>').attr({ id: "subjectTable" }),
        select = $('<select name="selectGrade" id="selectGrade"></select>'),
        mybody = $('<tbody></tbody>'),
        myheader = $('<thead></thead>');
        
        myheader.appendTo(mytable);
        mybody.appendTo(mytable);
        
        $('#selectGrade').remove();
        $('#subjectTable').remove();
        $('.tableSubjectWarning').remove();
        
        var rows = new Number(subjectList.Subjects.length);
        var cols = new Number(3);
        
        if (rows < 1) {
            $('<span class="tableSubjectWarning">Nenhuma materia cadastrada</span><br />').appendTo("#subjectGrid");;
            return;
        }

        $('<tr><th>Materia</th><th>Peso</th><th></th></tr>').appendTo(myheader);

        for (var i = 0; i < rows; i++) {
            var row = $('<tr></tr>').appendTo(mybody);
            
            $('<option value="' + subjectList.Subjects[i].Name + '">' + subjectList.Subjects[i].Name + '</option>').appendTo(select);
            
            for (var j = 0; j < cols; j++) {
                if (j == 0) {
                    $('<td style="padding-top: 20px"></td>').text(subjectList.Subjects[i].Name).appendTo(row);
                }
                if (j == 1) {
                    $('<td style="padding-top: 20px"></td>').text(subjectList.Subjects[i].Weight).appendTo(row);
                }
                if (j ==2) {
                    $('<td field="' + subjectList.Subjects[i].Name + '" class="deleteSubject"><a data-role="button" data-icon="delete" data-iconpos="notext" class="ui-link ui-btn ui-btn-a ui-icon-delete ui-btn-icon-notext ui-btn-inline ui-shadow ui-corner-all" data-inline="true">Delete</a></td>').appendTo(row);
                }
            }
        }
        mytable.appendTo("#subjectGrid");
        select.appendTo("#selectSubjectNameContainer");
        
        $('select').selectmenu();
        $('table').grid();
        
        $('.deleteSubject').click(function () {
            var field = this.getAttribute('field');

            subjectList.Delete(field);
            gradeList.Delete(field);
            
            subjectList.List(gradeList);
            gradeList.List();
            
        });
    }

    return {
        Add: Add,
        Delete: Delete,
        Subjects: Subjects,
        Exists: subjectExists,
        Find: Find,
        List: ListSubjects
    };
};


var Grade = function () {
    var Value = Value,
    SubjectName = SubjectName;

    return {
        Value: Value,
        SubjectName: SubjectName
    };
};

var GradeList = function () {
    var Grades = [];

    function Add(grade) {
        var grades = this.Grades;

        grades.push(grade);
        window.localStorage.GradesList = JSON.stringify(grades);
    }

    function Delete(subjectName) {
        var grades = this.Grades;
        var gradeIndex = Find(subjectName, grades);

        if (gradeIndex > -1) {
            grades.splice(gradeIndex, 1);
            window.localStorage.GradesList = JSON.stringify(grades);
        }
    }

    function Find(subjectName, grades) {

        for (var gradeIndex in grades) {
            if (grades[gradeIndex].SubjectName === subjectName) {
                return gradeIndex;
            }
        }

        return -1;
    }

    function gradeExists(subjectName) {
        var grades = this.Grades;
        
        for (var gradeIndex in grades) {
            if (grades[gradeIndex].SubjectName === subjectName) {
                return true;
            }
        }
    }

    function ListGrades() {
        var gradeList = this,
        mytable = $('<table data-role="table" data-mode="columntoggle" class="ui-responsive table-stroke ui-table ui-table-columntoggle"></table>').attr({ id: "gradeTable" }),
        mybody = $('<tbody></tbody>'),
        myheader = $('<thead></thead>');

        myheader.appendTo(mytable);
        mybody.appendTo(mytable);
        

        $('#gradeTable').remove();
        $('.tableWarning').remove();

        var rows = new Number(gradeList.Grades.length);
        var cols = new Number(3);

        if (rows < 1) {
            $('<span class="tableWarning">Nenhuma nota cadastrada</span><br />').appendTo("#gradeGrid");
            return;
        }

        $('<tr><th>Materia</th><th>Nota</th><th></th></tr>').appendTo(myheader);
        

        for (var i = 0; i < rows; i++) {
            var row = $('<tr></tr>').appendTo(mybody);
            for (var j = 0; j < cols; j++) {
                if (j == 0) {
                    $('<td style="padding-top: 20px"></td>').text(gradeList.Grades[i].SubjectName).appendTo(row);
                }
                if (j == 1) {
                    $('<td style="padding-top: 20px"></td>').text(gradeList.Grades[i].Value).appendTo(row);
                }
                if (j == 2) {
                    $('<td field="' + gradeList.Grades[i].SubjectName + '" class="deleteGrade"><a data-role="button" data-icon="delete" data-iconpos="notext" class="ui-link ui-btn ui-btn-a ui-icon-delete ui-btn-icon-notext ui-btn-inline ui-shadow ui-corner-all" data-inline="true">Delete</a></td>').appendTo(row);
                }
            }
        }
        
        mytable.appendTo("#gradeGrid");

        $('.deleteGrade').click(function () {
            var field = this.getAttribute('field');

            gradeList.Delete(field);
            gradeList.List();
        });
    }

    return {
        Add: Add,
        Delete: Delete,
        Grades: Grades,
        Exists: gradeExists,
        List: ListGrades
    };
};

var _subjectsList = new SubjectsList();
var _gradesList = new GradeList(); 

function tryParseSubjectsLocalValue() {
    try {
        return JSON.parse(window.localStorage.SubjectsList);
    } catch (e) {
        return [];
    }
}

function tryParseGradesLocalValue() {
    try {
        return JSON.parse(window.localStorage.GradesList);
    } catch (e) {
        return [];
    }
}

function createSubjectArrayIfNotExists(subjectList) {

    subjectList.Subjects = tryParseSubjectsLocalValue();
    return subjectList.Subjects;
};

function createGradesArrayIfNotExists(gradeList) {

    gradeList.Grades = tryParseGradesLocalValue();
    return gradeList.Grades;
};

$(function () {

    $('.numeric').numeric({ decimal: ",", negative: false, scale: 2 });

    _subjectsList.Subjects = createSubjectArrayIfNotExists(_subjectsList);
    _gradesList.Grades = createGradesArrayIfNotExists(_gradesList);
    
    _subjectsList.List(_gradesList);
    _gradesList.List();

    $('#saveMaterial').click(function () {
        var subjectName = $('#materialName').val(),
            weight = $('#weight').val();

        if (subjectName == "") {
            window.alert('Por favor preencha o nome da matéria');
            return;
        }
        
        if (_subjectsList.Exists(subjectName)) {
            window.alert('Essa matéria já existe');
            return;
        }

        weight = weight.replace(",", ".");
        
        weight = new Number(weight);

        if (weight <= 0) {
            weight = 1;
        }

        var subject = new Subject();
        subject.Name = subjectName;
        subject.Weight = weight;

        _subjectsList.Add(subject);
        _subjectsList.List(_gradesList);
        $.mobile.changePage("#materials", { allowSamePageTransition: true });
    });

    $('#saveGrade').click(function() {
        var subjectName = $('#selectGrade').val(),
            gradeValue = $('#grade').val();
        
        if (_gradesList.Exists(subjectName)) {
            window.alert('Essa matéria já possui nota');
            return;
        }

        gradeValue = gradeValue.replace(",", ".");
        
        gradeValue = new Number(gradeValue);

        if (gradeValue < 0 || gradeValue > 100) {
            window.alert('Nota deve ser de 0 a 100');
            return;
        }

        var grade = new Grade();
        grade.SubjectName = subjectName;
        grade.Value = gradeValue;

        _gradesList.Add(grade);
        
        _gradesList.List();
        $.mobile.changePage("#grades", { allowSamePageTransition: true });
    });

    $('.goToCr').click(function () {

        var totalWeight = 0,
            totalGrades = 0,
            gradeWeight = 1,
            grade = 0,
            gradeMultiplyWeight = 0,
            cr = 0;


        for (var gradeIndex in _gradesList.Grades) {
            
            gradeWeight = _subjectsList.Subjects[_subjectsList.Find(_gradesList.Grades[gradeIndex].SubjectName, _subjectsList.Subjects)].Weight;
            totalWeight += gradeWeight;
            
            grade = _gradesList.Grades[gradeIndex].Value;
            
            gradeMultiplyWeight = grade * gradeWeight;

            totalGrades += gradeMultiplyWeight;
        }

        cr = totalGrades / totalWeight;

        $('#CrValue').remove();

        if (!cr)
            $('<h3 id="CrValue">Voce nao possui Cr</h3>').appendTo('#CrContainer');
        else
            $('<h3 id="CrValue">' + cr.toFixed(2) + '</h3>').appendTo('#CrContainer');
        
        

        $.mobile.changePage("#Cr", { allowSamePageTransition: true });
    });
});


/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
var app = {
    // Application Constructor
    initialize: function() {
        this.bindEvents();
    },
    // Bind Event Listeners
    //
    // Bind any events that are required on startup. Common events are:
    // `load`, `deviceready`, `offline`, and `online`.
    bindEvents: function() {
        document.addEventListener('deviceready', this.onDeviceReady, false);
    },
    // deviceready Event Handler
    //
    // The scope of `this` is the event. In order to call the `receivedEvent`
    // function, we must explicity call `app.receivedEvent(...);`
    onDeviceReady: function() {
        
    },
};

