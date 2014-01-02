$(function () {
    


    $('#saveMaterial').click(function () {
        var materialName = $('#materialName').val(),
            weight = $('#weight').val();

        if (materialName.text == "") {
            window.alert('Por favor preencha um nome da matéria');
        }

        if (weight <= 0) {
            weight = 1;
        }

        Material.add(materialName, weight);
    });

});

var Material = function () {

    var Name,
        Weigth;

    function addMaterial(name, weight) {

    }

    return {
        add: addMaterial
    };
};