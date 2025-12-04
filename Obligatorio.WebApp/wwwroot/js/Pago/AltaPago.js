document.querySelector("#Dto_TipoPago").addEventListener('change', MostrarOpcionesSegunTipo);
document.querySelector("#formAlta").addEventListener('submit', validarDatos);


MostrarOpcionesSegunTipo();

function MostrarOpcionesSegunTipo() {
    let op = document.querySelector("#Dto_TipoPago").value;

    if (op == "Recurrente") {
        document.querySelector("#opcionesRecurrente").style.display = "block";
    } else {
        document.querySelector("#opcionesRecurrente").style.display = "none";
    }

}

function validarDatos(evt) {

    evt.preventDefault();
    let fechaFin = document.querySelector("#Dto_FechaFin").value;
    let op = document.querySelector("#Dto_TipoPago").value;
    if (op == "Recurrente") {
        if (fechaFin != "") {
            this.submit();
        } else {
            alert("Verificar fecha de fin");
        }
    } else {
        this.submit();
    }
}