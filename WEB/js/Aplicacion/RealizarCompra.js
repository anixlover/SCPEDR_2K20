$('input[type=radio][name=pago]').change(function () {
    if (this.value == '1') {
        $("#valorObtenidoRBTN").val('1');
    }
    else if (this.value == '2') {
        $("#valorObtenidoRBTN").val('2');
    }
    console.log($("#valorObtenidoRBTN").val());
});

$("#rbBoleta").change(function () {
    var rdb = $('#rbBoleta').val();
    console.log($('#rbBoleta').val());
    if (rdb == "1") {
        $("#RUC").fadeOut();
    }
});

$("#rbFactura").change(function () {
    var rdb2 = $('#rbFactura').val();
    console.log($('#rbFactura').val());
    if (rdb2 == "2") {
        $("#RUC").fadeIn();
        $("#ddlRUCs").fadeIn();
    }
});
2

$('#checkRUC').click(function () {
    if ($('#checkRUC').is(':checked')) {
        $('#newRUC').fadeIn();
        $('#ddlRUCs').fadeOut();
        $("#valorCheck").val('3');
        console.log($("#valorCheck").val());
    } else {       
        $('#newRUC').fadeOut();
        $('#ddlRUCs').fadeIn();
        $("#valorCheck").val('4');
        console.log($("#valorCheck").val());
    }
});