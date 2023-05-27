namespace api
{
    public record AddProductDto(
        string Name,
        string Description,
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
        string Name,
        string Description,
        string ImageUrl,
        string Brand,
        int InStock,
        decimal Price,
        CategoryResponseDto Category,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
