

function Nums() {
    var evt = window.event;
    var tec = evt.keyCode;

    if (tec < 48 || tec > 57) {
        alert('Pressione apenas numeros');
        evt.preventDefault();
    }
}

function NumsNChars() {
    var evt = window.event;
    var tec = evt.keyCode;
    // console.log(tec.keyCode);
    if (!((tec == 44) || (tec == 32) || (tec > 48 && tec < 57) ||
        (tec > 64 && tec < 91) || (tec > 96 && tec < 122))) {
        alert('Pressione letras ou numeros');
        evt.preventDefault();
    }
}

function Chars() {
    var evt = window.event;
    var tec = evt.keyCode;
    console.log(tec.keyCode);
    if (!(
        (tec == 32) ||
        ((tec > 64) && (tec < 91)) ||
        ((tec > 96) && (tec < 123))
        )) {
        alert('Pressione apenas letras');
        evt.preventDefault();
    }
}