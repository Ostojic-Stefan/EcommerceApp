import React from "react";
import SingleProduct from "./SingleProduct";
import { useAppSelector } from "../store/configureStore";

function ProductList() {
  const { products } = useAppSelector((state) => state.product);
  return (
    <div>
      <h1>Product List</h1>
      {products.map((product) => (
        <SingleProduct key={product.id} product={product} />
      ))}
    </div>
  );
}

export default ProductList;
