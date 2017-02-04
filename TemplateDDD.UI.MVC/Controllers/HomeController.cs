using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateDDD.AppService.Interface;
using TemplateDDD.AppService.ViewModels;

namespace TemplateDDD.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioViewModelService _service;
        public HomeController(IUsuarioViewModelService service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
            var usu = new UsuarioViewModel() { Nome = "Leonardo"};
            _service.Adicionar(ref usu);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}