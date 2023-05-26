namespace api
{
    public record AddProductDto(
        string Name,
        string Description,
        string Image,
        string Brand, 
        int InStock,
        decimal Price,
        int CatergoryId
    );

    public record AddBasketItemDto(
        int Quantity,
        int ProductId
    );

    public record ProductResponseDto(
        string Name,
        string Description, 
        string Image,
        string Brand, 
        int InStock, 
        decimal Price,
        int Quantity,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );

    public record BasketResponseDto(
        IEnumerable<ProductResponseDto> Products
    );
}
