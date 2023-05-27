import { useState } from "react";
import { useAppDispatch } from "../store/configureStore";
import { addProductAsync } from "../store/productSlice";

function AddProduct() {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [image, setImage] = useState("");
  const [brand, setBrand] = useState("");
  const [inStock, setInStock] = useState(0);
  const [price, setPrice] = useState(0);
  const [category, setCategory] = useState(0);

  const dispatch = useAppDispatch();

  const submitForm = async (event: any) => {
    event.preventDefault();
    console.log(name);
    console.log(price);
    console.log(description);

    dispatch(
      addProductAsync({
        brand,
        categoryId: category,
        description,
        image,
        inStock,
        name,
        price,
      })
    );
  };

  return (
    <div>
      <h1>Add Product</h1>
      <form onSubmit={submitForm}>
        <div>
          <label htmlFor="">Name</label>
          <input
            type="text"
            value={name}
            onChange={(e) => {
              setName(e.target.value);
            }}
          />
        </div>
        <div>
          <label htmlFor="">Description</label>
          <input
            type="text"
            value={description}
            onChange={(e) => {
              setDescription(e.target.value);
            }}
          />
        </div>
        <div>
          <label htmlFor="">Image</label>
          <input
            type="text"
            value={image}
            onChange={(e) => {
              setImage(e.target.value);
            }}
          />
        </div>
        <div>
          <label htmlFor="">Brand</label>
          <input
            type="text"
            value={brand}
            onChange={(e) => {
              setBrand(e.target.value);
            }}
          />
        </div>
        <div>
          <label htmlFor="">InStock</label>
          <input
            type="number"
            value={inStock}
            onChange={(e) => {
              setInStock(parseInt(e.target.value));
            }}
          />
        </div>
        <div>
          <label htmlFor="">Price</label>
          <input
            type="number"
            min="1"
            step="any"
            value={price}
            onChange={(e) => {
              setPrice(parseFloat(e.target.value));
            }}
          />
        </div>
        <div>
          <label htmlFor="">Category</label>
          <input
            type="text"
            value={category}
            onChange={(e) => {
              setCategory(parseInt(e.target.value));
            }}
          />
        </div>
        <button>Add Product</button>
      </form>
    </div>
  );
}

export default AddProduct;
