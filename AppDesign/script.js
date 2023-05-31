const mainPannel = document.querySelector(".main-pannel");

const products = [
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 49.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 19.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
  {
    name: "intel Core i5-13600K 3.5GHz (5.1GHz) - Processor",
    price: 69.999,
  },
];

let productsHtml = products.map((product) => {
  return `
    <div class="product-item">
<div class="img-and-text">
    <img src="./assets/AMD-Ryzen-9-5900X.png"
        alt="AMD-Ryzen-9-5900X">
    <h3>${product.name}</h3>
    <div class="protuct-icon-heart">
        <svg width="23" height="18"
            viewBox="0 0 22 18"
            xmlns="http://www.w3.org/2000/svg"><path
                d="M0 6.09922V5.89332C0 3.01078 2.14844 0.540025 5.11328 0.0870541C7.04688 -0.242379 9.06641 0.375308 10.4844 1.73422L11 2.18719L11.4727 1.73422C12.8906 0.375308 14.9102 -0.242379 16.8438 0.0870541C19.8086 0.540025 22 3.01078 22 5.89332V6.09922C22 7.82874 21.2266 9.47591 19.9375 10.6289L12.1602 17.5882C11.8594 17.8765 11.4297 18 11 18C10.5273 18 10.0977 17.8765 9.79688 17.5882L2.01953 10.6289C0.730469 9.47591 0 7.82874 0 6.09922Z"
                opacity="0.25"></path></svg>
    </div>
</div>
<div class="bottom">
    <span class="price">
        ${product.price} RSD
    </span>
    <svg width="23" height="21" viewBox="0 0 23 21"
        fill="none"
        xmlns="http://www.w3.org/2000/svg">
        <path
            d="M3.75 0.5C4.17969 0.5 4.57031 0.851562 4.64844 1.28125L4.72656 1.75H21.1328C21.9531 1.75 22.5781 2.57031 22.3438 3.35156L20.2344 10.8516C20.0781 11.3984 19.6094 11.75 19.0234 11.75H6.64062L6.99219 13.625H19.0625C19.5703 13.625 20 14.0547 20 14.5625C20 15.1094 19.5703 15.5 19.0625 15.5H6.21094C5.78125 15.5 5.39062 15.1875 5.3125 14.7578L2.96875 2.375H0.9375C0.390625 2.375 0 1.98438 0 1.4375C0 0.929688 0.390625 0.5 0.9375 0.5H3.75ZM18.5547 9.875L20.3125 3.625H5.11719L6.28906 9.875H18.5547ZM5 18.625C5 17.6094 5.82031 16.75 6.875 16.75C7.89062 16.75 8.75 17.6094 8.75 18.625C8.75 19.6797 7.89062 20.5 6.875 20.5C5.82031 20.5 5 19.6797 5 18.625ZM20 18.625C20 19.6797 19.1406 20.5 18.125 20.5C17.0703 20.5 16.25 19.6797 16.25 18.625C16.25 17.6094 17.0703 16.75 18.125 16.75C19.1406 16.75 20 17.6094 20 18.625Z">
        </path>
    </svg>
</div>
</div>
    `;
});

productsHtml = productsHtml.join("");

mainPannel.insertAdjacentHTML("afterbegin", productsHtml);
