const menu = document.querySelector('#menu-btn')
const navbar = document.querySelector('#navbar')
const logo = document.querySelector('#logo')
const navbarItem = document.querySelector('#navbarItem')
const darkMode = document.querySelector('#darkMode')
const notification = document.querySelector('#notification')
const profile = document.querySelector('#profile')
const blackBar = document.querySelector('#blackBar')
const moonIcon = document.querySelector('#moonIcon')
const sunIcon = document.querySelector('#sunIcon')
const moonIconMobile = document.querySelector('#moonIconMobile')
const sunIconMobile = document.querySelector('#sunIconMobile')

menu.addEventListener('click', showNav);

blackBar.addEventListener('click', hideNav);

window.addEventListener('resize', hideNav);

function showNav() {
    if (navbar.classList.contains('hidden')) {
        navbar.classList.remove('hidden', 'relative');
        navbar.classList.add('pt-32', 'absolute', 'w-1/3', 'sm:w-1/3', 'h-screen', 'z-40', 'shadow-lg');
        logo.classList.add('hidden');
        darkMode.classList.add('hidden');
        notification.classList.add('hidden');
        profile.classList.add('hidden');
        blackBar.classList.remove('hidden');
    }
}

function hideNav() {
    navbar.classList.add('hidden', 'relative');
    navbar.classList.remove('pt-32', 'absolute', 'w-1/3', 'sm:w-1/3', 'h-screen', 'z-40', 'shadow-lg');
    logo.classList.remove('hidden');
    darkMode.classList.remove('hidden');
    notification.classList.remove('hidden');
    profile.classList.remove('hidden');
    blackBar.classList.add('hidden');
}

document.getElementById('switchTheme').addEventListener('click', function () {
    let htmlClasses = document.querySelector('html').classList;
    if (localStorage.theme == 'dark') {
        htmlClasses.remove('dark');
        document.documentElement.classList.toggle('dark');
        localStorage.removeItem('theme');
        moonIcon.classList.remove('hidden');
        sunIcon.classList.add('hidden');
    } else {
        htmlClasses.add('dark');
        document.documentElement.classList.toggle('dark');
        localStorage.theme = 'dark';
        moonIcon.classList.add('hidden');
        sunIcon.classList.remove('hidden');
    }
});

document.getElementById('switchThemeMobile').addEventListener('click', function () {
    let htmlClasses = document.querySelector('html').classList;
    if (localStorage.theme == 'dark') {
        htmlClasses.remove('dark');
        localStorage.removeItem('theme');
        moonIconMobile.classList.remove('hidden');
        sunIconMobile.classList.add('hidden');
    } else {
        htmlClasses.add('dark');
        localStorage.theme = 'dark';
        moonIconMobile.classList.add('hidden');
        sunIconMobile.classList.remove('hidden');
    }
});

if (localStorage.theme === 'dark' || (!'theme' in localStorage && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
    document.querySelector('html').classList.add('dark')
} else if (localStorage.theme === 'dark') {
    document.querySelector('html').classList.add('dark')
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