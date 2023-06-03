import Home from "./views/pages/Home.js";
import About from "./views/pages/About.js";
import { parseRequestURL } from "./utils.js";

const routes = {
  "/": Home,
  "/about": About,
};

// The router code. Takes a URL, checks against the list of supported routes and then renders the corresponding content page.
const router = async () => {
  // Lazy load view element:
  const header = null || document.getElementById("header_container");
  const content = null || document.getElementById("page_container");
  const footer = null || document.getElementById("footer_container");

  // Get the parsed URl from the addressbar
  let request = parseRequestURL();

  // Parse the URL and if it has an id part, change it with the string ":id"
  let parsedURL =
    (request.resource ? "/" + request.resource : "/") +
    (request.id ? "/:id" : "") +
    (request.verb ? "/" + request.verb : "");

  let page = routes[parsedURL] ? routes[parsedURL] : "NotFound";
  content.innerHTML = await page.render();
  await page.after_render();
};

// Listen on page load:
window.addEventListener("load", router);

window.addEventListener("hashchange", () => {
  console.log(location.hash);
});
