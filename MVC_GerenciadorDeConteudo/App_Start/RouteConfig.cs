using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "paginas",
                "paginas",
                new { controller = "Paginas", action = "Index" }
                );

            routes.MapRoute(
               "paginas_novo",
               "paginas/novo",
               new { controller = "Paginas", action = "Novo" }
               );

            routes.MapRoute(
               "paginas_criar",
               "paginas/criar",
               new { controller = "Paginas", action = "Criar" }
               );

            routes.MapRoute(
               "paginas_editar",
               "paginas/editar/{id}",
               new { controller = "Paginas", action = "Editar", id = 0 }
               );

            routes.MapRoute(
               "paginas_alterar",
               "paginas/alterar/{id}",
               new { controller = "Paginas", action = "Alterar", id = 0 }
               );

            routes.MapRoute(
               "paginas_excluir",
               "paginas/excluir/{id}",
               new { controller = "Paginas", action = "Excluir", id = 0 }
               );

            routes.MapRoute(
              "paginas_preview",
              "paginas/preview/{id}",
              new { controller = "Paginas", action = "Preview", id = 0 }
              );

        }
    }
}
