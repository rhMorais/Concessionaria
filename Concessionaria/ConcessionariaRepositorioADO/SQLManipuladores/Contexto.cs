using System;
using System.Data;
using System.Data.SqlClient;

namespace Concessionaria.Repositorio
{
    class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = new SqlConnection(@"data source=PC-RAFAEL\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=CONCESSIONARIA");
            minhaConexao.Open();
        }        

        public void Dispose()
        {
            if(minhaConexao.State == ConnectionState.Open)
            {
                minhaConexao.Close();
            }
        }

        public SqlCommand ExecutaProcedure(string procedureName)
        {
            return new SqlCommand
            {
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure,
                Connection = minhaConexao
            };
        }        
    }
}

//public void ExecutaComando(string query)
//{
//    var cmdComando = new SqlCommand
//    {
//        CommandText = query,
//        CommandType = CommandType.Text,
//        Connection = minhaConexao
//    };
//    cmdComando.ExecuteNonQuery();
//}

//public SqlDataReader ExecutaComandoComRetorno(string query)
//{
//    var cmdComando = new SqlCommand(query, minhaConexao);
//    return cmdComando.ExecuteReader();
//}