using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        IList<Post> _posts = new List<Post>();


        public IActionResult Index()
        {
            using (var conexao = ConnectionFactory.CriaConexaoAberta())
            {
                
                SqlCommand comando = new SqlCommand("select * from Posts", conexao);

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var post = new Post();
                    post.Titulo = leitor["Titulo"].ToString();
                    post.Resumo = leitor["Resumo"].ToString();
                    post.Categoria = leitor["categoria"].ToString();
                    post.Id = Convert.ToInt32(leitor["Id"]);

                    _posts.Add(post);
                }
            }

            return View(_posts);
        }


        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {


            _posts.Add(post);
            return View("Index", post);
        }


    }
}





