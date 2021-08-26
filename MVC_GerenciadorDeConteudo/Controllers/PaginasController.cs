using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Paginas = new PaginaBusiness().Lista();
            return View();
        }

        public ActionResult Novo()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Criar()
        {
            //convertendo data
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            //pegando valores do formulario
            var pagina = new PaginaBusiness();
            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudo"];
            pagina.Save();
            Response.Redirect("/paginas");
        }

        public ActionResult Editar(int id)
        {
            var pagina = PaginaBusiness.BuscarPorId(id);
            ViewBag.Paginas = pagina;
            return View();
        }

        public ActionResult Preview(int id)
        {
            var pagina = PaginaBusiness.BuscarPorId(id);
            ViewBag.Paginas = pagina;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
          
                var pagina = PaginaBusiness.BuscarPorId(id);
                //convertendo data
                DateTime data;
                DateTime.TryParse(Request["data"], out data);
                //pegando valores do formulario

                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudo"];
                pagina.Save();


            Response.Redirect("/paginas");
        }


        public void Excluir(int id)
        {
            PaginaBusiness.Excluir(id);
           
            Response.Redirect("/paginas");
        }

    }
}