using Concessionaria.Aplicacao.Aplicacoes;
using ConcessionariaRepositorioADO.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Aplicacao.Construtores
{
    public class ExcelConstrutor
    {

        public static ExcelAplicacao ExcelAplicacao()
        {
            return new ExcelAplicacao(new ExcelRepositorio());
        }
    }
}
