using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using Hk.Application1.Repository.Interface;
using Hk.Utilities.GenericComponents;
using Hk.Utilities.Interfaces;

namespace Hk.Application1.Services.Categories
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        ICategoryRepository _iCategoryRepository;
        IUnitOfWork _unitOfWork;
        IServiceManager _iServiceManager;

        public CategoryService(
            ICategoryRepository iCategoryRepository,
            IUnitOfWork unitOfWork,
            IServiceManager iServiceManager
            ) : base(iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
            _unitOfWork = unitOfWork;
            _iServiceManager = iServiceManager;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _iCategoryRepository.GetCategoryById(categoryId);
        }
    }
}
