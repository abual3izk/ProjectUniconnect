// ==========================
// UniConnect Header Component
// ASP.NET Core MVC Version
// (Design taken from original static version)
// ==========================

class UCHeader extends HTMLElement {
  constructor() {
    super();
    const shadow = this.attachShadow({ mode: "open" });

    // MVC routes
    const HOME_HREF  = "/";
      const ABOUT_HREF = "/Home/About";

    // Header structure
    const wrapper = document.createElement("header");
    wrapper.className = "uc-header";
    wrapper.innerHTML = `
      <h1 class="uc-logo">UniConnect</h1>
      <nav class="uc-nav">
        <a class="uc-link" href="${HOME_HREF}">Home</a>
        <a class="uc-link" href="${ABOUT_HREF}">About Us</a>
        <a class="uc-link" href="/Account/Index">User Account</a>

      </nav>
    `;

    // Header styles (same sizes as original design)
    const style = document.createElement("style");
    style.textContent = `
      :host { 
        all: initial; 
        font-family: system-ui, Arial, sans-serif;
      }

      .uc-header { 
        width: 100%;
        position: fixed;
        top: 0; 
        left: 0;
        background: #eef2ff;
        padding: 14px 0;
        display: flex;
        justify-content: space-between; 
        align-items: center;
        box-shadow: 0 2px 8px rgba(0,0,0,0.08);
        z-index: 1000;
      }

      .uc-logo { 
        font-size: 26px; 
        font-weight: 700; 
        margin-left: 32px; 
      }

      .uc-nav { 
        display: flex; 
        gap: 25px; 
        margin-right: 32px; 
      }

      .uc-link { 
        font-size: 26px; 
        font-weight: 700; 
        text-decoration: none; 
        color: #0f172a; 
      }

      .uc-link:hover { 
        color: #4f46e5; 
      }
    `;

    shadow.append(style, wrapper);
  }
}

// Register component
customElements.define("uc-header", UCHeader);

// Add header and apply body padding
document.addEventListener("DOMContentLoaded", () => {
  const PAD = 82;
  document.documentElement.style.setProperty("--uc-header-pad", PAD + "px");
  document.body.style.paddingTop = "var(--uc-header-pad)";
  document.body.insertAdjacentHTML("afterbegin", "<uc-header></uc-header>");
});
