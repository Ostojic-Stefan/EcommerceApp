import axios, { AxiosResponse } from "../node_modules/axios/index";
import { LoginRequest, LoginResponse, RegisterRequest } from "./models/Account";
import { AddToBasket, Basket } from "./models/Basket";
import { Product, ProductResponse } from "./models/Product";

axios.defaults.baseURL = "https://localhost:5001/api/";
axios.defaults.withCredentials = true;

const responseBody = <TResponse>(res: AxiosResponse<TResponse>) => res.data;

export interface PaginationParams {
    category?: string;
    searchTerm?: string;
    pageNumber?: number;
    pageSize?: number;
}

class UrlBuilder {
    private url: string;
    private baseUrl: string;
    private queryParams = new Map<string, string>();
    private paths: string[] = []; 

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
        this.url = this.baseUrl;
    }

    public addPath(path: string): void {
        if (this.paths.find(val => val === path))
            return;
        this.paths.push(`${path}`);
    }

    public addQueryParam(key: string, val: string): void {
        this.queryParams.set(key, val);
    }

    public removeQueryParam(key: string) {
        this.queryParams.delete(key);
    }

    public build(): string {
        this.url = this.baseUrl;

        this.paths.forEach(path => {
            this.url += path;
        });

        let idx = 0;
        this.queryParams.forEach((value, key) => {
            const prefix = idx !== 0 ? '&' : '?';
            this.url += `${prefix}${key}=${value}`;
            ++idx;
        });
        
        return this.url;
    }

    public getCurrentUrlState() {
        return this.url;
    }
}

const urlBuilder = new UrlBuilder(axios.defaults.baseURL!);

const products = {
    getProducts: (paginationParams?: PaginationParams) => {
        urlBuilder.addPath("Products");
        
        if (paginationParams?.category) 
            urlBuilder.addQueryParam("FilterParams.Category", paginationParams.category);
        if (paginationParams?.searchTerm)
            urlBuilder.addQueryParam("SearchTerm", paginationParams.searchTerm);
        if (paginationParams?.pageSize)
            urlBuilder.addQueryParam("PaginationParams.PageSize", paginationParams.pageSize.toString());
        if (paginationParams?.pageNumber)
            urlBuilder.addQueryParam("PaginationParams.PageNumber", paginationParams.pageNumber.toString());

        const url = urlBuilder.build();

        return axios.get<ProductResponse>(url).then(responseBody<ProductResponse>);
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