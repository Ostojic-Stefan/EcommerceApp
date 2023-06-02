import { Router } from "./Router";

export class RouterBuilder {
    public routes = new Map<string, IPage>();
    public htmlId = "output";
    public notFound?: IPage;

    public setHtmlId(htmlId: string) {
        this.htmlId = htmlId;
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
