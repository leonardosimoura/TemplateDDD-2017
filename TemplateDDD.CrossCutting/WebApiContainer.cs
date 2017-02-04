using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace TemplateDDD.CrossCutting
{
    public static class WebApiContainer
    {

        public static void IniciarContainer(ref Container container)
        {
            container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            
        }
    }
}
