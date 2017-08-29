// MÁSCARAS; 
jQuery( function ($) {
    $('#Clicpf').mask('000.000.000-00');
    $('#Clitelef').mask('(00)00000-0000');
});



//ESPECIFICACAO DE CARACTERES
function Nums(string) {
    var evt = window.event;
    var tec = evt.keyCode;
    
    if (tec < 48 || tec > 57) {        
        evt.preventDefault();
        $(string).errorMessage("Só é permitido numeros neste campo!", 5000);
    }
}

function NumsNChars(string) {
    var evt = window.event;
    var tec = evt.keyCode;
    console.log(tec);
    if (!((tec == 44) || (tec == 32) || (tec > 47 && tec < 58) ||
        (tec > 64 && tec < 91) || (tec > 96 && tec < 123))) {        
        evt.preventDefault();
        $(string).errorMessage("Só é permitido numeros ou letras neste campo!", 5000);
    }
}

function Chars(string) {
    var evt = window.event;
    var tec = evt.keyCode;    
    if (!((tec == 32) ||
        ((tec > 64) && (tec < 91)) ||
        ((tec > 96) && (tec < 123)))) {        
        evt.preventDefault();
        $(string).errorMessage("Só é permitido letras neste campo!", 5000);
    }
}
