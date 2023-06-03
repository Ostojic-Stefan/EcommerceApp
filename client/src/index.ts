import { DefaultNotFound } from "./Router/DefaultNotFound";
import { RouterBuilder } from "./Router/RouterBuilder";
import Home from "./views/pages/Home";
import Login from "./views/pages/Login";
import Register from "./views/pages/Register";
import SingleProduct from "./views/pages/SingleProduct";

const router = new RouterBuilder()
    .setHtmlId('page_container')
    .addRoute('/', Home)
    .addRoute('/product/:id', SingleProduct)
    .addRoute('/login', Login)
    .addRoute('/register', Register)
    .addNotFoundPage(DefaultNotFound)
    .build();

window.addEventListener('load', async () => {
    await router.process();
});

window.addEventListener('hashchange', async () => {
    await router.process();
});

