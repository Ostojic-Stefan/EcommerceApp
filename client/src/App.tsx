import { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "./store/configureStore";
import { getProductsAsync } from "./store/productSlice";
import ProductList from "./components/ProductList";
import { Outlet } from "react-router-dom";

function App() {
  const { products } = useAppSelector((state) => state.product);
  const dispatch = useAppDispatch();

  console.log(products);

  useEffect(() => {
    dispatch(getProductsAsync());
  }, []);

  return (
    <div>
      <ProductList />
    </div>
  );
}

export default App;
