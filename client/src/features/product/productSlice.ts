import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { ApiHandler, PaginationParams } from "../../ApiHandler";
import { PaginationData, Product, ProductResponse } from "../../models/Product";

export interface ProductState {
    pagination: PaginationData | null;
    products: Product[];
    pageNumber: number; // TODO
}

const initialState: ProductState = {
    products: [],
    pagination: null,
    pageNumber: 0
}

export const getProducts = createAsyncThunk<ProductResponse, PaginationParams | undefined>(
    // @ts-ignore
    'product/getProducts', async (paginationParams, thunkAPI) => {
        try {
            const result = await ApiHandler.products.getProducts(paginationParams);
            return result;            
        } catch (error: any) {
            thunkAPI.rejectWithValue(error.message);
        }
    }
)

const productSlice = createSlice({
    name: 'product',
    initialState,
    reducers: {
        incrementPageNumber(state) {
            state.pageNumber += 1;
        },
        decrementPageNumber(state) {
            state.pageNumber -= 1;
        }
    },
    extraReducers: builder => {
        builder.addCase(getProducts.fulfilled, (state, action) => {
            state.products = action.payload.products;
            state.pagination = action.payload.paginationData;
        });
        builder.addCase(getProducts.rejected, (state, action) => {
            console.error("getProducts REJECTED");
        })
    }
})
export const { incrementPageNumber, decrementPageNumber } = productSlice.actions;
export default productSlice;