import { BasketState } from "../../features/basket/basketSlice";
import { store } from "../../store";

class Cart implements IPage {
    public async render(): Promise<string> {
        let basket: BasketState = store.getState().basket;

        if (basket === null)
            return "Loading...";

        const totalPrice = basket.basketItems.reduce((acc, basketItem) => {
            return acc + (basketItem.price * basketItem.quantity);
        }, 0);

        const view = `
        <section class="container cart-items">
            <div class="products">
            ${
                basket.basketItems.map(basketItem => {
                return `
                    <div class="product">
                        <img src="https://localhost:5001/${basketItem.imageUrl}" alt="img">
                        <div>Quantity: ${basketItem.quantity}</div>
                        <span>Price: ${basketItem.price}</span>
                    </div>`;
            })}
            </div>
            <div class="summary">
                <div class="total-cost">
                    <h2>Total Cost</h2>
                    <span>$${totalPrice}</span>
                </div>
                <button>Proceed</button>
            </div>
        </section>`;
        return view;
    }
    public async afterRender(): Promise<void> {
    }
}

export default new Cart();
