using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class ClienteAplicacao
    {
        private readonly IRepositorio<Cliente> repositorio;

        public ClienteAplicacao(IRepositorio<Cliente> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Cliente cliente)
        {
            repositorio.Salvar(cliente);
        }

        public void Excluir(Cliente cliente)
        {
            repositorio.Excluir(cliente);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Cliente listarPorId(string cpf)
        {
            return repositorio.ListarPorId(cpf);
        }
    }
}
