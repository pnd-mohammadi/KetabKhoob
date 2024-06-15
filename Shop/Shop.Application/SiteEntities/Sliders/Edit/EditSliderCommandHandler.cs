using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        public readonly ISliderRepository _repository;
        public readonly IFileService _localFileService;

        public EditSliderCommandHandler(ISliderRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider =await _repository.GetTracking(request.SliderId);
            if (slider == null)
                return OperationResult.NotFound();

            var  oldImage= slider.ImageName;
            var  imageName=slider.ImageName;


            if (request.ImageFile !=null)
               imageName=await _localFileService.SaveFileAndGenerateName(request.ImageFile,Directories.SliderImages);

            slider.Edit(request.Title, imageName, request.Link);

            await _repository.Save();
            DeleteOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }
        private void DeleteOldImage(IFormFile? imageFile, string oldImage)
        {
            if (imageFile != null)
                _localFileService.DeleteFile(Directories.SliderImages, oldImage);
        }
    }
}

