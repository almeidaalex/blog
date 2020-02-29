using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infra
{
    public class PostDAO
    {
        public IList<Post> Lista2()
        {
            var lista = new List<Post>();

            using (var conexao = ConnectionFactory.CriaConexaoAberta())
            {

                SqlCommand comando = new SqlCommand("select * from Posts", conexao);

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var post = new Post
                    {
                        Titulo = leitor["Titulo"].ToString(),
                        Resumo = leitor["Resumo"].ToString(),
                        Categoria = leitor["categoria"].ToString(),
                        Id = Convert.ToInt32(leitor["Id"])
                    };

                    lista.Add(post);
                }
            }

            return lista;
        }

        internal Post BuscaPorId(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                return post;
            }
        }

        internal void Publica(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
            }
        }

        public IList<Post> Lista()
        {
            using(var contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }

        }

        public void Adiciona(Post post)
        {
            using (var contexto = new BlogContext())
            {
                var lista = contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Post post)
        {
            using (var contexto = new BlogContext())
            {
                var lista = contexto.Posts.Update(post);
                contexto.SaveChanges();
            }
        }


        public void Remove(int id)
        {
            using (var contexto = new BlogContext())
            {
                var lista = contexto.Posts.Find(id);
                contexto.Remove(lista);
                contexto.SaveChanges();
            }
        }
    }
}
