using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;
using Restoran.Repositories;
using Restoran;

namespace RestoranWeb.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<RestoranContext>().ToSelf().InSingletonScope();
            kernel.Bind<UnitOfWork>().ToSelf().InRequestScope();      
            kernel.Bind<ILocationRepository>().To<LocationRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
            kernel.Bind<IProductOrderedRepository>().To<ProductOrderedARepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IRecipeRepository>().To<RecipeRepository>();
            kernel.Bind<ISupplierRepository>().To<SupplierRepository>();
            kernel.Bind<IUnitRepository>().To<UnitRepository>();
            kernel.Bind<IMarketRepository>().To<MarketRepository>();
            kernel.Bind<IProductSupplierRepository>().To<ProductSupplierRepository>();
            kernel.Bind<IReasonRepository>().To<ReasonRepository>();
            kernel.Bind<IProductDisposalRepository>().To<ProductDisposalRepository>();
            kernel.Bind<IDisposalProductRepository>().To<DisposalProductRepository>();
        }
    }
}