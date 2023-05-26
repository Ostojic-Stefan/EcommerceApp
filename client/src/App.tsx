import { useEffect, useState } from "react";
import { apiHandler } from "./apiHandler";
import { ProductResponseDto } from "./dtos/ProductDtos";

function App() {
  const [products, setProducts] = useState<ProductResponseDto[]>();
  useEffect(() => {
    apiHandler.products.getAllProducts().then((data) => {
      setProducts(data);
    });
  }, []);

  return (
    <div>
      {products?.map((product) => (
        <div key={product.id}>
          <h1>{product.name}</h1>
          <p>{product.description}</p>
        </div>
      ))}
    </div>
  );
}

export default App;
