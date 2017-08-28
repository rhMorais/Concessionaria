function Chars() {
    evt = window.event;
    var tecla = evt.keyCode;

    if (!(tecla > 64 && tec < 91) ||
        (tecla > 96 && tecla < 123)) {
        alert('Precione apenas letras');
        evt.preventDefault();
    }
}

function Nums() {
    evt = window.event;
    var tecla = evt.keyCode;

    if (tecla < 48 || tecla > 57) {
        alert('Pressione apenas numeros');
        evt.preventDefault();
    }
}

function NumsNChars() {
    evt = window.event;
    var tec = evt.keyCode;
    if(!((tec == 44) || (tec == 32)|| (tec > 48 && tec < 57) ||
        (tec > 64 && tec < 91) || 
        (tec > 96 && tec < 122)
        )) {
        alert('Pressione letras ou numeros');
        evt.preventDefault();
    }
}