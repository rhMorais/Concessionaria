using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Concessionaria.Repositorio
{
    public class ClienteRepositorioADO : IRepositorio<Cliente>
    {
        private Contexto contexto;

        private void Inserir(Cliente cliente)
        {            
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("INSERIR_CLIENTE");
                cmd.Parameters.AddWithValue("@CLICPF", cliente.Clicpf);
                cmd.Parameters.AddWithValue("@CLINOME", cliente.Clinome.ToUpper());
                cmd.Parameters.AddWithValue("@CLIENDER", cliente.Cliender.ToUpper());
                cmd.Parameters.AddWithValue("@CLITELEF", cliente.Clitelef);
                cmd.Parameters.AddWithValue("@CLIDATAN", cliente.Clidatan);
                cmd.Parameters.AddWithValue("@CLICIDAD", cliente.Clicidad?.ToUpper());
                cmd.ExecuteNonQuery();
            }
        }

        private void Alterar(Cliente cliente)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("EDITAR_CLIENTE");
                cmd.Parameters.AddWithValue("@CLICPF", cliente.Clicpf);
                cmd.Parameters.AddWithValue("@CLINOME", cliente.Clinome.ToUpper());
                cmd.Parameters.AddWithValue("@CLIENDER", cliente.Cliender.ToUpper());
                cmd.Parameters.AddWithValue("@CLITELEF", cliente.Clitelef);
                cmd.Parameters.AddWithValue("@CLIDATAN", cliente.Clidatan);
                cmd.Parameters.AddWithValue("@CLICIDAD", cliente.Clicidad?.ToUpper());
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(Cliente cliente)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("DELETAR_CLIENTE");
                cmd.Parameters.AddWithValue("@CLICPF", cliente.Clicpf);
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente ListarPorId(string cpf)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CLIENTE_ID");
                cmd.Parameters.AddWithValue("@CLICPF", cpf);

                var retornoCliente = new Cliente();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        retornoCliente = new Cliente
                        {
                            Clicpf = reader.ReadAsString("CLICPF"),
                            Clicidad = reader.ReadAsStringNull("CLICIDAD"),
                            Clidatan = reader.ReadAsDateTimeNull("CLIDATAN"),
                            Cliender = reader.ReadAsString("CLIENDER"),
                            Clinome = reader.ReadAsString("CLINOME"),
                            Clitelef = reader.ReadAsStringNull("CLITELEF")
                        };
                return retornoCliente;
            }
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_CLIENTE");
                var clientes = new List<Cliente>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        do
                        {
                            clientes.Add(new Cliente
                            {
                                Clicpf = reader.ReadAsString("CLICPF"),
                                Clicidad = reader.ReadAsStringNull("CLICIDAD"),
                                Clidatan = reader.ReadAsDateTimeNull("CLIDATAN"),
                                Cliender = reader.ReadAsString("CLIENDER"),
                                Clinome = reader.ReadAsString("CLINOME"),
                                Clitelef = reader.ReadAsStringNull("CLITELEF")
                            });
                        } while (reader.Read());
                return clientes;
            }
        }

        public void Salvar(Cliente cliente)
        {
            cliente.Clicpf = Regex.Replace(cliente.Clicpf, "[-.]+", "");
                                            //Expressão Lambda
            var penis = ListarTodos().Where(x => x.Clicpf == cliente.Clicpf);
            if (penis.Any())
                Alterar(cliente);
            else
                Inserir(cliente);
        }
    }

    //var nome = "Lenon";
    //var sobrenome = "Bordini";

    //var nomeCompleto = nome.Concatena(sobrenome).Concatena(".");
    //var a = (10).Soma(10).Soma(230).Soma(50).Soma(13);
}


//else retornoCliente = new Cliente
//{
//    Clicidad = "",
//    Clicpf = "",
//    Clidatan = DateTime.Today,
//    Cliender = "",
//    Clinome = "",
//    Clitelef = ""
//};