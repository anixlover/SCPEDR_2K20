function modal(idModal) {
    $('#' + idModal).modal('show');
}
$(".letrasnumeros").keypress(function (key) {
    if ((key.charCode < 97 || key.charCode > 122)//letras mayusculas
        && (key.charCode < 65 || key.charCode > 90) //letras minusculas
        && (key.charCode != 45) //retroceso
        && (key.charCode != 241)
        && (key.charCode != 209)
        && (key.charCode != 32) //espacio
        && (key.charCode != 225)
        && (key.charCode != 233)
        && (key.charCode != 237)
        && (key.charCode != 243)
        && (key.charCode != 250)
        && (key.charCode != 193)
        && (key.charCode != 201)
        && (key.charCode != 205)
        && (key.charCode != 211)
        && (key.charCode != 218)
        && (key.charCode != 48)
        && (key.charCode != 49)
        && (key.charCode != 50)
        && (key.charCode != 51)
        && (key.charCode != 52)
        && (key.charCode != 53)
        && (key.charCode != 53)
        && (key.charCode != 55)
        && (key.charCode != 56)
        && (key.charCode != 57)
        && (key.charCode != 220)
        && (key.charCode != 252)
    )
        return false;
});
$(".letras").keypress(function (key) {
    if ((key.charCode < 97 || key.charCode > 122)//letras mayusculas
        && (key.charCode < 65 || key.charCode > 90) //letras minusculas
        && (key.charCode != 45) //retroceso
        && (key.charCode != 241)
        && (key.charCode != 209)
        && (key.charCode != 32) //espacio
        && (key.charCode != 225)
        && (key.charCode != 233)
        && (key.charCode != 237)
        && (key.charCode != 243)
        && (key.charCode != 250)
        && (key.charCode != 193)
        && (key.charCode != 201)
        && (key.charCode != 205)
        && (key.charCode != 211)
        && (key.charCode != 218)
        && (key.charCode != 220)
        && (key.charCode != 252)
    )
        return false;
});
$(".numeros").keypress(function (key) {
    if (key.charCode < 48 || key.charCode > 57)
        return false;
});
$(".decimales").keypress(function (tecla) {
    if ((tecla.charCode < 48 || tecla.charCode > 57) && (tecla.charCode != 46) && (tecla.charCode != 8)) {
        return false;
    }
});
$(".decimales2").keypress(function (tecla) {
    if ((tecla.charCode < 48 || tecla.charCode > 57) && (tecla.charCode != 46) && (tecla.charCode != 8)) {
        return false;
    } else {
        var len = $('.decimales2').val().length;
        var index = $('.decimales2').val().indexOf('.');

        if (index > 0 && tecla.charCode == 46) {
            return false;
        }
        if (index > 0) {
            var CharAfterdot = (len + 1) - index;
            if (CharAfterdot > 3) {
                return false;
            }
        }
    }
    return true;
});
$(".numeros").keypress(function (key) {
    if (key.charCode < 48 || key.charCode > 57)
        return false;
});
$(".decimales").keypress(function (tecla) {
    if ((tecla.charCode < 48 || tecla.charCode > 57) && (tecla.charCode != 46) && (tecla.charCode != 8)) {
        return false;
    }
});
$(".decimales2").keypress(function (tecla) {
    if ((tecla.charCode < 48 || tecla.charCode > 57) && (tecla.charCode != 46) && (tecla.charCode != 8)) {
        return false;
    } else {
        var len = $('.decimales2').val().length;
        var index = $('.decimales2').val().indexOf('.');

        if (index > 0 && tecla.charCode == 46) {
            return false;
        }

        if (index > 0) {
            var CharAfterdot = (len + 1) - index;
            if (CharAfterdot > 3) {
                return false;
            }
        }
    }
    return true;
});