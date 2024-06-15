using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories;
using Shop.Application.Comments.Create;
using Shop.Application.Products;
using Shop.Application.Roles.Create;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.CategoryAgg.Service;
using Shop.Domain.ProductAgg.Service;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Presentation.Facade;
using Shop.Query.Orders.GetByFilter;
using System.Reflection;

namespace Shop.Config
{
    public static class ShopBootStrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services , string connectionString )
        {
            InfrastructureBootstrapper.Init(services, connectionString);
            services.AddMediatR(typeof(Directories).Assembly);
            services.AddMediatR(typeof(GetOrderByFilterQuery).Assembly);
            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();

            services.AddValidatorsFromAssembly(typeof(CreateRoleCommadValidator).Assembly);
            services.InitFacadeDependency();
        }
    }
}
