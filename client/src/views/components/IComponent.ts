export interface IComponent {
    ContainerId: string;
    readonly ShouldReRender: boolean;
    render: () => Promise<string>;
    afterRender: () => Promise<void>;
}