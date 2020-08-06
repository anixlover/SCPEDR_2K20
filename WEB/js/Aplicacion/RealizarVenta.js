$(document).ready(function () {

    $("#ddl_TipoComprobante").change(function () {
        var ddlSelectedTipoComprobante = $('#ddl_TipoComprobante').val();
        console.log($('#ddl_TipoComprobante').val());
        if (ddlSelectedTipoComprobante == "1") {
            $("#divRUCHide").fadeOut();
            $("#iddecuento").fadeOut();

        } else if (ddlSelectedTipoComprobante == "2") {

            $("#divRUCHide").fadeIn();
            $("#iddecuento").fadeIn();
        }
    });


    $('input[type=radio][name=TipoPedido]').change(function () {
        if (this.value == '1') {
            $("#valorObtenidoRBTN").val('1');
        }
        else if (this.value == '2') {
            $("#valorObtenidoRBTN").val('2');
        }
        console.log($("#valorObtenidoRBTN").val());

    });


    $('input[type=radio][name=identificadorUsuario]').change(function () {
        if (this.value == '1') {
            $("#txtIdentificadorUsuario").val('');
            $('#valorObtenidoRBTN').val('1');
            //$("#txtIdentificadorUsuario").rules("add", { regex: "[0-8]+" })
            $("#txtIdentificadorUsuario").attr('minLength', '8');
            $("#txtIdentificadorUsuario").attr('maxlength', '8');
            $("#lbldnitext").text('Ingrese el DNI');

        }
        else if (this.value == '2') {
            $('#valorObtenidoRBTN').val('2');
            //$("#txtIdentificadorUsuario").rules("add", { regex: "[0-11]+" })
            $("#lbldnitext").text('Ingrese el RUC');
            $("#txtIdentificadorUsuario").val('');

            $("#txtIdentificadorUsuario").attr('minLength', '11');
            $("#txtIdentificadorUsuario").attr('maxlength', '11');
        }
    });

    $("#cbx_Catalogo").change(function () {
        var rdb = $('#cbx_Catalogo').val();
        console.log($('#cbx_Catalogo').val());
        if (rdb == "1") {
            $("#divSubAddGv").fadeIn();
            $("#CardTipoComprobante").fadeIn();
            $("#CardPayment").fadeIn();
            $("#DivCodigoSubtotal").fadeIn();
            $("#btnadd").fadeIn();
            $("#txtimportetotal").fadeIn();
            

            $("#ddlPedidoMuestra").fadeOut();
            $("#IdCalendar").fadeOut();
            $("#idMostrarbtnEnviar").fadeOut();
            $("#idTipoMoldura").fadeOut();
        }
    });

    $("#cbx_Personalizado").change(function () {
        var rdb2 = $('#cbx_Personalizado').val();
        console.log($('#cbx_Personalizado').val());
        if (rdb2 == "2") {
            $("#ddlPedidoMuestra").fadeIn();
            $("#divSubAddGv").fadeIn();

            $("#CardTipoComprobante").fadeOut();
            $("#CardPayment").fadeOut();
            $("#btnadd").fadeOut();
            $("#txtimportetotal").fadeOut();
            
        }
    });

    $("#ddlPedidoPor").change(function () {
        var ddlPedidopor = $('#ddlPedidoPor').val();
        console.log($('#ddlPedidoPor').val());
        if (ddlPedidopor == "1") {
            $("#IdCalendar").fadeIn();
            $("#idMostrarbtnEnviar").fadeIn();
            $("#DivCodigoSubtotal").fadeIn();

            $("#divSubAddGv").fadeOut();
            $("#idTipoMoldura").fadeOut();
            $("#btnagregar").fadeOut();
            $("#btnadd").fadeOut();

        } else if (ddlPedidopor == "2") {
            $("#divSubAddGv").fadeIn();
            $("#idTipoMoldura").fadeIn();

            $("#IdCalendar").fadeOut();
            $("#idMostrarbtnEnviar").fadeOut();
            $("#DivCodigoSubtotal").fadeOut();
            $("#btnadd").fadeOut();

        }
    });

    $('input[type=radio][name=TipoC]').change(function () {
        if (this.value == '1') {
            $("#valorObtenidoRBTN1").val('1');
        }
        else if (this.value == '2') {
            $("#valorObtenidoRBTN1").val('2');
        }
        console.log($("#valorObtenidoRBTN1").val());
    });


    $("#RDB_DNI").change(function () {
        var rdb1 = $('#RDB_DNI').val();
        console.log($('#RDB_DNI').val());
        if (rdb1 == "1") {
            $("#lbldni").fadeIn();

            $("#lblcde").fadeOut();            
        }
    });
    $("#RDB_CEXTRANJERIA").change(function () {
        var rdb = $('#RDB_CEXTRANJERIA').val();
        console.log($('#RDB_CEXTRANJERIA').val());
        if (rdb == "2") {
            $("#lblcde").fadeIn();

            $("#lbldni").fadeOut();
        }
    });




});

