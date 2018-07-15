using System.Collections.Generic;
using System.Linq;
using MassMarket.Domain.Entities;
using MassMarket.Domain.Repositories;
using MassMarket.Service.Models;

namespace MassMarket.Service {

    public interface IProductService {
        IEnumerable<Product> Search(SearchModel query);
    }

    public class ProductService : IProductService {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> Search(SearchModel query) {
            IQueryable<Product> searchResult = _unitOfWork.Products.GetAll();

            // Query text filter
            if (!string.IsNullOrEmpty(query.QueryText)) {
                searchResult = searchResult.Where(p =>
                    p.Name.Contains(query.QueryText) || p.Description.Contains(query.QueryText));
            }

            // Category filter
            if (query.CategoryId != 0) {
                searchResult = searchResult.Where(p => p.CategoryId == query.CategoryId);
            }

            return searchResult;
        }
    }
}
