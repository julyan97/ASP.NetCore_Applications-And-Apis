// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var formDropDownMenu = document.getElementById('formDropDownMenu');
var form = document.getElementById('form');

function toggleDropDownMenu(event) {
    if(event.target !== form && event.target !== form.parentNode) {
        formDropDownMenu.classList.remove('form-dropdown');
        formDropDownMenu.style.visibility = 'hidden';
    } else {
        formDropDownMenu.classList.add('form-dropdown');
        formDropDownMenu.style.visibility = 'initial';
        formDropDownMenu.style.maxHeight = '300px';
    }
}

window.addEventListener('click', toggleDropDownMenu);







