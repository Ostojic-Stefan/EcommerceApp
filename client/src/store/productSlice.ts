import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { AddProductDto, ProductResponseDto } from "../dtos/ProductDtos";
import { apiHandler } from "../apiHandler";

enum Status {
    Idle,
    Loading,
    Fulfilled,
    Rejected
}

interface ProductState {
    products: ProductResponseDto[];
    status: Status; 
}

const initialState: ProductState = {
    products: [],
    status: Status.Idle
}

export const getProductsAsync = createAsyncThunk<ProductResponseDto[]>(
    'products/getProductsAsync', async (_, thunkAPI) => {
        try {
            return await apiHandler.products.getAllProducts();
        } catch (error: any) {
            return thunkAPI.rejectWithValue({ error: error.data });
        }
    }
);

export const addProductAsync = createAsyncThunk(
    'products/addProductAsync', async (data: AddProductDto, thunkAPI) => {
        try {
            console.log(data);
            return await apiHandler.products.addProduct(data);
        } catch (error: any) {
            thunkAPI.rejectWithValue({ error: error.data });            
        }
    }
)

export const productSlice = createSlice({
    name: 'product',
    initialState: initialState,
    reducers: {

    },
    extraReducers: builder => {
        builder.addCase(getProductsAsync.pending, (state, action) => {
            state.status = Status.Loading;
        });
        builder.addCase(getProductsAsync.fulfilled, (state, action) => {
            state.status = Status.Fulfilled;
            state.products = action.payload;
        });
        builder.addCase(getProductsAsync.rejected, (state, action) => {
            state.status = Status.Rejected;
            console.error(action);
        });
        builder.addCase(addProductAsync.fulfilled, (state, action) => {
            console.log(action);
        });
        builder.addCase(addProductAsync.rejected, (state, action) => {
            console.log(action);
        });
    }
});