
const wrapperMenu = document.getElementById("wrapper-menu");
const maskMenu = document.getElementById("mask_menu");
const closeMenu = document.querySelector(".close-menu");
const menuBar = document.getElementById("menu-bar");
menuBar.addEventListener('click', (e) => {
    wrapperMenu.style.animationPlayState = 'running';
    wrapperMenu.style.left = 0;
    closeMenu.style.left = '300px';
    wrapperMenu.style.left = 0;
    maskMenu.style.display = 'block';
})
function closeMenuBar() {
    wrapperMenu.style.left = '-300px';
    closeMenu.style.left = '-22%';
    maskMenu.style.display = 'none';
}