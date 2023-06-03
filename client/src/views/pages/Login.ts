import { ApiHandler } from "../../ApiHandler";

class Login implements IPage {
    public async render(): Promise<string> {
        return `
        <div class="container login-container">
        <div class="wrapper">
            <h2>Login To Your Account</h2>
            <form>
                <div class="form-control">
                    <label for="email">Email Address</label>
                    <input type="email" id="email" />
                </div>
                <div class="form-control">
                    <label for="password">Password</label>
                    <input type="password" id="password" />
                </div>
                <button class="btn btn-login">Login</button>
            </form>
            <div>
                <span style="font-weight: bold;">Don't have an account?</span>
                <a href="/#/register">Create one right now</a>
            </div>
        </div>
    </div>`;
    }
    public async afterRender(): Promise<void> {
        const emailField = document.querySelector('#email') as HTMLInputElement;
        const passwordField = document.querySelector('#password') as HTMLInputElement;
        const credentials = {
            email: '',
            password: ''
        };

        emailField.addEventListener('input', (e) => {
            credentials.email = (e.target as HTMLInputElement).value;
        });

        passwordField.addEventListener('input', (e) => {
            credentials.password = (e.target as HTMLInputElement).value;
        });

        document.querySelector('.btn-login')?.addEventListener('click', async (e) => {
            e.preventDefault();
            try {
                const response = await ApiHandler.account.login(credentials);
                localStorage.setItem('userToken', JSON.stringify(response.token));
            } catch (error: any) {
                console.error(error.response.data);
            }
        });
    }
}

export default new Login();