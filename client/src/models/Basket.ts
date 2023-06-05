export interface AddToBasket {
    productId: number;
    quantity: number;
}

export interface Basket {
    name: string;
    description: string;
    imageUrl: string;
    brand: string;
    inStock: number;
    price: number;
    quantity: number;
    createdAt: Date;
    updatedAt: Date;
}
