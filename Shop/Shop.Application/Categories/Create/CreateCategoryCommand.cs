using Common.Application;
using Common.Domain.ValueObjects;
using MediatR;

namespace Shop.Application.Categories.Create
{
    public record CreateCategoryCommand(string slug, string title, SeoData seoData) : IBaseCommand<long>
    {
    }
}
