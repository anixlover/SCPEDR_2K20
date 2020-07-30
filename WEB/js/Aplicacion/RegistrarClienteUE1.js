$('input[type=radio][name=documento]').change(function () {
    if (this.value == '1') {
        $("#valorObtenidoRBTN").val('1');
    }
    else if (this.value == '2') {
        $("#valorObtenidoRBTN").val('2');
    }
    console.log($("#valorObtenidoRBTN").val());
});

$("#rbdni").change(function () {
    var rdb = $('#rbdni').val();
    console.log($('#rbdni').val());
    if (rdb == "1") {
        $("#DNI").fadeIn();
        $("#Extranjero").fadeOut();
    }
});

$("#rbcarnet").change(function () {
    var rdb2 = $('#rbcarnet').val();
    console.log($('#rbcarnet').val());
    if (rdb2 == "2") {
        $("#Extranjero").fadeIn();
        $("#DNI").fadeOut();
    }
});
