using System;
using System.Collections.Generic;
using System.Linq;
using MassMarket.Domain.Entities;
using MassMarket.Domain.Repositories;
using MassMarket.Service.Models;

namespace MassMarket.Service {

    public interface IProductService {
        SearchResult Search(SearchModel query);
    }

    public class ProductService : IProductService {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public SearchResult Search(SearchModel query) {
            SearchResult result = new SearchResult();

            IQueryable<Product> foundProducts = _unitOfWork.Products.GetAll();

            // Category filter
            if (query.CategoryId != 0) {
                foundProducts = foundProducts.Where(p => 
                    p.CategoryId == query.CategoryId
                    || p.Category.ParentCategoryId == query.CategoryId);
            }

            // Query text filter
            if (!string.IsNullOrEmpty(query.QueryText)) {
                foundProducts = foundProducts.Where(p =>
                    p.Name.Contains(query.QueryText) || p.Description.Contains(query.QueryText));
            }

            // Check the possible minimum and maximum price before filtering by price
            if (foundProducts.Any()) {
                result.MinPrice = Math.Floor(foundProducts.Min(p => p.Price));
                result.MaxPrice = Math.Ceiling(foundProducts.Max(p => p.Price));
            }
            
            // Price filter
            if (query.MinPrice.HasValue) {
                foundProducts = foundProducts.Where(p => p.Price >= query.MinPrice);
            }

            if (query.MaxPrice.HasValue) {
                foundProducts = foundProducts.Where(p => p.Price <= query.MaxPrice);
            }

            result.FoundProducts = foundProducts.Take(20);

            return result;
        }
    }
}
