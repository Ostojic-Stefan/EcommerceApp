import { DefaultNotFound } from "./Router/DefaultNotFound";
import { RouterBuilder } from "./Router/RouterBuilder";
import Home from "./views/pages/Home";
import SingleProduct from "./views/pages/SingleProduct";

const router = new RouterBuilder()
    .setHtmlId('page_container')
    .addRoute('/', Home)
    .addRoute('/product/:id', SingleProduct)
    .addNotFoundPage(DefaultNotFound)
    .build();

window.addEventListener('load', async () => {
    await router.process();
});

window.addEventListener('hashchange', async () => {
    await router.process();
});

