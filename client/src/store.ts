import { configureStore } from '@reduxjs/toolkit';

import basketSlice from "./features/basket/basketSlice"

export const store = configureStore({
  reducer: {
    basket: basketSlice.reducer
  },
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch