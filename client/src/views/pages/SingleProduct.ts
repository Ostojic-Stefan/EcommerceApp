import { ApiHandler } from "../../ApiHandler";

function convertSpecificationsToHtml(object: string) {
    return JSON.parse(object)
        .reduce((acc: string, { name, value }: {name: string, value: string}) => {
        return acc.concat(
            `<tr>
                <td>${name}</td>
                <td>${value}</td>
            </tr>`
        );
    }, '');
}

class SingleProduct implements IPage {
    public async render(): Promise<string> {
        const productId = Number.parseInt(location.hash.split('/')[2]);
        const product = await ApiHandler.products.getProduct(productId);
        

        return `
        <div class="single-product-container">
        <div class="single-product container">
            <div class="single-product left">
                <div class="img-container">
                    <img src="${product.imageUrl}"
                        alt="AMD-Ryzen-9-5900X">
                </div>
            </div>
            <div class="single-product right">
                <h2>${product.name}</h2>
                <div class="product-description">
                    <p>${product.description}</p>
                </div>
                <div class="price">
                    <div>
                        <span class="full-price">$${product.price}</span>
                    </div>
                    <div>|</div>
                    <div>
                        <span class="monthly-price">$${product.price}</span>
                        monthly
                    </div>
                </div>
                <div class="quantity">
                    <span>quantity:</span>
                    <div class="btn btn-decrease"><span>-</span></div>
                    <span>1</span>
                    <div class="btn btn-increase"><span>+</span></div>
                </div>
                <div class="add-to-cart-container">
                    <button id="add-to-cart-btn">Add To Cart</button>
                </div>
            </div>
        </div>

        <div class="specifications container">
            <h2>Specifications</h2>
            <table>
                <tbody>
                    ${convertSpecificationsToHtml(product.specifications)}
                </tbody>
            </table>
        </div>
    </div>
        `;
    }
    public async afterRender(): Promise<void> {

    }
}

export default new SingleProduct();
