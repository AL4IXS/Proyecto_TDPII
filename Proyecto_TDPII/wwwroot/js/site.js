// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const btnAbrirModal =
    document.querySelector("#btn-abrir-modal");
const btnCerrarModal =
    document.querySelector("#btn-cerrar-modal");
const modal =
    document.querySelector("#modal");

btnAbrirModal.addEventListener("click", () => {
    modal.showModal();

})
