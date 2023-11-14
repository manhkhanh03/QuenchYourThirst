function handleImport(options) {
    const formElement = document.querySelector(options.form);
    let selectorRules = {};

    function validate(rule, ruleElement) {
        const formMessage = ruleElement.parentElement.querySelector(options.formMessage);
        let errorMessage;

        let rules = selectorRules[rule.selector];
        for (let i in rules) {
            errorMessage = rules[i](ruleElement.value);
            if (errorMessage) break;
        }

        if (errorMessage) {
            formMessage.innerText = errorMessage;
        } else formMessage.innerText = '';
        return !errorMessage;
    }

    function handle(e, options) {
        // e.preventDefault();

        let isCheckInput = true;

        const inputElement = formElement.querySelectorAll('input:not([disabled])' + options.formInput);
        options.rules.forEach((rule, index) => {
            const ruleElement = formElement.querySelectorAll(rule.selector);
            ruleElement.forEach(function (value) {
                let isValidate = validate(rule, value);
                if (!isValidate) {
                    isCheckInput = false;
                }
            });
        });

        if (isCheckInput) {
            const data = {};
            Array.from(inputElement).forEach((ele) => {
                data[ele.getAttribute('id')] = ele.value;
            });

            options.isSuccess(data, e);
        }
    }

    // btn mặc định của form
    formElement.onsubmit = function (e) {
        e.preventDefault();
        options.rules.forEach((rule, index) => {
            const ruleElement = formElement.querySelectorAll(rule.selector);

            if (Array.isArray(selectorRules[rule.selector])) {
                selectorRules[rule.selector].push(rule.test);
            } else selectorRules[rule.selector] = [rule.test];
            ruleElement.forEach(function (ruleE) {
                ruleE.addEventListener('input', () => {
                    validate(rule, ruleE);
                });

                ruleE.addEventListener('blur', () => {
                    validate(rule, ruleE);
                });
            });
        });
        handle(this, options);
    };
}

handleImport.isFocus = function (selector, message, other) {
    return {
        selector: selector,
        test: function (value) {
            return value.trim() ? undefined : message;
        },
    };
};

handleImport.isPassword = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            return value.length >= 8 ? undefined : message;
        },
    };
};

handleImport.isEmail = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(value) ? undefined : message;
        },
    };
};

handleImport.isConfirmPassword = function (selector, message, password) {
    return {
        selector: selector,
        test: function (value) {
            const valuePassword = document.querySelector(password).value;
            return valuePassword === value ? undefined : message;
        },
    };
};

handleImport.isChange = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            return value == 0 ? message : undefined;
        },
    };
};
