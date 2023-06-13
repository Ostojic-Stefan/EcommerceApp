import { getProducts } from "../../features/product/productSlice";
import { store } from "../../store";
import { IComponent } from "./IComponent";

class Header implements IComponent {
    public ContainerId: string = "header-container";

    async render(): Promise<string> {
        return `<div class="header-container container">
        <a class="nostyle" href="/#/">
            <div class="logo">
                <svg width="135" height="40" viewBox="0 0 118 35"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"><path
                        fill-rule="evenodd"
                        clip-rule="evenodd"
                        d="M7.06924 23.6282C3.20456 23.6282 0.0429688 20.477 0.0429688 16.6273V7.00024C0.0429688 3.15058 3.20456 -0.000606537 7.06924 -0.000606537V4.50089C5.8079 4.54605 4.7897 5.58801 4.7897 6.85546V16.9489C4.7897 18.2162 5.8079 19.2582 7.06924 19.3024V23.6282ZM7.66534 13.6816H10.0602V16.9489C10.0602 18.2329 9.01387 19.2858 7.72861 19.3037V23.6282C11.5927 23.6282 14.755 20.477 14.755 16.6273V9.77359H12.3863H10.0602H7.66534V13.6816ZM7.72861 -0.000606537C11.5627 -0.000606537 14.7046 3.10086 14.7534 6.90955L10.0602 7.22016V6.85546C10.0602 5.57041 9.01387 4.51737 7.72861 4.49978V-0.000606537ZM16.9208 0.302084H21.7684V23.2482H16.9208V0.302084ZM30.971 23.6282C27.1061 23.6282 23.9441 20.477 23.9441 16.6273V7.00024C23.9441 3.15058 27.1061 -0.000606537 30.971 -0.000606537V4.50089C29.7089 4.54605 28.6909 5.58801 28.6909 6.85546V16.9489C28.6909 18.2162 29.7089 19.2582 30.971 19.3024V23.6282ZM31.566 13.6816H33.9607V16.9489C33.9607 18.2329 32.9145 19.2858 31.6292 19.3037V23.6282C35.4939 23.6282 38.6557 20.477 38.6557 16.6273V9.77359H36.2873H33.9607H31.566V13.6816ZM31.6292 -0.000606537C35.4635 -0.000606537 38.6052 3.10086 38.6544 6.90955L33.9607 7.22016V6.85546C33.9607 5.57041 32.9145 4.51737 31.6292 4.49978V-0.000606537ZM43.2788 5.58251L39.2029 23.2482H44.0508L44.7057 20.4118H49.3017L48.4524 16.5589H45.595L46.927 10.7858L46.456 8.74598C46.1384 7.37043 45.2185 5.56482 43.5739 5.58037L43.2788 5.58251ZM44.552 0.302084H50.0451L55.339 23.2482H50.4917L47.1103 8.59561C46.7277 6.93832 45.5983 4.89203 43.5678 4.91075L44.552 0.302084ZM68.2896 4.75172H53.8087V0.302084H68.2896V4.75172ZM58.6249 5.38708H63.4731V23.2482H58.6249V5.38708ZM69.7617 0.302084H74.6101V23.2482H69.7617V0.302084ZM77.8051 0.302084H75.2157V4.80247H77.2962C78.7201 4.80247 79.8856 5.96266 79.8856 7.38253V7.68187C79.8856 9.10174 78.7201 10.263 77.2962 10.263H75.2157V14.7623H77.8051C81.5767 14.7623 84.663 11.6873 84.663 7.92944V7.13496C84.663 3.3771 81.5767 0.302084 77.8051 0.302084ZM81.7508 14.1436L85.0721 23.2482H79.841L76.9777 15.3977H77.6178C79.1424 15.3977 80.5652 14.9348 81.7508 14.1436ZM93.2302 23.6282C89.3644 23.6282 86.2027 20.477 86.2027 16.6273V7.00024C86.2027 3.15058 89.3644 -0.000606537 93.2302 -0.000606537V4.50089C91.9681 4.54605 90.9492 5.58801 90.9492 6.85546V16.9489C90.9492 18.2162 91.9681 19.2582 93.2302 19.3024V23.6282ZM93.9844 23.6282C97.8491 23.6282 101.012 20.477 101.012 16.6273V7.00024C101.012 3.15058 97.8491 -0.000606537 93.9844 -0.000606537V4.50089C95.2463 4.54605 96.2657 5.58801 96.2657 6.85546V16.9489C96.2657 18.2162 95.2463 19.2582 93.9844 19.3024V23.6282ZM103.186 23.2482H107.893V12.7381L106.031 7.79797C105.49 6.36367 104.68 5.66882 103.186 5.50188V23.2482ZM103.158 0.302084H108.587L114.16 15.0694C114.789 16.7355 115.506 18.4693 118 18.7964V23.2482H112.571L106.658 7.5626C105.956 5.6974 104.796 4.98151 103.154 4.82565L103.158 0.302084ZM113.293 0.302084H118V18.1202C116.02 17.8264 115.427 16.5235 114.789 14.834L113.293 10.8707V0.302084Z"
                        fill="#FFC220"></path><path
                        d="M1.4802 33.9631L0 27.292H1.70868L2.10601 30.0633C2.20535 30.7661 2.31468 31.5184 2.39411 32.2706H2.41401C2.49344 31.5085 2.57297 30.7661 2.6723 30.0337L3.04973 27.292H4.74851L3.22859 33.9631H1.4802Z"
                        fill="white"></path><path
                        d="M7.32161 31.4688L7.15275 30.2019C7.10313 29.8259 7.0137 29.1033 6.95408 28.6875H6.93418C6.86466 29.1033 6.76532 29.8455 6.7057 30.2019L6.50703 31.4688H7.32161ZM6.35799 32.6467L6.12951 33.9631H4.6394L6.05998 27.292H7.92761L9.14953 33.9631H7.65942L7.44085 32.6467H6.35799Z"
                        fill="white"></path><path
                        d="M11.0663 26.9356L10.2417 25.7973H11.3146L11.6425 26.2922H11.6623L11.9901 25.7973H13.0233L12.2385 26.9356H11.0663ZM9.63574 33.0723L11.6822 28.6578V28.6281H9.83441V27.2919H13.4107V28.44L11.4836 32.5972V32.6269H13.4008V33.9631H9.63574V33.0723Z"
                        fill="white"></path><path
                        d="M14.1064 33.9631V27.292H15.5071L16.4509 29.6872C16.6198 30.1128 16.9377 30.9542 17.1066 31.4688H17.1264C17.0867 30.9244 16.9774 29.6278 16.9774 28.3708V27.292H18.3186V33.9631H16.9178L16.0138 31.7163C15.8052 31.2016 15.4972 30.3207 15.378 29.8258H15.3582C15.388 30.3999 15.4476 31.5085 15.4476 32.8149V33.9631H14.1064Z"
                        fill="white"></path><path
                        d="M20.7025 30.6281C20.7025 32.2019 20.9906 32.7167 21.378 32.7167C21.7952 32.7167 21.9939 31.9248 21.9939 30.5588C21.9939 29.4107 21.8349 28.5396 21.3681 28.5396C20.9906 28.5396 20.7025 29.1633 20.7025 30.6281ZM23.5933 30.4797C23.5933 33.0037 22.6793 34.043 21.3283 34.043C19.6395 34.043 19.103 32.2613 19.103 30.6084C19.103 28.9554 19.7985 27.2133 21.4177 27.2133C23.2356 27.2133 23.5933 29.2128 23.5933 30.4797Z"
                        fill="white"></path><path
                        d="M26.464 27.2926H28.0038V31.7269C28.0038 33.8352 26.9309 34.043 25.9871 34.043C25.6891 34.043 25.4109 33.9935 25.262 33.934L25.3911 32.6474C25.5203 32.687 25.6593 32.7067 25.8382 32.7067C26.1461 32.7067 26.464 32.5781 26.464 31.8061V27.2926Z"
                        fill="white"></path><path
                        d="M32.0467 31.1323H30.5864V32.6368H32.2256V33.9631H29.0466V27.292H32.1163V28.6183H30.5864V29.8654H32.0467V31.1323Z"
                        fill="white"></path><path
                        d="M38.6232 33.7869C38.3351 33.8957 37.6695 34.0244 37.1529 34.0244C36.3085 34.0244 35.7125 33.7869 35.2754 33.3613C34.6595 32.7773 34.3615 31.7677 34.3813 30.6492C34.4211 28.2935 35.8317 27.2345 37.3616 27.2345C37.908 27.2345 38.3053 27.3433 38.514 27.4423L38.2656 28.7587C38.0668 28.6597 37.8087 28.6102 37.5006 28.6102C36.5966 28.6102 35.9807 29.1942 35.9807 30.7878C35.9807 32.1933 36.537 32.7376 37.0536 32.7376C37.1132 32.7376 37.1728 32.7376 37.2225 32.7179V31.3619H36.7357V30.1148H38.6232V33.7869Z"
                        fill="white"></path><path
                        d="M41.1061 32.7575C41.1557 32.7773 41.2451 32.7773 41.3147 32.7773C41.8511 32.7773 42.2783 32.1637 42.2783 30.5107C42.2783 29.2735 41.9902 28.4816 41.3246 28.4816C41.2451 28.4816 41.1756 28.4816 41.1061 28.5113V32.7575ZM39.5762 27.3928C39.914 27.3236 40.4504 27.2642 41.0266 27.2642C41.9306 27.2642 42.5565 27.472 43.0134 27.8977C43.6095 28.442 43.8677 29.3329 43.8677 30.5799C43.8677 31.8568 43.53 32.8665 42.8843 33.4108C42.4174 33.8166 41.7518 34.0244 40.7485 34.0244C40.2915 34.0244 39.8445 33.975 39.5762 33.9453V27.3928Z"
                        fill="white"></path><path
                        d="M47.6527 31.1323H46.1924V32.6368H47.8316V33.9631H44.6526V27.292H47.7222V28.6183H46.1924V29.8654H47.6527V31.1323Z"
                        fill="white"></path><path
                        d="M50.3347 27.292H51.8646V30.2218H51.8943C51.9838 29.9347 52.0732 29.6377 52.1824 29.3309L52.9176 27.292H54.6064L53.166 30.2218L54.6164 33.9631H52.9375L52.1328 31.3995L51.8646 31.9044V33.9631H50.3347V27.292Z"
                        fill="white"></path><path
                        d="M56.6128 27.2926V31.5685C56.6128 32.4495 56.8512 32.7067 57.1294 32.7067C57.4175 32.7067 57.646 32.5088 57.646 31.5685V27.2926H59.1857V31.2913C59.1857 33.0037 58.5599 34.043 57.1393 34.043C55.5697 34.043 55.073 32.9442 55.073 31.2715V27.2926H56.6128Z"
                        fill="white"></path><path
                        d="M61.7981 30.3503C61.8577 30.3602 61.9174 30.3602 61.977 30.3602C62.5929 30.3602 62.7916 29.905 62.7916 29.42C62.7916 28.8855 62.573 28.4896 62.0763 28.4896C61.977 28.4896 61.8677 28.5093 61.7981 28.539V30.3503ZM60.2683 27.3909C60.6656 27.3116 61.2121 27.2622 61.7385 27.2622C62.5829 27.2622 63.2287 27.3613 63.7055 27.7868C64.1326 28.153 64.3115 28.727 64.3115 29.2815C64.3115 30.0535 64.0631 30.6078 63.6758 30.9937C63.2386 31.4094 62.5433 31.5876 62.0266 31.5876H61.7981V33.9631H60.2683V27.3909Z"
                        fill="white"></path><path
                        d="M66.5467 27.2926V31.5685C66.5467 32.4495 66.7851 32.7067 67.0632 32.7067C67.3513 32.7067 67.5798 32.5088 67.5798 31.5685V27.2926H69.1195V31.2913C69.1195 33.0037 68.4937 34.043 67.0731 34.043C65.5036 34.043 65.0068 32.9442 65.0068 31.2715V27.2926H66.5467Z"
                        fill="white"></path><path
                        d="M70.6993 27.2926H72.2391V31.7269C72.2391 33.8352 71.1662 34.043 70.2225 34.043C69.9245 34.043 69.6463 33.9935 69.4973 33.934L69.6265 32.6474C69.7555 32.687 69.8947 32.7067 70.0735 32.7067C70.3814 32.7067 70.6993 32.5781 70.6993 31.8061V27.2926Z"
                        fill="white"></path><path
                        d="M76.2821 31.1323H74.8217V32.6368H76.4609V33.9631H73.282V27.292H76.3516V28.6183H74.8217V29.8654H76.2821V31.1323Z"
                        fill="white"></path><path
                        d="M78.0698 28.7173H76.9075V27.2919H80.7818V28.7173H79.6096V33.9631H78.0698V28.7173Z"
                        fill="white"></path><path
                        d="M84.4479 31.1323H82.9875V32.6368H84.6266V33.9631H81.4478V27.292H84.5174V28.6183H82.9875V29.8654H84.4479V31.1323Z"
                        fill="white"></path><path
                        d="M87.8249 28.7173H86.6626V27.2919H90.5369V28.7173H89.3647V33.9631H87.8249V28.7173Z"
                        fill="white"></path><path
                        d="M94.2025 31.1323H92.7421V32.6368H94.3813V33.9631H91.2024V27.292H94.272V28.6183H92.7421V29.8654H94.2025V31.1323Z"
                        fill="white"></path><path
                        d="M96.8345 27.292V29.8853H97.967V27.292H99.5068V33.9631H97.967V31.3105H96.8345V33.9631H95.2947V27.292H96.8345Z"
                        fill="white"></path><path
                        d="M100.64 33.9631V27.292H102.04L102.984 29.6872C103.153 30.1128 103.471 30.9542 103.64 31.4688H103.66C103.62 30.9244 103.511 29.6278 103.511 28.3708V27.292H104.852V33.9631H103.451L102.547 31.7163C102.338 31.2016 102.03 30.3207 101.911 29.8258H101.891C101.921 30.3999 101.981 31.5085 101.981 32.8149V33.9631H100.64Z"
                        fill="white"></path><path
                        d="M107.524 33.9619H105.984V27.2908H107.524V33.9619Z"
                        fill="white"></path><path
                        d="M108.656 27.292H110.186V30.2218H110.216C110.305 29.9347 110.395 29.6377 110.504 29.3309L111.239 27.292H112.928L111.488 30.2218L112.938 33.9631H111.259L110.454 31.3995L110.186 31.9044V33.9631H108.656V27.292Z"
                        fill="white"></path><path
                        d="M114.935 27.2926V31.5685C114.935 32.4495 115.173 32.7067 115.451 32.7067C115.739 32.7067 115.968 32.5088 115.968 31.5685V27.2926H117.507V31.2913C117.507 33.0037 116.882 34.043 115.461 34.043C113.892 34.043 113.395 32.9442 113.395 31.2715V27.2926H114.935Z"
                        fill="white"></path>
                </svg>
            </div>
        </a>
        <div class="search">
            <input id='search' type="text" placeholder="Search for a product">
            <i class="search-icon fa fa-search"></i>
        </div>
        <div class="right">
            <div>
                <a class="nostyle" href="/#/login">Login</a>
            </div>
            <a href="/#/checkout" class="nostyle">
                <a class="nostyle" href="/#/cart">
                    <div class="cart">
                        <i>
                            <svg width="23" height="21"
                                viewBox="0 0 23 21"
                                fill="none"
                                xmlns="http://www.w3.org/2000/svg">
                                <path
                                    d="M3.125 0.239258C3.39844 0.239258 3.63281 0.473633 3.71094 0.74707L3.90625 1.48926H21.1328C21.9531 1.48926 22.5781 2.30957 22.3438 3.09082L20.2344 10.5908C20.0781 11.1377 19.6094 11.4893 19.0234 11.4893H6.17188L6.71875 13.9893H19.375C19.6875 13.9893 20 14.3018 20 14.6143C20 14.9658 19.6875 15.2393 19.375 15.2393H6.25C5.9375 15.2393 5.70312 15.0439 5.625 14.7705L2.61719 1.48926H0.625C0.273438 1.48926 0 1.21582 0 0.864258C0 0.551758 0.273438 0.239258 0.625 0.239258H3.125ZM4.17969 2.73926L5.85938 10.2393H19.0234L21.1328 2.73926H4.17969ZM5 18.0518C5 16.8799 5.97656 15.8643 7.1875 15.8643C8.35938 15.8643 9.375 16.8799 9.375 18.0518C9.375 19.2627 8.35938 20.2393 7.1875 20.2393C5.97656 20.2393 5 19.2627 5 18.0518ZM7.1875 18.9893C7.69531 18.9893 8.125 18.5986 8.125 18.0518C8.125 17.5439 7.69531 17.1143 7.1875 17.1143C6.64062 17.1143 6.25 17.5439 6.25 18.0518C6.25 18.5986 6.64062 18.9893 7.1875 18.9893ZM20 18.0518C20 19.2627 18.9844 20.2393 17.8125 20.2393C16.6016 20.2393 15.625 19.2627 15.625 18.0518C15.625 16.8799 16.6016 15.8643 17.8125 15.8643C18.9844 15.8643 20 16.8799 20 18.0518ZM17.8125 17.1143C17.2656 17.1143 16.875 17.5439 16.875 18.0518C16.875 18.5986 17.2656 18.9893 17.8125 18.9893C18.3203 18.9893 18.75 18.5986 18.75 18.0518C18.75 17.5439 18.3203 17.1143 17.8125 17.1143Z"
                                    fill="white" />
                            </svg>
                        </i>
                        <p>Cart</p>
                    </div>
                </a>
        
            </a>
        </div>
        </div>`;
    }

    async afterRender(): Promise<void> {
        const searchInput = document.getElementById('search');
        searchInput?.addEventListener('input', ev => {
            ev.preventDefault();
            const inputValue = (ev.target as HTMLInputElement).value;
            console.log(inputValue);
            
            store.dispatch(getProducts({ searchTerm: inputValue }));
        })
    }
}

export default new Header();