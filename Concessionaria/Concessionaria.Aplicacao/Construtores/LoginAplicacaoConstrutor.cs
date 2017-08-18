using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Repositorio;

namespace Concessionaria.Aplicacao.Construtores
{
    public class LoginAplicacaoConstrutor
    {
        public static LoginAplicacao LoginAplicacao()
        {
            return new LoginAplicacao(new LoginRepositorioADO());
        }
    }
}
