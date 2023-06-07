import { DefaultNotFound } from "./Router/DefaultNotFound";
import { RouterBuilder } from "./Router/RouterBuilder";
import Home from "./views/pages/Home";
import Login from "./views/pages/Login";
import Register from "./views/pages/Register";
import SingleProduct from "./views/pages/SingleProduct";
import { store } from "./store";
import Cart from "./views/pages/Cart";
import { getBasket } from "./features/basket/basketSlice";
import { getProducts } from "./features/product/productSlice";

store.dispatch(getBasket());
store.dispatch(getProducts());


const router = new RouterBuilder()
    .setHtmlId('page_container')
    .addRoute('/', Home)
    .addRoute('/product/:id', SingleProduct)
    .addRoute('/cart', Cart)
    .addRoute('/login', Login)
    .addRoute('/register', Register)
    .addNotFoundPage(DefaultNotFound)
    .build();

store.subscribe(() => {
    router.process();
});


['load', 'hashchange'].forEach(ev => {
    window.addEventListener(ev, async () => {
        await router.process();
    })
}); 


