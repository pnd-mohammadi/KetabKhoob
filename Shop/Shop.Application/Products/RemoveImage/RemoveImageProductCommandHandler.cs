using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveImageProductCommandHandler : IBaseCommandHandler<RemoveImageProductCommand>
    {
        public readonly IProductRepository _repository;
        public readonly IFileService _fileService;

        public RemoveImageProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public  async Task<OperationResult> Handle(RemoveImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);
            await _repository.Save();
            _fileService.DeleteFile(Directories.ProductGalleryImage, imageName);

            return OperationResult.Success();
        }
    }
    

}
