using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class CarroAplicacao
    {
        private readonly IRepositorio<Carro> repositorio;

        public CarroAplicacao(IRepositorio<Carro> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Carro carro)
        {
            repositorio.Salvar(carro);
        }

        public void Excluir(Carro carro)
        {
            repositorio.Excluir(carro);
        }

        public IEnumerable<Carro> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Carro listarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
