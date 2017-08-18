using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System;
using System.Collections.Generic;

namespace Concessionaria.Repositorio
{
    public class CarroRepositorioADO : IRepositorio<Carro>
    {
        private Contexto contexto;

        private void Inserir(Carro carro)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("INSERIR_CARRO");
                cmd.Parameters.AddWithValue("@MODELO", carro.Carmodel);
                cmd.Parameters.AddWithValue("@MARCA", carro.Carmarca);
                cmd.Parameters.AddWithValue("@ANO", carro.Carano);
                cmd.Parameters.AddWithValue("@TIPO", carro.Cartipo);
                cmd.Parameters.AddWithValue("@COMBUSTIVEL", carro.Carcombu);
                cmd.Parameters.AddWithValue("@COR", carro.Carcor);
                cmd.ExecuteNonQuery();
            }
        }

        private void Alterar(Carro carro)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("EDITAR_CARRO");
                cmd.Parameters.AddWithValue("@ID", carro.Carid);
                cmd.Parameters.AddWithValue("@MODELO", carro.Carmodel);
                cmd.Parameters.AddWithValue("@MARCA", carro.Carmarca);
                cmd.Parameters.AddWithValue("@COR", carro.Carcor);
                cmd.Parameters.AddWithValue("@COMBU", carro.Carcombu);
                cmd.Parameters.AddWithValue("@TIPO", carro.Cartipo);
                cmd.Parameters.AddWithValue("@ANO", carro.Carano);
                cmd.ExecuteNonQuery();
            }
        }
        public void Excluir(Carro carro)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("DELETAR_CARRO");
                cmd.Parameters.AddWithValue("@CARID", carro.Carid);
                cmd.ExecuteNonQuery();
            }
        }

        public Carro ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CARRO_ID");
                cmd.Parameters.AddWithValue("@CARID", Convert.ToInt32(id));

                var retornoCarro = new Carro();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        retornoCarro = new Carro
                        {
                            Carano = reader.ReadAsString("CARANO"),
                            Carcombu = reader.ReadAsStringNull("CARCOMBU"),
                            Carcor = reader.ReadAsString("CARCOR"),
                            Carid = reader.ReadAsInt("CARID"),
                            Carmarca = reader.ReadAsString("CARMARCA"),
                            Carmodel = reader.ReadAsString("CARMODEL"),
                            Cartipo = reader.ReadAsStringNull("CARTIPO")
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
                                Carid = reader.ReadAsInt("CARID"),
                                Carmarca = reader.ReadAsString("CARMARCA"),
                                Carmodel = reader.ReadAsString("CARMODEL"),
                                Cartipo = reader.ReadAsStringNull("CARTIPO")
                            });
                        } while (reader.Read());
                return carros;
            }
        }

        public void Salvar(Carro carro)
        {
            if (carro.Carid > 0) Alterar(carro);
            else Inserir(carro);
        }
    }
}
