using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector.Advanced;
using TemplateDDD.AppService.Interface;
using TemplateDDD.Domain.Interface.UnitOfWork;

namespace TemplateDDD.CrossCutting
{
    public class ImportPropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type type, PropertyInfo prop)
        {
            if (prop.GetType().GetInterfaces().Any(a => a == typeof(IUnitOfWork)))
                return true;
            else if (prop.GetType().GetInterfaces().Any(a => a == typeof(IMapperService<,>)))
                return true;

            return false;
        }
    }
}
