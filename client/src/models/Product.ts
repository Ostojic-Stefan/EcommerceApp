import { Category } from "./Category";

export interface Product {
    id: number;
    name: string;
    description: string;
    specifications: string;
    imageUrl: string;
    brand: string;
    inStock: number;
    price: number;
    category: Category;
    createdAt: Date
}