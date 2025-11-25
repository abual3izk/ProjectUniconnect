function bindLoginForm({ formId, emailId, passId, msgId }) {
    const form = document.getElementById(formId);
    if (!form) return;

    const email = document.getElementById(emailId);
    const pass = document.getElementById(passId);
    const msg = document.getElementById(msgId);

    // Toggle password visibility 
    const toggleBtn = form.querySelector('.icon-btn');
    if (toggleBtn && pass) {
        toggleBtn.addEventListener('click', () => {
            pass.type = pass.type === 'password' ? 'text' : 'password';
            toggleBtn.textContent = pass.type === 'password' ? 'Show' : 'Hide';
            toggleBtn.setAttribute('aria-label', pass.type === 'password' ? 'Show password' : 'Hide password');
            pass.focus();
        });
    }

    // submit handler
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        if (msg) { msg.style.color = 'var(--err)'; msg.textContent = ''; }

        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }

        if (msg) {
            msg.style.color = 'var(--ok)';
            msg.textContent = 'Login successful (front-end only).';
        }

        form.reset();
    });
}

// Initialize bindings for the three forms 
document.addEventListener('DOMContentLoaded', () => {
    bindLoginForm({ formId: 'gradForm', emailId: 'gradEmail', passId: 'gradPass', msgId: 'gradMsg' });
    bindLoginForm({ formId: 'empForm', emailId: 'empEmail', passId: 'empPass', msgId: 'empMsg' });
    bindLoginForm({ formId: 'uniForm', emailId: 'uniEmail', passId: 'uniPass', msgId: 'uniMsg' });
});