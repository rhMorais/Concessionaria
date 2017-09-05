var OpcionalJs = (function() {

    var listar = (function get(mensagem) {
        //busca o grid

        //dentro do success
        $('#divGrid').slideDown(function () {
            if (mensagem)
                $(this).successMessage(mensagem, 5000);
        });
        return get;
    })();

    var novoCadastro = function(url) {
        $.get(url).success(function(data) {
            $("#divGrid").slideUp(function() {
                $("#divDados").hide().html(data).slideDown();
            });
        }).error(function(xhr) {
            $("#divGrid").errorMessage(xhr.responseText);
        });
    };

    var cadastrar = function(url) {
        $('#submit').prop("disabled", true);
        $.post(url, {
            Opcdescr: $('#Opcdescr').val()
        }).success(function (data) {
            $("#divDados").slideUp(function() {
                $("#divDados").empty(); //$(this).empty();
                listar(data);
            });
        }).error(function (xhr) {
            $('#divDados').errorMessage(xhr.responseText, 5000);
        }).complete(function () {
            $('#submit').prop("disabled", false);
        });
        return false;
    };

    return {
        novoCadastro: novoCadastro,
        cadastrar: cadastrar
    };
})();

function EditarOpcional() {
    $.post(("/Opcional/EditarOpcional"), { Opcid: $('#Opcid').val(), Opcdescr: $('#Opcdescr').val() }).success(function (data) {
        $('#Msgopcional').successMessage(data, 5000);
        $('#Opcdescr').val("");
    }).error(function (xhr) {
        $('#Msgopcional').errorMessage(xhr.responseText, 5000);
    }).complete(function () {
        $('#submit').prop("disabled", false);
    });
    return false; //não recarregar a página. 
}

function vlDescricao() {
    var descr = $("#Opcdescr");
    
    if (descr.val().length > 25 || descr.val().length < 3) {
        $("#submit").prop("disabled", true);
        descr.focus();
        $('#ErroOpcdescr').errorMessage("A descrição deve ser maior que 2 e menor que 25 caracters", 5000);
    } else {        
        $("#submit").prop("disabled", false);
        $("#submit").focus();
    }
}
