using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Repositorio;

namespace Concessionaria.Aplicacao.Construtores
{
    public class OpcionalAplicacaoConstrutor
    {   
        public static OpcinalAplicacao OpcionalAplicacao()
        {
            return new OpcinalAplicacao(new OpcionalRespositorioADO());
        }
    }
}
