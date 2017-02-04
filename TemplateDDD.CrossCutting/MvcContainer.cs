using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using System.Web.Mvc;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using TemplateDDD.Domain.Interface.Repository;
using TemplateDDD.Domain.Interface.Service;
using TemplateDDD.Domain.Interface.UnitOfWork;
using TemplateDDD.Domain.Service;
using TemplateDDD.Repository.EF;
using TemplateDDD.Repository.EF.Context;
using TemplateDDD.Repository.EF.Repository;
using AutoMapper;
using TemplateDDD.AppService.AutoMapper;
using TemplateDDD.AppService.Interface;
using TemplateDDD.AppService.Service;

namespace TemplateDDD.CrossCutting
{


    public static class MvcContainer
    {

        public static void IniciarContainer(ref Container container)
        {
            container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();


        }
    }

    
}
