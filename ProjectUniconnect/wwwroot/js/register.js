document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('registerForm');
    if (!form) return;

    const fullName = document.getElementById('fullName');
    const email = document.getElementById('regEmail');
    const pass = document.getElementById('regPass');
    const confirmPass = document.getElementById('confirmPass');
    const acceptTerms = document.getElementById('acceptTerms');
    const msg = document.getElementById('registerMsg');

    const ruleLength = document.getElementById('rule-length');
    const ruleNumber = document.getElementById('rule-number');
    const ruleUpper = document.getElementById('rule-upper');

    function updateRules(p) {
        // طول
        if (p.length >= 8) {
            ruleLength.classList.remove('bad');
            ruleLength.classList.add('ok');
        } else {
            ruleLength.classList.remove('ok');
            ruleLength.classList.add('bad');
        }

        // رقم
        if (/\d/.test(p)) {
            ruleNumber.classList.remove('bad');
            ruleNumber.classList.add('ok');
        } else {
            ruleNumber.classList.remove('ok');
            ruleNumber.classList.add('bad');
        }

        // حرف كبير
        if (/[A-Z]/.test(p)) {
            ruleUpper.classList.remove('bad');
            ruleUpper.classList.add('ok');
        } else {
            ruleUpper.classList.remove('ok');
            ruleUpper.classList.add('bad');
        }
    }

    pass.addEventListener('input', () => {
        updateRules(pass.value);
    });

    form.addEventListener('submit', (e) => {
        e.preventDefault(); // حالياً فرونت اند فقط

        msg.textContent = '';
        msg.style.color = '#dc2626';

        if (!fullName.value.trim()) {
            msg.textContent = 'Please enter your full name.';
            fullName.focus();
            return;
        }

        if (!email.value.trim()) {
            msg.textContent = 'Please enter your email.';
            email.focus();
            return;
        }

        const p = pass.value;
        const c = confirmPass.value;

        if (p.length < 8 || !/\d/.test(p) || !/[A-Z]/.test(p)) {
            msg.textContent = 'Password does not meet the requirements.';
            pass.focus();
            return;
        }

        if (p !== c) {
            msg.textContent = 'Passwords do not match.';
            confirmPass.focus();
            return;
        }

        if (!acceptTerms.checked) {
            msg.textContent = 'You must agree to the terms.';
            acceptTerms.focus();
            return;
        }

        msg.style.color = '#16a34a';
        msg.textContent = 'Account created successfully (front-end only).';

        // ممكن نفضّي الحقول لو حبيتي:
        // form.reset();
        // updateRules('');
    });
});
