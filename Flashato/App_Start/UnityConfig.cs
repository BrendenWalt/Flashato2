using Flashato.Controllers;
using Flashato.Services;
using Flashato.Services.Interfaces;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Flashato
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<IFlashcardServices, FlashcardServices>();

            container.RegisterType<IUserService, UserServices>();
        }
    }
}