import { ApiHandler } from "../../ApiHandler";

class Register implements IPage {
    public async render(): Promise<string> {
        return `
        <div class="container login-container">
        <div class="wrapper">
            <h2>Register</h2>
            <form>
                <div class="form-control">
                    <label for="email">Email Address</label>
                    <input type="email" id="email" />
                </div>
                <div class="form-control">
                    <label for="password">Password</label>
                    <input type="password" id="password" />
                </div>
                <button class="btn btn-register">Register</button>
            </form>
            <div>
                <span style="font-weight: bold;">Already have an account?</span>
                <a href="/#/login">login instead</a>
            </div>
        </div>
    </div>`;
    }
    public async afterRender(): Promise<void> {
        const emailField = document.querySelector('#email') as HTMLInputElement;
        const passwordField = document.querySelector('#password') as HTMLInputElement;
        const credentials = {
            userName: 'crapola',
            email: '',
            password: ''
        };

        emailField.addEventListener('input', (e) => {
            credentials.email = (e.target as HTMLInputElement).value;
        });

        passwordField.addEventListener('input', (e) => {
            credentials.password = (e.target as HTMLInputElement).value;
        });

        document.querySelector('.btn-register')?.addEventListener('click', async (e) => {
            e.preventDefault();
            try {
                const response = await ApiHandler.account.register(credentials);
                console.log(response);
            } catch (error: any) {
                console.error(error);
            }
        });
    }
}

export default new Register();