import { ProductResponseDto } from "../dtos/ProductDtos";

interface Props {
  product: ProductResponseDto;
}

function SingleProduct({ product }: Props) {
  return (
    <div>
      <h1>
        {product.name} - {product.brand}
      </h1>
      <p>{product.description}</p>
    </div>
  );
}

export default SingleProduct;
