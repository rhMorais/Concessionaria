using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Repositorio;
namespace Concessionaria.Aplicacao.Construtores
{
    public class ClienteAplicacaoConstrutor
    {
        public static ClienteAplicacao ClienteAplicacao()
        {
            return new ClienteAplicacao(new ClienteRepositorioADO());
        }
    }
}
