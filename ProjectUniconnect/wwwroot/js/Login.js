// ===============================
// UniConnect - Login Form Handler
// Generic Binding for 3 Login Pages
// ===============================

/**
 * Binds login validation logic to a specific form.
 * @param {Object} config - Form configuration.
 * @param {string} config.formId - The form element ID.
 * @param {string} config.emailId - The email input ID.
 * @param {string} config.passId - The password input ID.
 * @param {string} config.msgId - The message label ID.
 */
function bindLoginForm({ formId, emailId, passId, msgId }) {
    const form = document.getElementById(formId);
    if (!form) return;

    const email = document.getElementById(emailId);
    const pass = document.getElementById(passId);
    const msg = document.getElementById(msgId);

    // ===== Toggle Password Visibility =====
    const toggleBtn = form.querySelector(".icon-btn");
    if (toggleBtn && pass) {
        toggleBtn.addEventListener("click", () => {
            const isHidden = pass.type === "password";
            pass.type = isHidden ? "text" : "password";

            toggleBtn.textContent = isHidden ? "Hide" : "Show";
            toggleBtn.setAttribute(
                "aria-label",
                isHidden ? "Hide password" : "Show password"
            );

            pass.focus();
        });
    }

    // ===== Handle Form Submit =====
    form.addEventListener("submit", (e) => {
        e.preventDefault();

        // reset message
        if (msg) {
            msg.style.color = "var(--err)";
            msg.textContent = "";
        }

        // Check HTML5 form validation
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }

        // Simulated success message (front-end only)
        if (msg) {
            msg.style.color = "var(--ok)";
            msg.textContent = "Login successful!";
        }

        // Reset form fields
        form.reset();
    });
}

// ===============================
// Initialize Login Forms
// ===============================

document.addEventListener("DOMContentLoaded", () => {
    bindLoginForm({
        formId: "gradForm",
        emailId: "gradEmail",
        passId: "gradPass",
        msgId: "gradMsg"
    });

    bindLoginForm({
        formId: "empForm",
        emailId: "empEmail",
        passId: "empPass",
        msgId: "empMsg"
    });

    bindLoginForm({
        formId: "uniForm",
        emailId: "uniEmail",
        passId: "uniPass",
        msgId: "uniMsg"
    });
});
