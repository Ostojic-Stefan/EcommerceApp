interface IPage {
    render: () => Promise<string>;
    afterRender: () => Promise<void>;
    init: () => void;
    destroy:() => void;
}