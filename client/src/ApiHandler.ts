import axios, { AxiosResponse } from "../node_modules/axios/index";
import { LoginRequest, LoginResponse, RegisterRequest } from "./models/Account";
import { AddToBasket, Basket } from "./models/Basket";
import { Product } from "./models/Product";

axios.defaults.baseURL = "https://localhost:5001/api/";
axios.defaults.withCredentials = true;

const responseBody = <TResponse>(res: AxiosResponse<TResponse>) => res.data;

export interface PaginationParams {
    category?: string;
    searchTerm?: string;
}

const products = {
    getProducts: (paginationParams?: PaginationParams) => {
        let url = 'Products';
        if (paginationParams?.category) {
            url += `?Category=${paginationParams.category}`;
        }
        if (paginationParams?.searchTerm) {
            url += `?Search=${paginationParams.searchTerm}`;
        }
        return axios.get<Product[]>(url).then(responseBody<Product[]>);
    },
    getProduct: (id: number) => axios.get<Product>(`Products/${id}`).then(responseBody<Product>),
}

const basket = {
    addToBasket: (data: AddToBasket) => axios.post<Basket[]>("Basket", data).then(responseBody<Basket[]>),
    getCart: () => axios.get<Basket[]>("Basket").then(responseBody<Basket[]>)
}

const account = {
    login: (loginData: LoginRequest) => axios.post<LoginResponse>("Account/login", loginData).then(responseBody<LoginResponse>),
    register: (loginData: RegisterRequest) => axios.post("Account/register", loginData).then(responseBody),
}

export const ApiHandler = {
    products,
    basket,
    account,
}