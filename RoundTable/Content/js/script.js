const menu = document.querySelector('#menu-btn')
const navbar = document.querySelector('#navbar')
const logo = document.querySelector('#logo')
const navbarItem = document.querySelector('#navbarItem')
const notification = document.querySelector('#notification')
const profile = document.querySelector('#profile')
const blackBar = document.querySelector('#blackBar')

menu.addEventListener('click', showNav);
blackBar.addEventListener('click', hideNav);
window.addEventListener('resize', hideNav);

function showNav() {
    if (navbar.classList.contains('hidden')) {
        navbar.classList.remove('hidden', 'relative');
        navbar.classList.add('pt-32', 'absolute', 'w-2/5', 'sm:w-2/5', 'h-screen', 'z-40', 'shadow-lg');
        logo.classList.add('hidden');
        darkMode.classList.add('hidden');
        notification.classList.add('hidden');
        profile.classList.add('hidden');
        blackBar.classList.remove('hidden');
    }
}

function hideNav() {
    navbar.classList.add('hidden', 'relative');
    navbar.classList.remove('pt-32', 'absolute', 'w-2/5', 'sm:w-2/5', 'h-screen', 'z-40', 'shadow-lg');
    logo.classList.remove('hidden');
    darkMode.classList.remove('hidden');
    notification.classList.remove('hidden');
    profile.classList.remove('hidden');
    blackBar.classList.add('hidden');
}

//ScrollSpy
window.addEventListener('DOMContentLoaded', () => {

    const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            const id = entry.target.getAttribute('id');
            if (entry.intersectionRatio > 0) {
                document.querySelector(`.support-section-nav li a[href="#${id}"]`).parentElement.classList.add('active');
            } else {
                document.querySelector(`.support-section-nav li a[href="#${id}"]`).parentElement.classList.remove('active');
            }
        });
    });

    document.querySelectorAll('section[id]').forEach((section) => {
        observer.observe(section);
    });

});

//Smooth Scrolling
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});

//Shortcut Key (Ctrl+\)
document.addEventListener('keydown', function (e) {

    if ((e.keyCode || e.which) == 220 && e.ctrlKey) {
        document.getElementById("bot-launch-button").click();
    }

});

//Dropdown content
function postDropdown() {
    document.getElementById("threedot_dropdown").classList.toggle('hidden');
    document.getElementById("threedot_btn").classList.toggle('text-indigo-600');
}

//Copy URL to clipboard
function copyURL() {
    var copyText = document.getElementById("ContentPlaceHolder1_post_url_txt");
    copyText.select();
    copyText.setSelectionRange(0, 99999);
    document.execCommand("copy");
}