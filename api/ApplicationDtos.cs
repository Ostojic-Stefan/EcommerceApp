using api.QueryStringHelpers;
using System.ComponentModel.DataAnnotations;

namespace api
{
    public record AddProductDto(
        string Name,
        string Description,
        string Specifications,
        IFormFile ProductImage,
        string Brand, 
        int InStock,
        decimal Price,
        int CategoryId
    );

    public record AddBasketItemDto(
        int Quantity,
        int ProductId
    );

    public record BasketItemResponseDto(
        string Name,
        string Description, 
        string ImageUrl,
        string Brand, 
        int InStock, 
        decimal Price,
        int Quantity,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );

    public record BasketResponseDto(
        IEnumerable<BasketItemResponseDto> Products
    );

    public record CategoryResponseDto(
        string Name,
        string IconUrl
    );

    public record ProductResponseDto(
        int Id,
        string Name,
        string Description,
        string Specifications,
        string ImageUrl,
        string Brand,
        int InStock,
        decimal Price,
        CategoryResponseDto Category,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );

    public record UserRegisterDto(
        [Required]
        string Username,
        [Required][DataType(DataType.EmailAddress)]
        string Email,
        [Required]
        string Password
    );

    public record UserLoginDto(
    [Required][DataType(DataType.EmailAddress)]
    string Email,
    [Required]
    string Password
    );

    public record ProductPaginationParams(
        string? SearchTerm,
        FilterParams? FilterParams,
        PaginationParams? PaginationParams,
        string? SortTerm
    );

    public record PagedProductResponseDto(
        PaginationData PaginationData,
        IEnumerable<ProductResponseDto> Products
    );
}
