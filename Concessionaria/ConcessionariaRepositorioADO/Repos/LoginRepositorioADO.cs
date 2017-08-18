using Concessionaria.Dominio;
using Concessionaria.Dominio.Contrato;
using System.Collections.Generic;
using System.Linq;

namespace Concessionaria.Repositorio
{
    public class LoginRepositorioADO : IRepositorio<Login>
    {
        private Contexto contexto;

        private void Inserir(Login login)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("INSERIR_LOGIN");
                cmd.Parameters.AddWithValue("@USER", login.Logusuar);
                cmd.Parameters.AddWithValue("@SENHA", login.Logsenha);
                cmd.ExecuteNonQuery();
            }
        }

        private void Alterar(Login login)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("EDITAR_LOGIN");
                cmd.Parameters.AddWithValue("@USER", login.Logusuar);
                cmd.Parameters.AddWithValue("@SENHA", login.Logsenha);
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(Login login)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("DELETAR_LOGIN");
                cmd.Parameters.AddWithValue("@LOGUSUAR", login.Logusuar);
                cmd.ExecuteNonQuery();
            }
        }

        public Login ListarPorId(string usuario)
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_LOGIN_ID");
                cmd.Parameters.AddWithValue("@LOGUSUAR", usuario);

                var retornoLogin = new Login();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        retornoLogin = new Login
                        {
                            Logusuar = reader.ReadAsString("LOGUSUAR"),
                            Logsenha = reader.ReadAsString("LOGSENHA")
                        };
                return retornoLogin;
            }
        }

        public IEnumerable<Login> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var cmd = contexto.ExecutaProcedure("LISTAR_LOGIN");

                var logins = new List<Login>();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        do
                        {
                            logins.Add(new Login
                            {
                                Logusuar = reader.ReadAsString("LOGUSUAR"),
                                Logsenha = reader.ReadAsString("LOGSENHA")
                            });
                        } while (reader.Read());
                return logins;
            }
        }

        public void Salvar(Login login)
        {
            var logins = ListarTodos().Where(x => x.Logusuar == login.Logusuar);

            if (logins.Any()) Alterar(login);
            else Inserir(login);
        }
    }
}
