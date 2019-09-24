using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult QuemSomos() => View();
        public IActionResult Objetivos() => View();
        public IActionResult Dificuldades() => View();
        public IActionResult Especificacoes() => View();
    }
}