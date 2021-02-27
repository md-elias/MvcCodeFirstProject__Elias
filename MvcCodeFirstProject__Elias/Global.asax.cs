using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


using MvcCodeFirstProject__Elias.Models;
using MvcCodeFirstProject__Elias.ViewModels;

namespace MvcCodeFirstProject__Elias
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(config =>
            {
                config.CreateMap<InstractorVM, Instractor>();
                config.CreateMap<Instractor, InstractorVM>();


                config.CreateMap<BookVM, Book>();
                config.CreateMap<Book, BookVM>();
            });



        }
    }
}
