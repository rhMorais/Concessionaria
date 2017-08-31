using ConcessionariaRepositorioADO.Repos;

namespace Concessionaria.Aplicacao.Aplicacoes
{

    public class ExcelAplicacao
    {
        private readonly ExcelRepositorio repositorio;

        public ExcelAplicacao(ExcelRepositorio repo)
        {
            repositorio = repo;
        }

        public void GerarExcel()
        {
            repositorio.GerarExcel();
        }
    
    }
}
