using Concessionaria.Dominio;
using Concessionaria.Repositorio;
using OfficeOpenXml;
using System;
using System.IO;

namespace ConcessionariaRepositorioADO.Repos
{
    public class ExcelRepositorio
    {
        public void GerarExcel()
        {
            FileInfo caminhoArquivo = new FileInfo(@"C:\Users\Rafael\Desktop\ExcelGerado\" + DateTime.Now.Ticks);
            using(ExcelPackage arquivoExcel = new ExcelPackage(caminhoArquivo))
            {
                GerarVendas(arquivoExcel);
                //return arquivoExcel;
            }
            
        }


        private ExcelWorksheet GerarVendas(ExcelPackage arquivoExcel)
        {
            VendaRepositorioADO appVendas = new VendaRepositorioADO();
            var vendas = appVendas.ListarTodos();

            using (ExcelWorksheet planilha = arquivoExcel.Workbook.Worksheets.Add("Vendas")) {

                planilha.Cells["A1"].Value = "Vendas Concessionária";

                int linha = 1, coluna = 1;

                planilha.Cells[linha++, coluna].Value = "Relação de vendas";
                linha++;

                foreach (Venda venda in vendas)
                {
                    coluna = 1;
                    planilha.Cells[linha, coluna++].Value = venda.Venid;
                    planilha.Cells[linha, coluna++].Value = venda.Carro.Carplaca;
                    planilha.Cells[linha, coluna++].Value = venda.Carro.Carmodel;
                    planilha.Cells[linha, coluna++].Value = venda.Cliente.Clinome;
                    planilha.Cells[linha, coluna++].Value = venda.Vendatav;
                    planilha.Cells[linha, coluna++].Value = venda.Venvalor;
                    linha++;
                }

                arquivoExcel.Save();
                arquivoExcel.Dispose();
                return planilha;

            }            
        }
    }
}
