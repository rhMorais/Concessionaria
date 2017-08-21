using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System;
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
                cmd.Parameters.AddWithValue("@CLICPF", venda.Cliente.Clicpf);
                cmd.Parameters.AddWithValue("@CARPLACA", venda.Carro.Carplaca);
                cmd.Parameters.AddWithValue("@VENVALOR", venda.Venvalor);
                cmd.Parameters.AddWithValue("@VENDATAV", venda.Vendatav);
                cmd.ExecuteNonQuery();
            }            
        }

        public void Excluir(Venda venda)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("DELETAR_VENDA");
                cmd.Parameters.AddWithValue("@VENID", venda.Venid);                
                cmd.ExecuteNonQuery();
            }
        }

        public Venda ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_VENDA_ID");
                cmd.Parameters.AddWithValue("@VENID", Convert.ToInt32(id));                

                var retornoVenda = new Venda();
                using (var reader = cmd.ExecuteReader())                
                    if (reader.Read())
                        retornoVenda = new Venda
                        {
                            Venid = reader.ReadAsInt("VENID"),
                            Vendatav = reader.ReadAsDateTimeNull("VENDATAV"),
                            Venvalor = reader.ReadAsDecimalNull("VENVALOR"),
                            Cliente = new Cliente
                            {
                                Clicpf = reader.ReadAsString("CLICPF"),
                                Clinome = reader.ReadAsString("CLINOME"),
                                Clitelef = reader.ReadAsString("CLITELEF")
                            },
                            Carro = new Carro
                            {
                                Carplaca = reader.ReadAsString("CARPLACA"),
                                Carano = reader.ReadAsString("CARCOR"),
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
                        do
                        {
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
                        } while (reader.Read());
                return vendas;
            }
        }

        public void Salvar(Venda venda)
        {
            Inserir(venda);
        }
    }
}
