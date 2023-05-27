export interface ProductResponseDto {
    id: number;
    name: string;
    description: string;
    image: string;
    brand: string;
    inStock: number;
    price: number;
    quantity: number;
    CreatedAt: Date;
    UpdatedAt: Date;
};

export interface AddProductDto {
    name: string;
    description: string;
    image: string;
    brand: string;
    inStock: number;
    price: number;
    categoryId: number;
}