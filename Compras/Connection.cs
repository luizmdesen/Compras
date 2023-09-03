using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Compras
{
    /// <summary>
    /// Class <c>Connection</c> conector e CRUD do SQL Server.
    /// </summary>
    public class Connection
    {
        /// <value>Property <c>conStr</c> representa a string de conexão para o SQL Server.</value>
        private string conStr { get; set; }
        public Connection(string conStr)
        {
            this.conStr = conStr;
        }
        /// <summary>
        /// Teste de login para saber se o usuário é válido.
        /// </summary>
        public void TestLogin ()
        {
            SqlConnection cnn = new SqlConnection(conStr);
            cnn.Open();
            cnn.Close();
        }
        /// <summary>
        /// Este método executa um comando no SQL Server sem retorno de dados.
        /// </summary>
        /// <param name="query">consulta que irá ser executada no SQL Server.</param>
        public void ExecuteOnDatabase(string query)
        {
            SqlConnection cnn = new SqlConnection(conStr);
            SqlCommand sqlComm = new SqlCommand(query, cnn);
            cnn.Open();
            sqlComm.ExecuteNonQuery();
            cnn.Close();
        }
        /// <summary>
        /// Este método executa um comando do SQL Server com retorno de dados.
        /// </summary>
        /// <param name="query">consulta que irá ser executada no SQL Server.</param>
        
        /// <returns>
        /// Retorna reader da classe SqlConnection
        /// </returns>
        public SqlDataReader Read(string query)
        {
            SqlConnection cnn = new SqlConnection(conStr);
            SqlCommand sqlComm = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataReader res = sqlComm.ExecuteReader();
            return res;
        }
    }
}
