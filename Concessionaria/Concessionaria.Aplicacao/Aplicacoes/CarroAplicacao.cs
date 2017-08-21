﻿using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class CarroAplicacao
    {
        private readonly ICarroRepositorio<Carro> repositorio;

        public CarroAplicacao(ICarroRepositorio<Carro> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Carro carro, int[] list)
        {
            repositorio.Salvar(carro, list);
        }

        public void Excluir(Carro carro)
        {
            repositorio.Excluir(carro);
        }

        public IEnumerable<Carro> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public IEnumerable<Carro> ListarVendidos()
        {
            return repositorio.ListarVendidos();
        }

        public Venda ListarDetalhesVendidos(string placa)
        {
            return ListarDetalhesVendidos(placa);
        }

        public Carro ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }

        public IEnumerable<Opcional> ListarOpcionaldoCarro(string id)
        {
            return ListarOpcionaldoCarro(id);
        }
    }
}
