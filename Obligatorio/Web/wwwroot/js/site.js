// Comportamiento visual del sitio (no modifica la lógica de la aplicación).

// Mostrar / ocultar contraseña en los formularios de acceso.
document.addEventListener("click", function (evento) {
    const boton = evento.target.closest("[data-fx-toggle-password]");
    if (!boton) return;

    const campo = document.getElementById(boton.getAttribute("data-fx-toggle-password"));
    if (!campo) return;

    const visible = campo.type === "text";
    campo.type = visible ? "password" : "text";

    const icono = boton.querySelector("i");
    if (icono) icono.className = visible ? "bi bi-eye" : "bi bi-eye-slash";
    boton.setAttribute("aria-label", visible ? "Mostrar contraseña" : "Ocultar contraseña");
});
