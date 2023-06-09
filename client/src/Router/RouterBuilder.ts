import { IComponent } from "../views/components/IComponent";
import { Router } from "./Router";

export class RouterBuilder {
    public routes = new Map<string, IPage>();
    public components = new Map<IComponent, string>();
    public htmlId = "output";
    public notFound?: IPage;

    public setHtmlId(htmlId: string) {
        this.htmlId = htmlId;
        return this;
    }

    public addComponent({ component, pages } : { component: IComponent, pages?: IPage[] }) {
        let pattern = "";
        if (!pages) {
            pattern = '*';
        } else {
            pattern = pages.reduce((acc, curr) => {
                return acc + ' ' + curr.constructor.name;
            }, '').trimStart();
        }
        this.components.set(component, pattern);
        return this;
    }

    public addRoute(path: string, page: IPage) {
        this.routes.set(path, page);
        return this;
    }

    public addNotFoundPage(page: IPage) {
        this.notFound = page;
        return this;
    }

    public build(): Router {
        return new Router(this);
    }
}
