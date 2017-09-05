using Concessionaria.Dominio;
using Concessionaria.Repositorio;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace ConcessionariaRepositorioADO.Repos
{
    public class ExcelRepositorio
    {
        private ExcelPackage _ep;

        public byte[] GerarExcel()
        {
            _ep = new ExcelPackage();

            GerarVendas();
            GerarCarros();
            GerarClientes();

            return _ep.GetAsByteArray();
        }

        public byte[] GerarExcelVenda()
        {
            _ep = new ExcelPackage();
            GerarVendas();

            return _ep.GetAsByteArray();
        }

        private void GerarVendas()
        {
            VendaRepositorioADO appVendas = new VendaRepositorioADO();
            var vendas = appVendas.ListarTodos();

            ExcelWorksheet planilha = _ep.Workbook.Worksheets.Add("Vendas");

            planilha.Cells["A1"].Value = "Vendas Concessionária";                

            int linha = 1, coluna = 1;          // letra    =   coluna
            linha++;                            // numero   =   linha
            planilha.Cells[++linha, 2].Value = "Relação de vendas"; //b2    
            planilha.Cells[3,2,3,9].Merge = true; //b2:d2
            planilha.Cells[3, 2, 3, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //b2:d2

            planilha.Cells[3, 2, 3, 4].Style.Font.Bold = true; //b3:d3

            planilha.Cells[++linha, coluna++].Value = "ID:"; //a4
            planilha.Cells[linha, coluna++].Value = "Placa do Veículo:"; //b4
            planilha.Cells[linha, coluna++].Value = "Modelo:"; //C4
            planilha.Cells[linha, coluna++].Value = "Ano:"; //d4
            planilha.Cells[linha, coluna++].Value = "Cor:"; //e4
            planilha.Cells[linha, coluna++].Value = "Nome cliente:"; //f4
            planilha.Cells[linha, coluna++].Value = "CPF:"; //g4
            planilha.Cells[linha, coluna++].Value = "Data da venda:"; //h4
            planilha.Cells[linha, coluna++].Value = "Valor:"; //i4

            planilha.Cells[4, 1, 4, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);
            planilha.Cells[4, 1, 4, 9].Style.Font.Bold = true;
            planilha.Cells[4, 1, 4, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[4, 1, 4, 9].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue); ;
            //formata primeira linha da tabela
            linha++; //D8

            foreach (Venda venda in vendas)
            {
                coluna = 1;  //D1
                planilha.Cells[linha, coluna++].Value = venda.Venid;
                planilha.Cells[linha, coluna++].Value = venda.Carro.Carplaca;
                planilha.Cells[linha, coluna++].Value = venda.Carro.Carmodel;
                planilha.Cells[linha, coluna++].Value = venda.Carro.Carano;
                planilha.Cells[linha, coluna++].Value = venda.Carro.Carcor;
                planilha.Cells[linha, coluna++].Value = venda.Cliente.Clinome;
                planilha.Cells[linha, coluna++].Value = $"{long.Parse(venda.Cliente.Clicpf):000\\.000\\.000\\-00}";
                planilha.Cells[linha, coluna++].Value = venda.Vendatav;
                planilha.Cells[linha, coluna++].Value = venda.Venvalor;
                linha++;
            }
                
            var border = planilha.Cells[4, 1, linha - 1, coluna - 1].Style.Border;
            border.Bottom.Style = 
                border.Top.Style =       // insere bordas na tabela inteira
                border.Left.Style = 
                border.Right.Style = ExcelBorderStyle.Thin;
                
            planilha.Cells[5, 1, linha - 1, coluna-1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[5, 1, linha -1, coluna -1].Style.Fill.BackgroundColor.SetColor(Color.Cornsilk); //adiciona cor de fundo amarela no corpo da tabela


            planilha.Cells[4, 1, linha, coluna].AutoFitColumns(); // define dimensao automatica para celulas

            planilha.Cells[5, 9, linha, 9].Style.Numberformat.Format = "#,##0.00"; // valor recebe formato numerico
            planilha.Cells[5, 8, linha, 8].Style.Numberformat.Format = "dd/mm/yyyy";     // receives date format 


            planilha.Cells[linha, coluna - 2].Value = "Total de vendas: ";
            planilha.Cells[linha, coluna-1].Formula = "SUM(I5:I" + (linha - 1) + ")"; // call the function sum of the rows of valor
            planilha.Cells[linha, coluna - 2, linha, coluna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[linha, coluna - 2, linha, coluna - 1].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
        }

        private void GerarCarros()
        {
            CarroRepositorioADO appCarros = new CarroRepositorioADO();
            var carros = appCarros.ListarTodos();

            ExcelWorksheet planilha = _ep.Workbook.Worksheets.Add("Carros");

            planilha.Cells["A1"].Value = "Carros Concessionária";

            int linha = 1, coluna = 1;          // letra    =   coluna
            linha++;                            // numero   =   linha
            planilha.Cells[++linha, 2].Value = "Relação de Carros"; //b2    
            planilha.Cells[3, 2, 3, 9].Merge = true; //b2:d2
            planilha.Cells[3, 2, 3, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //b2:d2

            planilha.Cells[3, 2, 3, 4].Style.Font.Bold = true; //b3:d3

            planilha.Cells[++linha, coluna++].Value = "Placa do veículo:"; //a4
            planilha.Cells[linha, coluna++].Value = "Modelo:"; //b4
            planilha.Cells[linha, coluna++].Value = "Cor:"; //C4
            planilha.Cells[linha, coluna++].Value = "Marca:"; //d4
            planilha.Cells[linha, coluna++].Value = "Ano:"; //e4
            planilha.Cells[linha, coluna++].Value = "Tipo:"; //f4
            planilha.Cells[linha, coluna++].Value = "Combustivel:"; //g4
            planilha.Cells[linha, coluna++].Value = "Opcionais:"; //h4                

            planilha.Cells[4, 1, 4, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);
            planilha.Cells[4, 1, 4, 8].Style.Font.Bold = true;
            planilha.Cells[4, 1, 4, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[4, 1, 4, 8].Style.Fill.BackgroundColor.SetColor(Color.CornflowerBlue); ;
            //formata primeira linha da tabela
            linha++; //D8

            foreach (Carro carro in carros)
            {
                coluna = 1;
                planilha.Cells[linha, coluna++].Value = carro.Carplaca;
                planilha.Cells[linha, coluna++].Value = carro.Carmodel;
                planilha.Cells[linha, coluna++].Value = carro.Carcor;
                planilha.Cells[linha, coluna++].Value = carro.Carmarca;
                planilha.Cells[linha, coluna++].Value = carro.Carano;
                planilha.Cells[linha, coluna++].Value = carro.Cartipo;
                planilha.Cells[linha, coluna++].Value = carro.Carcombu;

                var opcionais = appCarros.ListarOpcionaldoCarro(carro.Carplaca);
                if (opcionais != null)
                    foreach (Opcional opcional in opcionais)
                    {
                        planilha.Cells[linha, coluna++].Value = opcional.Opcdescr;
                    }
                linha++;
            }
               
            var border = planilha.Cells[4, 1, linha - 1, coluna - 1].Style.Border;
            border.Bottom.Style =
                border.Top.Style =       // insere bordas na tabela inteira
                    border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;

            planilha.Cells[5, 1, linha - 1, coluna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[5, 1, linha - 1, coluna - 1].Style.Fill.BackgroundColor.SetColor(Color.Aquamarine); //adiciona cor de fundo amarela no corpo da tabela

            planilha.Cells[4, 1, linha, coluna].AutoFitColumns(); // define dimensao automatica para celulas                

            planilha.Cells[linha, coluna - 2].Value = "Total de carros: ";
            planilha.Cells[linha, coluna - 1].Value = (linha - 1); // call the function sum of the rows of valor
            planilha.Cells[linha, coluna - 2, linha, coluna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[linha, coluna - 2, linha, coluna - 1].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
        }

        private void GerarClientes()
        {
            ClienteRepositorioADO appCliente = new ClienteRepositorioADO();
            var clientes = appCliente.ListarTodos();

            ExcelWorksheet planilha = _ep.Workbook.Worksheets.Add("Clientes");

            planilha.Cells["A1"].Value = "Clientes Concessionária";

            int linha = 1, coluna = 1;
            linha++;                            // numero   =   linha
            planilha.Cells[++linha, 2].Value = "Relação de Clientes"; //b2    
            planilha.Cells[3, 2, 3, 9].Merge = true; //b2:d2
            planilha.Cells[3, 2, 3, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //b2:d2

            planilha.Cells[3, 2, 3, 4].Style.Font.Bold = true; //b3:d3

            planilha.Cells[++linha, coluna++].Value = "CPF::"; //a4
            planilha.Cells[linha, coluna++].Value = "Nome:"; //b4
            planilha.Cells[linha, coluna++].Value = "Data de nascimento:"; //C4
            planilha.Cells[linha, coluna++].Value = "Endereço:"; //d4
            planilha.Cells[linha, coluna++].Value = "Cidade:"; //e4
            planilha.Cells[linha, coluna++].Value = "Telefone:"; //f4                

            planilha.Cells[4, 1, 4, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
            planilha.Cells[4, 1, 4, 6].Style.Font.Bold = true;
            planilha.Cells[4, 1, 4, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[4, 1, 4, 6].Style.Fill.BackgroundColor.SetColor(Color.DarkViolet); ;
            //formata primeira linha da tabela
            linha++; //D8

            foreach (Cliente cliente in clientes)
            {
                coluna = 1;
                planilha.Cells[linha, coluna++].Value = cliente.Clicpf;
                planilha.Cells[linha, coluna++].Value = cliente.Clinome;
                planilha.Cells[linha, coluna++].Value = cliente.Clidatan;
                planilha.Cells[linha, coluna++].Value = cliente.Cliender;
                planilha.Cells[linha, coluna++].Value = cliente.Clicidad;
                planilha.Cells[linha, coluna++].Value = cliente.Clitelef;
                    
                linha++;
            }

            var border = planilha.Cells[4, 1, linha - 1, coluna - 1].Style.Border;
            border.Bottom.Style =
                border.Top.Style =       // insere bordas na tabela inteira
                    border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;

            planilha.Cells[5, 1, linha - 1, coluna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[5, 1, linha - 1, coluna - 1].Style.Fill.BackgroundColor.SetColor(Color.BurlyWood); //adiciona cor de fundo amarela no corpo da tabela


            planilha.Cells[4, 1, linha, coluna].AutoFitColumns(); // define dimensao automatica para celulas
                
            planilha.Cells[5, 3, linha, 3].Style.Numberformat.Format = "dd/mm/yyyy";     // receives date format 

            planilha.Cells[linha, coluna - 4].Value = "Total de clientes: ";
            planilha.Cells[linha, coluna - 4, linha, coluna - 3].Merge = true; 
            planilha.Cells[linha, coluna - 1].Value = linha - 1; // call the function sum of the rows of valor
            planilha.Cells[linha, coluna - 2, linha, coluna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[linha, coluna - 2, linha, coluna - 1].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
        }
    }
}
