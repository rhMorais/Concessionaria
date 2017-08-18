using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class LoginAplicacao
    {
        private readonly IRepositorio<Login> repositorio;

        public LoginAplicacao(IRepositorio<Login> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Login login)
        {
            repositorio.Salvar(login);
        }

        public void Excluir(Login login)
        {
            repositorio.Excluir(login);
        }

        public IEnumerable<Login> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Login listarPorId(Login login)
        {
            return repositorio.ListarPorId(login);
        }
    }
}
