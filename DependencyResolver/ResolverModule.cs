using System.Data.Entity;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interfaces.Interfaces;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }
        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<DbContext>().To<AuctionDbContext>().InRequestScope();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<AuctionDbContext>().InSingletonScope();
            }

            kernel.Bind<IAuctionService>().To<AuctionService>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<ILotService>().To<LotService>();
            kernel.Bind<ILotRepository>().To<LotRepository>();

            kernel.Bind<IBidService>().To<BidService>();
            kernel.Bind<IBidRepository>().To<BidRepository>();

            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();

            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();

            kernel.Bind<IPurchaseService>().To<PurchaseService>();
            kernel.Bind<IPurchaseRepository>().To<PurchaseRepository>();

            kernel.Bind<IExceptionInformationService>().To<ExceptionInformationService>();
            kernel.Bind<IExceptionInformationRepository>().To<ExceptionInformationRepository>();
        }

    }
}
