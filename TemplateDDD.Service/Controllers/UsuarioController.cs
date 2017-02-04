using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using TemplateDDD.AppService.Interface;
using TemplateDDD.AppService.ViewModels;

namespace TemplateDDD.Service.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioViewModelService _service;
        public UsuarioController(IUsuarioViewModelService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("AdicionarUsuario")]
        public IHttpActionResult AdicionarUsuario(UsuarioViewModel model)
        {
            
            _service.Adicionar(ref model);

            return Ok(model);
        }

        [HttpPost]
        [Route("RemoverUsuario")]
        public IHttpActionResult RemoverUsuario([FromBody]int Id)
        {
            _service.Remover(Id);
            //_service.RemoverMuitos(new List<object[]>() { new object []{ 2 } , new object[] { 3 }, new object[] { 4 } });
            return Ok();
        }
    }
}
