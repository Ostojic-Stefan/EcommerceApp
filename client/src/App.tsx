import { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "./store/configureStore";
import { getProductsAsync } from "./store/productSlice";
import ProductList from "./components/ProductList";

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
