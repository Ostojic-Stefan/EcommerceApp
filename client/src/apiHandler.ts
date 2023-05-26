import axios, { AxiosResponse } from 'axios'
import { ProductResponseDto } from './dtos/ProductDtos';

axios.defaults.baseURL = "https://localhost:5001/api";
axios.defaults.withCredentials = true;

const responseBody = <TResponse>(res: AxiosResponse<TResponse>) => res.data;

const products = {
    getAllProducts: () => axios.get<ProductResponseDto[]>("products")
        .then(responseBody<ProductResponseDto[]>),
    getProduct: (productId: number) => axios.get<ProductResponseDto>(`products/${productId}`)
        .then(responseBody<ProductResponseDto>)
}

export const apiHandler = {
    products
}