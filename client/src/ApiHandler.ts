import axios, { AxiosResponse } from "../node_modules/axios/index";
import { LoginRequest, LoginResponse, RegisterRequest } from "./models/Account";
import { Product } from "./models/Product";

axios.defaults.baseURL = "https://localhost:5001/api/";
axios.defaults.withCredentials = true;

const responseBody = <TResponse>(res: AxiosResponse<TResponse>) => res.data;

const products = {
    getProducts: () => axios.get<Product[]>("Products").then(responseBody<Product[]>),
    getProduct: (id: number) => axios.get<Product>(`Products/${id}`).then(responseBody<Product>),
}

const account = {
    login: (loginData: LoginRequest) => axios.post<LoginResponse>("Account/login", loginData).then(responseBody<LoginResponse>),
    register: (loginData: RegisterRequest) => axios.post("Account/register", loginData).then(responseBody),
}

export const ApiHandler = {
    products,
    account
}