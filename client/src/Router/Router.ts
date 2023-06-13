import { IComponent } from "../views/components/IComponent";
import { DefaultNotFound } from "./DefaultNotFound";
import { RouterBuilder } from "./RouterBuilder";

export class Router {
    private htmlContent?: HTMLDivElement;

    private routes = new Map<string, IPage>();
    private components = new Map<IComponent, string>();

    private defaultNotFound = DefaultNotFound;

    constructor(builder: RouterBuilder) {
        this.routes = builder.routes;
        this.components = builder.components;
        this.htmlContent = document.getElementById(builder.htmlId) as HTMLDivElement;
    }

    public async process() {
        const parsedURL = this.parseUrl();
        const page: IPage = this.routes.get(parsedURL) ? this.routes.get(parsedURL)! : this.defaultNotFound!;
        await this.render(page);
        this.renderComponents(page);
    }

    private async render(page: IPage) {
        if (!this.htmlContent)
            throw new Error("Html Content is not set up correctly");
        this.htmlContent.innerHTML = await page.render();
        await page.afterRender();
    }

    private renderComponents(page: IPage) {
        this.components.forEach((key: string, value: IComponent) => {
            const container = document.getElementById(value.ContainerId);
            container!.innerHTML = "";
            if (key === '*') {
                this.renderComponent(value);
                return;
            }
            if (key.split(' ').includes(page.constructor.name)) {
                this.renderComponent(value);
            }
        });
    }

    private async renderComponent(component: IComponent) {
        const container = document.getElementById(component.ContainerId);
        if (!container) {
            console.error(`container id ${component.ContainerId} does not exist`);
            return;
        }
        container.innerHTML = await component.render();
        await component.afterRender();
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
