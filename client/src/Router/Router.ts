import { DefaultNotFound } from "./DefaultNotFound";
import { RouterBuilder } from "./RouterBuilder";

export class Router {
    private htmlContent?: HTMLDivElement;
    private routes = new Map<string, IPage>();
    private defaultNotFound = DefaultNotFound;

    constructor(builder: RouterBuilder) {
        this.routes = builder.routes;
        this.htmlContent = document.getElementById(builder.htmlId) as HTMLDivElement;
    }

    public async process() {
        const parsedURL = this.parseUrl();
        const page: IPage = this.routes.get(parsedURL) ? this.routes.get(parsedURL)! : this.defaultNotFound!;
        console.log(parsedURL);
        await this.render(page);
    }

    private async render(page: IPage) {
        if (!this.htmlContent)
            throw new Error("Html Content is not set up correctly");
        this.htmlContent.innerHTML = await page.render();
    }

    private parseUrl(): string {
        const hash = window.location.hash.slice(1).toLowerCase() || '/';
        const r = hash.split('/');
        const routes = {
            resource: r[1],
            id: r[2]
        }
        let parsedURL = '';
        if (routes.resource) parsedURL = "/" + routes.resource;
        else parsedURL = "/";
        if (routes.id) parsedURL += "/:id";
        return parsedURL;
    }
}
