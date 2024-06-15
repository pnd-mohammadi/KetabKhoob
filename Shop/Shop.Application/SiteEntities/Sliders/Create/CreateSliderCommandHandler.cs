using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly IFileService _localFileService;
        public readonly ISliderRepository _repository;
        public CreateSliderCommandHandler(IFileService localFileService, ISliderRepository repository)
        {
            _localFileService = localFileService; 
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName =await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Slider(request.Link,imageName,request.Title);
            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
