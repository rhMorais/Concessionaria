using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Aplicacao.Aplicacoes
{
    public class LoginAplicacao
    {
        private readonly ILoginRepositorio repositorio;

        public LoginAplicacao(ILoginRepositorio repo)
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

        public Login ListarPorId(string usuario)
        {
            return repositorio.ListarPorId(usuario);
        }

        public bool AutenticarUsuario(Login login)
        {
            return repositorio.AutenticarUsuario(login);
        }
    }
}
