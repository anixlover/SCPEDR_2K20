$('input[type=radio][name=TipoPedido]').change(function () {
    if (this.value == '1') {
        $("#valorObtenidoRBTN").val('1');
    }
    else if (this.value == '2') {
        $("#valorObtenidoRBTN").val('2');
    }
    console.log($("#valorObtenidoRBTN").val());

});


$("#rbCatalogo").change(function () {
    var rdb = $('#rbCatalogo').val();
    console.log($('#rbCatalogo').val());
    if (rdb == "1") {
        $("#catalogo").fadeIn();

        $("#personalizado").fadeOut();
    }
});

$("#rbPropio").change(function () {
    var rdb2 = $('#rbPropio').val();
    console.log($('#rbPropio').val());
    if (rdb2 == "2") {
        $("#personalizado").fadeIn();
        $("#catalogo").fadeOut();
    }
});

