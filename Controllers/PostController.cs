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
            var dao = new PostDAO();
            var lista = dao.Lista();
            return View(lista);
        }


        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            var dao = new PostDAO();
            dao.Adiciona(post);
            return RedirectToAction("Index");
        }

        public IActionResult RemovePost(int id)
        {
            var dao = new PostDAO();
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            var dao = new PostDAO();
            var post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult EditaPost(Post post)
        {
            var dao = new PostDAO();
            dao.Atualiza(post);
            return RedirectToAction("Index");
        }

        public IActionResult PublicaPost(int id)
        {
            var dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }

    }
}





