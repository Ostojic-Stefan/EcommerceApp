using api.Models;
using api.QueryStringHelpers;

namespace api.Extensions
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> SearchProduct(this IQueryable<Product> products, string? searchTerm)
        {
            if (searchTerm is not null)
                return products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            return products;
        }

        public static IQueryable<Product> SortProducts(this IQueryable<Product> products, string? sortTerm)
        {
            if (sortTerm is null)
                return products;

            return sortTerm switch
            {
                "Price" => products.OrderBy(x => x.Price),
                "PriceDesc" => products.OrderByDescending(x => x.Price),
                "Name" => products.OrderBy(x => x.Name),
                "NameDesc" => products.OrderByDescending(x => x.Name),
                "Brand" => products.OrderBy(x => x.Brand),
                "BrandDesc" => products.OrderByDescending(x => x.Brand),
                _ => products
            };
        }

        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, FilterParams? filterParams)
        {
            if (filterParams is null)
                return products;

            if (filterParams.Brands is not null)
                products = products.Where(x => x.Brand == filterParams.Brands);
            if (filterParams?.Category is not null)
                products = products.Where(x => x.CategoryId == (int)filterParams.Category);
            return products;
        }
    }
}
