using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Repositorio;

namespace Concessionaria.Aplicacao.Construtores
{
    public class CarroAplicacaoConstrutor
    {
        public static CarroAplicacao CarroAplicacao()
        {
            return new CarroAplicacao(new CarroRepositorioADO());
        }
    }
}
