using RetailShop.BL.IRepo;
using RetailShop.BL.IService;
using RetailShop.BL.Service;
using RetailShop.DL;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace RetailShop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepo, ProductRepo>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepo, OrderRepo>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}