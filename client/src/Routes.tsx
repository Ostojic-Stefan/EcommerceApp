import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import AddProduct from "./components/AddProduct";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "addProduct",
    element: <AddProduct />,
  },
]);
