using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommand :IBaseCommand
    {
        public EditProductCommand(long productId, string slug, string title, IFormFile imageFile,
            string description, long categoryId, long subCategoryId, long secondarySubCategoryId, 
            SeoData seoData, Dictionary<string, string> specifications)

        {
            ProductId = productId;
            Slug = slug;
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            SeoData = seoData;
            Specifications = specifications;
        }

        public long ProductId { get;private set; }
        public string Slug { get; private set; }
        public string Title { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specifications { get;  private set; }
    }
}
