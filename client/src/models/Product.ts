import { Category } from "./Category";

export interface PaginationData {
    totalItems: number;
    pageSize: number;
    pageCount: number;
}

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

export interface ProductResponse {
    paginationData: PaginationData;
    products: Product[];
}
