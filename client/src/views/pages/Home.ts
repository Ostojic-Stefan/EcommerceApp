export const Home: IPage = {
    render: async () => {
        const view = `
        <section class="section">
            <h1> Home </h1>
        </section>`;
        return view;
    },
    afterRender: async () => {}
}