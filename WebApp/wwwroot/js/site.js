function valideForm() {

    document.getElementById("myForm").onsubmit = function () {
        var name = document.getElementById("Name").value;
        var email = document.getElementById("Email").value;

        var isValid = true;

        // Perform your validation logic here
        if (name.trim() === "") {
            document.getElementById("Name-error").innerHTML = "Name is required.";
            isValid = false;
        } else {
            document.getElementById("Name-error").innerHTML = "";
        }

        if (email.trim() === "") {
            document.getElementById("Email-error").innerHTML = "Email is required.";
            isValid = false;
        } else {
            document.getElementById("Email-error").innerHTML = "";
        }

        return isValid;
    };
}




function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)


function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]')



















//try {
//    const footer = document.querySelector('footer')

//    if (document.body.scrollHeight >= window.innerHeight) {
//        footer.classList.remove('position-fixed-bottom')
//        footer.classList.add('position-static')
//    } else {
//        footer.classList.remove('position-static')
//        footer.classList.add('position-fixed-bottom')
//    }
//}
//catch { }
