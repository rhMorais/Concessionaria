using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;

namespace Concessionaria.Repositorio
{
    public class VendaRepositorioADO:IRepositorio<Venda>
    {
        private Contexto contexto;

        private void Inserir(Venda venda)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("INSERIR_VENDA");
                cmd.Parameters.AddWithValue("@CLIENTE", venda.Cliente.Clicpf);
                cmd.Parameters.AddWithValue("@CARRO", venda.Carro.Carid);
                cmd.Parameters.AddWithValue("@VALOR", venda.Venvalor);
                cmd.Parameters.AddWithValue("@DATA", venda.Vendatav);
                cmd.ExecuteNonQuery();
            }            
        }

        public void Excluir(Venda venda)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("DELETAR_VENDA");
                cmd.Parameters.AddWithValue("@CLICPF", venda.Cliente.Clicpf);
                cmd.Parameters.AddWithValue("@CARID", venda.Carro.Carid);
                cmd.ExecuteNonQuery();
            }
        }

        public Venda ListarPorId(Venda venda)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_VENDA_ID");
                cmd.Parameters.AddWithValue("@CLICPF", venda.Cliente.Clicpf);
                cmd.Parameters.AddWithValue("@CARID", venda.Carro.Carid);

                var retornoVenda = new Venda();
                using (var reader = cmd.ExecuteReader())                
                    if (reader.Read())
                        retornoVenda = new Venda
                        {
                            Vendatav = reader.ReadAsDateTimeNull("VENDATAV"),
                            Venvalor = reader.ReadAsDecimalNull("VENVALOR"),
                            Cliente = new Cliente
                            {
                                Clinome = reader.ReadAsString("CLINOME")
                            },
                            Carro = new Carro
                            {
                                Carmodel = reader.ReadAsString("CARMODEL"),
                                Carcor = reader.ReadAsString("CARCOR")
                            }
                        };                    
                return retornoVenda;                
            }
        }

        public IEnumerable<Venda> ListarTodos()
        {
            using(contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_VENDA");
                var vendas = new List<Venda>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        while (reader.Read())
                            vendas.Add(new Venda
                            {
                                Vendatav = reader.ReadAsDateTimeNull("VENDATAV"),
                                Venvalor = reader.ReadAsDecimalNull("VENVALOR"),
                                Cliente = new Cliente
                                {
                                    Clinome = reader.ReadAsString("CLINOME")
                                },
                                Carro = new Carro
                                {
                                    Carmodel = reader.ReadAsString("CARMODEL"),
                                    Carcor = reader.ReadAsString("CARCOR")
                                }
                            });
                return vendas;
            }
        }

        public void Salvar(Venda venda)
        {
            Inserir(venda);
        }
    }
}
