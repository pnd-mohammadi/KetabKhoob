using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Service;
using Shop.Domain.CommentAgg;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.RoleAgg;
using Shop.Domain.SellerAgg;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.SiteAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.UserAgg;

namespace Shop.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init( IServiceCollection services ,string connctionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();
        //services.AddSingleton<ICustomPublisher, CustomPublisher>();

        services.AddTransient(_ => new DapperContext(connctionString));

        services.AddDbContext<ShopContext>(option =>
        {
            option.UseSqlServer(connctionString);
        });
    }
}
