export const DefaultNotFound: IPage = {
    init(): void {

    },
    destroy(): void {
        
    },
    render: async function (): Promise<string> {
        const view = `
            <section class="section">
                <h1> 404 Page Not Found </h1>
                <p>Register a custom 404 page by adding:</p>
                <code>
                    const routerBuilder = new RouterBuilder().addNotFoundPage(MyCustom404Page);
                </code>
            </section>`;
        return view;
    },
    afterRender: async function (): Promise<void> {
    }
}