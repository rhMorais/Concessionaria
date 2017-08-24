using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class VendaAplicacao
    {
        private readonly IRepositorio<Venda> repositorio;

        public VendaAplicacao(IRepositorio<Venda> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Venda venda)
        {
            repositorio.Salvar(venda);
        }

        public void Excluir(Venda venda)
        {
            repositorio.Excluir(venda);
        }

        public IEnumerable<Venda> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Venda ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
