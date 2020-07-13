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
});