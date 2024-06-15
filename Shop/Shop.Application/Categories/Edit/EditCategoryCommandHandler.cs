using Common.Application;
using Shop.Domain.CategoryAgg.Service;
using Shop.Domain.CategoryAgg;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainServicer;
        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer)
        {
            _repository = repository;
            _domainServicer = domainServicer;
        }
        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();
                category.Edit(request.slug, request.title, request.seoData, _domainServicer);
                await _repository.Save();
                return OperationResult.Success(); 
        }
    }
}
