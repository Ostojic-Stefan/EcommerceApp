interface IPage {
    render: () => Promise<string>;
    afterRender: () => Promise<void>;
}