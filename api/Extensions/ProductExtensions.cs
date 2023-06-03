using api.Models;

namespace api.Extensions
{
    public static class ProductExtensions
    {
        private static readonly int MaxPageSize = 10;
        private static readonly int MinPageSize = 1;
        private static readonly int DefaultPageSize = 5;
        private static readonly int DefaultPageNumber = 1;

        public static IQueryable<Product> SearchProduct(this IQueryable<Product> products, string? searchTerm)
        {
            if (searchTerm is not null)
                return products.Where(x => x.Name.Contains(searchTerm));
            return products;
        }

        public static IQueryable<Product> GetPagedProducts(this IQueryable<Product> products, int? pageSize, int? pageNumber)
        {
            if (pageSize is null)
            {
                pageSize = DefaultPageSize;
            }
            else
            {
                if (pageSize > MaxPageSize)
                {
                    Math.Clamp(pageSize.Value, MinPageSize, MaxPageSize);
                }
            }
            if (pageNumber is null)
            {
                pageNumber = DefaultPageNumber;
            }
            return products
                .Skip((pageNumber.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);
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

        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, string? brands, string? categories)
        {
            if (brands is not null)
                products.Where(x => x.Brand == brands);
            if (categories is not null)
                products.Where(x => x.Category.Name == categories);
            return products;
        }
    }
}
