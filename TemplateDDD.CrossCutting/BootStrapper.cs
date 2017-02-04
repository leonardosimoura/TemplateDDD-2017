using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using TemplateDDD.AppService.AutoMapper;
using TemplateDDD.AppService.Interface;
using TemplateDDD.AppService.Service;
using TemplateDDD.Domain.Interface.Repository;
using TemplateDDD.Domain.Interface.Service;
using TemplateDDD.Domain.Interface.UnitOfWork;
using TemplateDDD.Domain.Service;
using TemplateDDD.Repository.EF;
using TemplateDDD.Repository.EF.Context;
using TemplateDDD.Repository.EF.Repository;

namespace TemplateDDD.CrossCutting
{
    public class BootStrapper
    {
        public static void IniciarMvcContainer()
        {
            var container = new Container();
            MvcContainer.IniciarContainer(ref container);
            RegistrarServicos(container);
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static void IniciarWebApiContainer(HttpConfiguration config)
        {
            var container = new Container();
            WebApiContainer.IniciarContainer(ref container);
            RegistrarServicos(container);
            container.Verify();

            config.DependencyResolver =  new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegistrarServicos(Container container)
        {
            var config = AutoMapperConfig.RegisterMappings();
            container.RegisterSingleton<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance), Lifestyle.Singleton);
            container.Register(typeof(IMapperService<,>), typeof(MapperService<,>), Lifestyle.Singleton);

            container.Register<DbContext, DbConn>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);

            //AppService
            container.Register<IUsuarioViewModelService, UsuarioViewModelService>(Lifestyle.Scoped);
            //Service
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            //Repository
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
        }
    }
    
}
