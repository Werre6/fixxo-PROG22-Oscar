const toggleBtn = document.querySelector('[data-option="toggle"]')
toggleBtn.addEventListener('click', function () {
    const element = document.querySelector(toggleBtn.getAttribute('data-target'))

    if (!element.classList.contains('hide')) {
        element.classList.add('hide')
    }

    else {
        element.classList.remove('hide')
    }
})


const textValidation = (target, minLength) => {
    if (target.value.length >= minLength) {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = `Must contain more than ${minLength} characters`
    }
}

const emailValidation = (target) => {
    const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (!regEx.test(target.value))
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = "Not a valid email"
    else
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""
}

//const passwordValidation = (target) => {
//    const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/;

//    if (!regEx.test(target.value))
//        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = "Not a valid password"
//    else
//        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""
//}

const requiredInputs = document.querySelectorAll('[data-val-required]')
for (let input of requiredInputs) {
    input.addEventListener('keyup', (e) => {
        switch (e.target.type) {
            case 'text':
                textValidation(e.target, 2)
                break
            case 'email':
                emailValidation(e.target)
                break
            case 'password':
                passwordValidation(e.target)
                break
        }
    })
}