using System;
using System.Collections.Generic;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Models.Post> Lista()
        {
            var lista = new List<Models.Post>();

            using (var connection = Infra.ConnectionFactory.GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Titulo, Resumo, Categoria FROM Post";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Models.Post
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Titulo = Convert.ToString(reader["titulo"]),
                            Resumo = Convert.ToString(reader["resumo"]),
                            Categoria = Convert.ToString(reader["categoria"])
                        });
                    }
                }
            }

            return lista;
        }

        public void Insere(Models.Post post)
        {
            using (var connection = Infra.ConnectionFactory.GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Post (Titulo, Resumo, Categoria) VALUES (@titulo, @resumo, @categoria)";

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@titulo", post.Titulo));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@resumo", post.Resumo));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@categoria", post.Categoria));

                command.ExecuteNonQuery();
            }
        }
    }
}
