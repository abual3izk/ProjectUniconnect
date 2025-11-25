class UCHeader extends HTMLElement {
    constructor() {
        super();
        const shadow = this.attachShadow({ mode: "open" });

        // Detect current folder
        const path = location.pathname.toLowerCase();
        const inLogin = path.includes("/loginuniconnect/");
        const inAbout = path.includes("/aboutuniconnect/");
        const inHome = path.includes("/homeuniconnect/");

        // Set correct links based on location
        let HOME_HREF;
        let ABOUT_HREF;

        if (inLogin) {
            HOME_HREF = "../HomeUniconnect/index.html";
            ABOUT_HREF = "../AboutUniconnect/about.html";
        } else if (inAbout) {
            HOME_HREF = "../HomeUniconnect/index.html";
            ABOUT_HREF = "about.html";
        } else if (inHome) {
            HOME_HREF = "index.html";
            ABOUT_HREF = "../AboutUniconnect/about.html";
        } else {
            HOME_HREF = "index.html";
            ABOUT_HREF = "../AboutUniconnect/about.html";
        }
   

        // Header styles
        const style = document.createElement("style");
        style.textContent = `
      :host { all: initial; }
      .uc-header { 
        width:100%; position:fixed; top:0; left:0;
        background:#eef2ff; padding:14px 0;
        display:flex; justify-content:space-between; 
        align-items:center; box-shadow:0 2px 8px rgba(0,0,0,0.08);
        z-index:1000; font-family:system-ui, Arial;
      }
      .uc-logo { font-size:26px; font-weight:700; margin-left:32px; }
      .uc-nav { display:flex; gap:25px; margin-right:32px; }
      .uc-link { font-size:26px; font-weight:700; text-decoration:none; color:#0f172a; }
      .uc-link:hover { color:#4f46e5; }
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
