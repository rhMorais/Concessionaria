using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class OpcinalAplicacao
    {
        private readonly IRepositorio<Opcional> repositorio;

        public OpcinalAplicacao(IRepositorio<Opcional> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Opcional opcional)
        {
            repositorio.Salvar(opcional);
        }

        public void Excluir(Opcional opcional)
        {
            repositorio.Excluir(opcional);
        }

        public IEnumerable<Opcional> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Opcional ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
