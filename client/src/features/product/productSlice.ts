import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { ApiHandler, PaginationParams } from "../../ApiHandler";
import { Product } from "../../models/Product";

export interface ProductState {
    products: Product[];
}

const initialState: ProductState = {
    products: []
}

export const getProducts = createAsyncThunk<Product[], PaginationParams | undefined>(
    // @ts-ignore
    'product/getProducts', async (paginationParams, thunkAPI) => {
        try {
            const result = await ApiHandler.products.getProducts(paginationParams);
            console.log(result);
            return result;            
        } catch (error: any) {
            thunkAPI.rejectWithValue(error.message);
        }
    }
)

const productSlice = createSlice({
    name: 'product',
    initialState,
    reducers: {},
    extraReducers: builder => {
        builder.addCase(getProducts.fulfilled, (state, action) => {
            state.products = action.payload;
        });
        builder.addCase(getProducts.rejected, (state, action) => {
            console.error("getProducts REJECTED");
        })
    }
})

export default productSlice;