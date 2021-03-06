﻿var OpcionalJs = (function() {
    var url = {};

    var init = function(config) {
        url = config;
        listar();
    };

    function listar(mensagem) {
        //busca o grid
        $.get(url.listar).success(function(data) {
            $('#divGrid').html(data).slideDown(function() { //desce  o divgrid
                if (mensagem)
                    $(this).successMessage(mensagem, 5000); //informa mensagem de sucesso                
            });
        }).error(function(xhr) {
            $("#divGrid").errorMessage(xhr.responseText);
        });
    };

    var voltarInicio = function() {
        $.get(url.listar).success(function() {
            $("#divDados").slideUp(function() {
                $("#divDados").empty(); //$(this).empty();
                listar();
            }).error(function(xhr) {
                $("#divGrid").errorMessage(xhr.responseText);
            });
        });
    };

    var novoCadastro = function() {
        $.get(url.novoCadastro).success(function(data) {  //chamo a view pelo url
            $("#divGrid").slideUp(function() {  //subo a divgrid
                $("#divDados").hide().html(data).slideDown();  //escondo(hide), insiro a view buscada na divdados(html(data)), e desço ela pronta.
            });
        }).error(function(xhr) {
            $("#divGrid").errorMessage(xhr.responseText);
        });
    };

    var cadastrar = function() {
        $('#submit').prop("disabled", true);
        $.post(url.cadastrar, {
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
    };

    var novaEdicao = function(id){
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

    var editar = function() {
        $.post(url.editar,{
                Opcid: $('#Opcid').val(),
                Opcdescr: $('#Opcdescr').val()
            }).success(function(data) {
            $('#divDados').slideUp(function() {
                $('#divDados').empty();
                listar(data);
            });
        }).error(function(xhr) {
            $('#divDados').errorMessage(xhr.responseText, 5000);
        });
    }

    var detalhar = function(id) {
        $.get(url.detalhar,
            {
                id: id
            }).success(function(data) {
            $('#divGrid').slideUp(function() {
                $('#divDados').hide().html(data).slideDown();
            });
        }).error(function(xhr) {
            $('#divGrid').errorMessage(xhr.responseText);
        });
    }

    var novaExclusao = function(id) {
        $.get(url.novaExclusao,
            {
                id: id
            }).success(function(data) {
            $('#divGrid').slideUp(function() {
                $('#divDados').hide().html(data).slideDown();
            });
        }).error(function(xhr) {
            $('#divGrid').errorMessage(xhr.responseText);
        });
    }

    var excluir = function(id) {
        $.post(url.excluir,
            {
                id:id
            }).success(function(data) {
            $('#divDados').slideUp(function () {
                $('#divDados').empty();
                listar(data);
            });
        }).error(function(xhr) {
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
