using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Infra;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
         
        }

        public IActionResult Index()
        {
            var dao = new PostDAO();
            var posts = dao.ListaPublicados();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Busca(string termo)
        {
            var dao = new PostDAO();
            var postsBuscados = dao.BuscaPeloTermo(termo);
            ViewBag.Termo = termo;
            return View("Index", postsBuscados);
        }
        
    }
}
