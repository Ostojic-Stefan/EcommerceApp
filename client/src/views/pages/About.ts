export const About: IPage = {
    render: async () => {
        const view = `
        <section>
            <h1> About </h1>
        </section>
        `;
        return view;
    },
    afterRender: async () => {
    }
}