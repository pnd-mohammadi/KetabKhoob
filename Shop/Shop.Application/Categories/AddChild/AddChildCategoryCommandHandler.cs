using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler:IBaseCommandHandler<AddChildCategoryCommand,long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _service;

        public AddChildCategoryCommandHandler(ICategoryRepository category, ICategoryDomainService service)
        {
            _repository = category;
            _service = service;
        }

        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var child =await _repository.GetTracking(request.parntId);
            if (child == null)
                return OperationResult<long>.NotFound();
            child.AddChild(request.title, request.slug, _service);
            await _repository.Save();
            return OperationResult<long>.Success(child.Id);
        }
    }
}
