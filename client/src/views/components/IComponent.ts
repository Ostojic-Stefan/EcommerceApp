export interface IComponent {
    ContainerId: string;
    render: () => Promise<string>;
    afterRender: () => Promise<void>;
}