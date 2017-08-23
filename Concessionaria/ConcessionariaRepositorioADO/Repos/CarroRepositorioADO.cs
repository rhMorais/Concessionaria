using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System;
using System.Collections.Generic;

namespace Concessionaria.Repositorio
{
    public class CarroRepositorioADO : ICarroRepositorio<Carro>
    {
        private Contexto contexto;

        private void IncluirOpcional(Carro carro)
        {
            using (contexto = new Contexto())
            {
                using (var del = contexto.ExecutaProcedure("DELETAR_CARRO_OPCIONAL"))
                {
                    del.Parameters.AddWithValue("@CARPLACA", carro.Carplaca);
                    del.ExecuteNonQuery();
                }
                if (carro.Caropcio != null)
                    foreach (var item in carro.Caropcio)
                    {
                        using (var cmd = contexto.ExecutaProcedure("INSERIR_CARRO_OPCIONAL"))
                        {
                            cmd.Parameters.AddWithValue("@CARPLACA", carro.Carplaca);
                            cmd.Parameters.AddWithValue("@OPCID", item.Opcid);
                            cmd.ExecuteNonQuery();
                        }
                    }
            }
        }

        private void Inserir(Carro carro)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("INSERIR_CARRO");
                cmd.Parameters.AddWithValue("@CARPLACA", carro.Carplaca);
                cmd.Parameters.AddWithValue("@CARMODEL", carro.Carmodel);
                cmd.Parameters.AddWithValue("@CARMARCA", carro.Carmarca);
                cmd.Parameters.AddWithValue("@CARANO", carro.Carano);
                cmd.Parameters.AddWithValue("@CARTIPO", carro.Cartipo);
                cmd.Parameters.AddWithValue("@CARCOMBU", carro.Carcombu);
                cmd.Parameters.AddWithValue("@CARCOR", carro.Carcor);
                cmd.ExecuteNonQuery();
            }
        }

        private void Alterar(Carro carro)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("EDITAR_CARRO");
                cmd.Parameters.AddWithValue("@CARPLACA", carro.Carplaca);
                cmd.Parameters.AddWithValue("@CARMODEL", carro.Carmodel);
                cmd.Parameters.AddWithValue("@CARMARCA", carro.Carmarca);
                cmd.Parameters.AddWithValue("@CARANO", carro.Carano);
                cmd.Parameters.AddWithValue("@CARTIPO", carro.Cartipo);
                cmd.Parameters.AddWithValue("@CARCOMBU", carro.Carcombu);
                cmd.Parameters.AddWithValue("@CARCOR", carro.Carcor);
                cmd.ExecuteNonQuery();
            }
        }
        public void Excluir(Carro carro)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("DELETAR_CARRO");
                cmd.Parameters.AddWithValue("@CARPLACA", carro.Carplaca);
                cmd.ExecuteNonQuery();
            }
        }

        public Carro ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CARRO_ID");
                cmd.Parameters.AddWithValue("@CARPLACA", id);

                var retornoCarro = new Carro();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        retornoCarro = new Carro
                        {
                            Carano = reader.ReadAsString("CARANO"),
                            Carcombu = reader.ReadAsStringNull("CARCOMBU"),
                            Carcor = reader.ReadAsString("CARCOR"),
                            Carplaca = reader.ReadAsString("CARPLACA"),
                            Carmarca = reader.ReadAsString("CARMARCA"),
                            Carmodel = reader.ReadAsString("CARMODEL"),
                            Cartipo = reader.ReadAsStringNull("CARTIPO")
                        };
                    retornoCarro.Caropcio = ListarOpcionaldoCarro(id);
                }

                return retornoCarro;
            }
        }



        public Venda ListarDetalhesVendidos(string placa)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CARRO_VENDIDO_ID");
                cmd.Parameters.AddWithValue("@CARPLACA", Convert.ToInt32(placa));

                var retornoCarro = new Venda();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        retornoCarro = new Venda
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
                return retornoCarro;
            }
        }

        public IEnumerable<Carro> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CARRO");

                var carros = new List<Carro>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        do
                        {
                            carros.Add(new Carro
                            {
                                Carano = reader.ReadAsString("CARANO"),
                                Carcombu = reader.ReadAsStringNull("CARCOMBU"),
                                Carcor = reader.ReadAsString("CARCOR"),
                                Carplaca = reader.ReadAsString("CARPLACA"),
                                Carmarca = reader.ReadAsString("CARMARCA"),
                                Carmodel = reader.ReadAsString("CARMODEL"),
                                Cartipo = reader.ReadAsStringNull("CARTIPO")
                            });
                        } while (reader.Read());
                return carros;
            }
        }

        public IList<Opcional> ListarOpcionaldoCarro(string id)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CARRO_OPCIONAL_ID");
                cmd.Parameters.AddWithValue("CARPLACA", id);
                var retornoOpcional = new List<Opcional>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        do
                        {
                            retornoOpcional.Add(new Opcional
                            {
                                Opcdescr = reader.ReadAsString("OPCDESCR"),
                                Opcid = reader.ReadAsInt("OPCID")
                            });
                        } while (reader.Read());
                return retornoOpcional;
            }
        }

        public IEnumerable<Carro> ListarVendidos()
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_VENDIDOS");

                var carros = new List<Carro>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        do
                        {
                            carros.Add(new Carro
                            {
                                Carano = reader.ReadAsString("CARANO"),
                                Carcor = reader.ReadAsString("CARCOR"),
                                Carplaca = reader.ReadAsString("CARPLACA"),
                                Carmarca = reader.ReadAsString("CARMARCA"),
                                Carmodel = reader.ReadAsString("CARMODEL"),
                            });
                        } while (reader.Read());
                return carros;
            }
        }

        public void Salvar(Carro carro)
        {
            //var penis = ListarTodos().Where(x => x.Carplaca == carro.Carplaca);
            var xota = ListarPorId(carro.Carplaca);
            if (xota.Carplaca != null)
            {
                Alterar(carro);
                IncluirOpcional(carro);
            }
            else
            {
                Inserir(carro);
                IncluirOpcional(carro);
            }
        }
    }
}
