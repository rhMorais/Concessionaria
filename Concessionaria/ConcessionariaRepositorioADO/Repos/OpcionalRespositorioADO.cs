using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System;
using System.Collections.Generic;

namespace Concessionaria.Repositorio
{

    public class OpcionalRespositorioADO : IRepositorio<Opcional>
    {
        private Contexto contexto;

        private void Inserir(Opcional opcional)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("INSERIR_OPCIONAL");
                cmd.Parameters.AddWithValue("@OPCDESCR", opcional.Opcdescr);
                cmd.ExecuteNonQuery();
            }
        }

        private void Alterar(Opcional opcional)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("EDITAR_OPCIONAL");
                cmd.Parameters.AddWithValue("@OPCID", opcional.Opcid);
                cmd.Parameters.AddWithValue("@OPCDESCR", opcional.Opcdescr);
                cmd.ExecuteNonQuery();
            }
        }

        public void Salvar(Opcional opcional)
        {
            if (opcional.Opcid > 0) Alterar(opcional);
            else Inserir(opcional);
        }

        public void Excluir(Opcional opcional)
        {
            using (contexto = new Contexto())
            {
                var del = contexto.ExecutaProcedure("DELETAR_OPCIONAL_CARRO");
                del.Parameters.AddWithValue("@OPCID", opcional.Opcid);
                del.ExecuteNonQuery();

                var cmd = contexto.ExecutaProcedure("DELETAR_OPCIONAL");
                cmd.Parameters.AddWithValue("@OPCID", opcional.Opcid);
                cmd.ExecuteNonQuery();
            }

            //var nomeCompleto2 = $"{nome} {sobrenome}";
        }

        public Opcional ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_OPCIONAL_ID");
                cmd.Parameters.AddWithValue("@OPCID", Convert.ToInt32(id));

                var retornoOpcional = new Opcional();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        retornoOpcional = new Opcional
                        {
                            Opcid = reader.ReadAsInt("OPCID"),
                            Opcdescr = reader.ReadAsString("OPCDESCR")
                        };
                return retornoOpcional;
            }
        }

        public IEnumerable<Opcional> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_OPCIONAL");

                var opcionais = new List<Opcional>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        do
                        {
                            opcionais.Add(new Opcional
                            {
                                Opcid = reader.ReadAsInt("OPCID"),
                                Opcdescr = reader.ReadAsString("OPCDESCR")
                            });
                        } while (reader.Read());

                return opcionais;
            }            
        }        
    }
}


//using (contexto = new Contexto())
//{
//    var query = " SELECT * FROM OPCIONAL";
//    var dataReader = contexto.ExecutaComandoComRetorno(query);
//    return TransformaReaderEmListaDeObjeto(dataReader);
//}

//private List<Opcional> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
//{
//    var opcionais = new List<Opcional>();
//    while (reader.Read())
//    {
//        var tempObjeto = new Opcional()
//        {
//            opcid = int.Parse(reader["OPCID"].ToString()),
//            opcdescr = reader["OPCDESCR"].ToString()
//        };
//        opcionais.Add(tempObjeto);
//    }
//    reader.Close();
//    return opcionais;
//}