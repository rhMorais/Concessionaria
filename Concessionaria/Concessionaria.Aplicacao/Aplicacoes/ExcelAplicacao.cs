using ConcessionariaRepositorioADO.Repos;

namespace Concessionaria.Aplicacao.Aplicacoes
{

    public class ExcelAplicacao
    {
        private readonly ExcelRepositorio _repositorio;

        public ExcelAplicacao(ExcelRepositorio repo)
        {
            _repositorio = repo;
        }

        public void GerarExcel()
        {
            _repositorio.GerarExcel();
        }
    
    }
}
