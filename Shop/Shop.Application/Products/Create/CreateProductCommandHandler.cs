﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductRepository repository, IFileService fileService, IProductDomainService domainService)
        {
            _repository = repository;
            _fileService = fileService;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName =await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

            var product = new Product(request.Slug,request.Title, imageName, request.Description,request.CategoryId,
                request.SubCategoryId,request.SecondarySubCategoryId, _domainService ,request.SeoData);

            _repository.Add(product);
            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification=>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });   
            product.SetSpecification(specifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
