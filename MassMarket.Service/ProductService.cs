using System;
using System.Collections.Generic;
using System.Linq;
using MassMarket.Common;
using MassMarket.Domain.Entities;
using MassMarket.Domain.Repositories;
using MassMarket.Service.Helpers;
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

            // Get all possible brand options before filtering by brand
            result.BrandOptions = foundProducts
                .SelectMany(p => p.MetaFields.Where(f => f.MetaFieldId == Constants.BrandMetaFieldId))
                .Select(f => f.Option).Distinct();

            // MetaFieldOption filter
            if (query.MetaFieldOptions.All(o => o != 0)) {
                foundProducts = foundProducts
                    .Where(p => query.MetaFieldOptions
                    .Any(o => p.MetaFields.Select(f => f.Option.Id).Contains(o)));
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

            result.TotalProductCount = foundProducts.Count();

            result.FoundProducts = foundProducts.OrderBy(query.Ordering);
            result.FoundProducts = result.FoundProducts.Skip((query.PageNr - 1) * 20).Take(20);

            return result;
        }
    }
}
