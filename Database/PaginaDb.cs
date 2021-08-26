using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PaginaDb
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from paginas";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string nome, string conteudo, DateTime data)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                //string queryString = "insert into paginas (nome, data, conteudo) values " +
                //    "('" + nome + "','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + conteudo + "');";

                //if (id != 0)
                //{
                //    queryString = "update paginas set nome = '" + nome + "', data='" + data.ToString("yyyy-MM-dd HH:mm:ss") +
                //        "', conteudo='" + conteudo + "' where id=" + id;
                    
                //}

                string queryString = @"merge [cms].[dbo].[paginas] as b
                                    using ( select "+id+" as id, '" + nome+"' Nome ,'"+ conteudo + "' Conteudo ,'"+ data + @"' data ) as a on a.id=b.id
                                    when matched then 
                                    update set b.conteudo=a.Conteudo, nome =a.nome
                                    when not matched then 
                                    insert values(a.Nome,a.Conteudo,A.data);";


                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "delete from paginas where id =" + id; 
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public DataTable BuscaPorId(int id)
        {

            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from paginas where id = " + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
