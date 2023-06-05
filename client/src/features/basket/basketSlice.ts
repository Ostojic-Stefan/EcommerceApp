import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { Basket } from "../../models/Basket";
import { ApiHandler } from "../../ApiHandler";

export interface BasketState {
    basketItems: Basket[]
}

const initialState: BasketState = {
    basketItems: []
}

export const addToBasket = createAsyncThunk<Basket[], { productId: number }>(
    'basket/addToBasket',
    // @ts-ignore
    async ({ productId }, thunkAPI) => {
    try {
        const result = await ApiHandler.basket.addToBasket({ quantity: 1, productId: productId });
        console.log(result);
        return result;
    } catch (error: any) {
        thunkAPI.rejectWithValue(error.message);
    }
});

export const getBasket = createAsyncThunk<Basket[]>(
    'basket/getBasket',
    // @ts-ignore
    async (_, thunkAPI) => {
    try {
        const result = await ApiHandler.basket.getCart();
        return result;
    } catch (error: any) {
        thunkAPI.rejectWithValue(error.message);
    }
});

const basketSlice = createSlice({
    name: 'basket',
    initialState,
    reducers: {
    },
    extraReducers: builder => {
        builder.addCase(addToBasket.pending, (state, action) => {
            console.log('loading...');
        });
        builder.addCase(addToBasket.fulfilled, (state, action) => {
            state.basketItems = action.payload;
            console.log('fulfilled');
        });
        builder.addCase(addToBasket.rejected, (state, action) => {
            console.log('REJECTED: FAILED TO ADD ITEM TO BASKET');
        });
        builder.addCase(getBasket.pending, (state, action) => {
            console.log('Getting Basket...');
        });
        builder.addCase(getBasket.fulfilled, (state, action) => {
            state.basketItems = action.payload;
        });
        builder.addCase(getBasket.rejected, (state, action) => {
            console.log('REJECTED: FAILED TO GET BASKET');
        });
    }
})

export default basketSlice;