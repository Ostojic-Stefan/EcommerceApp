import { About } from "./views/pages/About";
import { Home } from "./views/pages/Home";
import { DefaultNotFound } from "./Router/DefaultNotFound";
import { RouterBuilder } from "./Router/RouterBuilder";

const router = new RouterBuilder()
    .setHtmlId('page_container')
    .addRoute('/', Home)
    .addRoute('/about', About)
    .addNotFoundPage(DefaultNotFound)
    .build();

window.addEventListener('load', async () => {
    await router.process();
});

window.addEventListener('hashchange', async () => {
    await router.process();
});

