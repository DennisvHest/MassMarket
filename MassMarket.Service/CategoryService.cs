using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MassMarket.Domain.Entities;
using MassMarket.Domain.Repositories;

namespace MassMarket.Service {

    public interface ICategoryService {
        IEnumerable<Category> GetParentWithChildrenCategories();
    }

    public class CategoryService : ICategoryService {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetParentWithChildrenCategories() {
            return _unitOfWork.Categories.GetAll()
                .Where(c => c.ParentCategoryId == null)
                .Include(c => c.ChildCategories);
        }
    }
}
