using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Repositorio;

namespace Concessionaria.Aplicacao.Construtores
{
    public class VendaAplicacaoConstrutor
    {   
        public static VendaAplicacao VendaAplicacaoADO()
        {
            return new VendaAplicacao(new VendaRepositorioADO());
        }
    }
}
