using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products;

public static class ProductMapper
{
    public static ProductDto? Map(this Product? product)
    {
        if (product == null)
            return null;

        return new ProductDto()
        {
            Slug = product.Slug,
            CreationDate = product.CreationDate,
            Title = product.Title,
            Id = product.Id,
            ImageName = product.ImageName,
            SeoData = product.SeoData,
            Description = product.Description,
            Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
            {
                Value = s.Value,
                Key = s.Key
            }).ToList(),
            Images = product.Images.Select(i => new ProductImageDto()
            {
                ImageName = i.ImageName,
            }).ToList(),
            Category = new ProductCategoryDto()
            {
                Id = product.CategoryId,
            },
            SubCategory = new ProductCategoryDto()
            {
                Id = product.SubCategoryId,
            },
            SecondarySubCategory = product.SecondarySubCategoryId != null ? new ProductCategoryDto()
            {
                Id = (long)product.SecondarySubCategoryId,
            } : null,
        };
    }

    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Id = product.Id,
            CreationDate = product.CreationDate,
            Title = product.Title,
            ImageName = product.ImageName,
            Slug = product.Slug,
        };
    }
    public static async Task SetCategories(this ProductDto product, ShopContext context)
    {
        var categoreis = context.Categories
            .Where(r => r.Id == product.Category.Id || r.Id == product.SubCategory.Id)
            .Select(s => new ProductCategoryDto()
            {
                Id = s.Id,
                Title = s.Title,
                Slug = s.Slug,
                SeoData = s.SeoData,
                ParentId = s.ParentId,
            });
        if (product.SecondarySubCategory != null)
        {
            var secondarySubCategory =await context.Categories
                .Where(r => r.Id == product.SecondarySubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Title = s.Title,
                    SeoData = s.SeoData,
                    Slug = s.Slug,
                    ParentId = s.ParentId,
                }).FirstOrDefaultAsync();

            if (secondarySubCategory != null)
                product.SecondarySubCategory = secondarySubCategory;   
        }
        product.Category = categoreis.First(r => r.Id == product.Category.Id);
        product.SubCategory = categoreis.First(r => r.Id == product.SubCategory.Id);

    }

}
