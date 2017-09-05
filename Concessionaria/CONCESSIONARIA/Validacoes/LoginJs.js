var LoginJs = (function () {
    var url = {};

    var init = function (config) {
        url = config;
        listar();
    };

    function listar(mensagem) {
        //busca o grid
        $.get(url.listar).success(function (data) {
            $('#divGrid').html(data).slideDown(function () { //desce  o divgrid
                if (mensagem)
                    $(this).successMessage(mensagem, 5000); //informa mensagem de sucesso                
            });
        }).error(function (xhr) {
            $("#divGrid").errorMessage(xhr.responseText);
        });
    };

    var voltarInicio = function () {
        $.get(url.listar).success(function () {
            $("#divDados").slideUp(function () {
                $("#divDados").empty(); //$(this).empty();
                listar();
            }).error(function (xhr) {
                $("#divGrid").errorMessage(xhr.responseText);
            });
        });
    };

    var novoCadastro = function () {
        $.get(url.novoCadastro).success(function (data) {  //chamo a view pelo url
            $("#divGrid").slideUp(function () {  //subo a divgrid
                $("#divDados").hide().html(data).slideDown();  //escondo(hide), insiro a view buscada na divdados(html(data)), e desço ela pronta.
            });
        }).error(function (xhr) {
            $("#divGrid").errorMessage(xhr.responseText);
        });
    };

    var cadastrar = function () {
        $('#submit').prop("disabled", true);
        $.post(url.cadastrar, {
            Opcdescr: $('#Opcdescr').val()
        }).success(function (data) {
            $("#divDados").slideUp(function () {
                $("#divDados").empty(); //$(this).empty();
                listar(data);
            });
        }).error(function (xhr) {
            $('#divDados').errorMessage(xhr.responseText, 5000);
        }).complete(function () {
            $('#submit').prop("disabled", false);
        });
    };

    var novaEdicao = function (id) {
        $.get(url.novaEdicao,
            {
                id: id
            }).success(function (data) {
            $("#divGrid").slideUp(function () {
                $("#divDados").hide().html(data).slideDown();
            });
        }).error(function (xhr) {
            $("#divGrid").errorMessage(xhr.responseText);
        });
    }

    var editar = function () {
        $.post(url.editar, {
            Opcid: $('#Opcid').val(),
            Opcdescr: $('#Opcdescr').val()
        }).success(function (data) {
            $('#divDados').slideUp(function () {
                $('#divDados').empty();
                listar(data);
            });
        }).error(function (xhr) {
            $('#divDados').errorMessage(xhr.responseText, 5000);
        });
    }

    var detalhar = function (id) {
        $.get(url.detalhar,
            {
                id: id
            }).success(function (data) {
            $('#divGrid').slideUp(function () {
                $('#divDados').hide().html(data).slideDown();
            });
        }).error(function (xhr) {
            $('#divGrid').errorMessage(xhr.responseText);
        });
    }

    var novaExclusao = function (id) {
        $.get(url.novaExclusao,
            {
                id: id
            }).success(function (data) {
            $('#divGrid').slideUp(function () {
                $('#divDados').hide().html(data).slideDown();
            });
        }).error(function (xhr) {
            $('#divGrid').errorMessage(xhr.responseText);
        });
    }

    var excluir = function (id) {
        $.post(url.excluir,
            {
                id: id
            }).success(function (data) {
            $('#divDados').slideUp(function () {
                $('#divDados').empty();
                listar(data);
            });
        }).error(function (xhr) {
            $('#divDados').errorMessage(xhr.responseText);
        });
    }


    return {
        init: init,
        voltarInicio: voltarInicio,
        novoCadastro: novoCadastro,
        cadastrar: cadastrar,
        novaEdicao: novaEdicao,
        editar: editar,
        detalhar: detalhar,
        novaExlusao: novaExclusao,
        excluir: excluir
    };
})();


function vlUsuario() {
    var usuar = $("#Logusuar");
    if (usuar.val().length > 12 || usuar.val().length < 4) {        
        usuar.focus();
        $('#ErroLogusuar').errorMessage("A usuário é obrigatório e deve conter entre 4 e 12 letras", 5000);
    } else {        
        $("#Logsenha").focus();
    }
};

function vlSenha() {
    var senha = $("#Logsenha");
    if (senha.val().length > 12 || senha.val().length < 4) {
        //$("#submit").prop("disabled", true);
        senha.focus();
        $('#ErroLogsenha').errorMessage("A senha é obrigatória e deve conter entre 4 e 12 caracteres", 5000);
    } else {
        $("#submit").prop("disabled", false);
        $("#submit").focus();
    }
}