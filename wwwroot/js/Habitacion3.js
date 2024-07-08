const SIMBOLOS = ["⚔", "⛵", "🕳", "🦜", "🕷"];
const SENIUELO = "☠";
const memotest = document.getElementById("memotest");
var cartas = [];

for (let posCarta = 0; posCarta < SIMBOLOS.length * 2; posCarta++) {
    crearBotonesCarta(posCarta);
    crearCarta(posCarta);
}

//mostrarContenidoCarta();
//ocultarContenidoCarta();
//mostrarContenidoCartas();
//ocultarContenidoCartas();


function crearBotonesCarta(posCarta) {
    var botonCarta = document.createElement("button");
    botonCarta.innerText = SENIUELO;

    botonCarta.classList.add("carta");
    botonCarta.classList.add("reverso");
    botonCarta.setAttribute("disabled", true);

    botonCarta.addEventListener("click", (clickBotonCarta) => darVuelta(clickBotonCarta, posCarta));
    memotest.appendChild(botonCarta);
}
function crearCarta(posCarta) {
    var posSimbolo = posCarta;
        if (posCarta % 2 != 0)
            posSimbolo = posCarta - 1;

        cartas.push(SIMBOLOS[posSimbolo]);
}
function barajarLista(lista) {
    //lista.sort(() => Math.floor(Math.random() * lista.length);
}

function mostrarContenidoCarta(botonCarta, posCarta) {
    botonCarta.classList.remove("reverso");
    botonCarta.classList.add("anverso");


}
function ocultarContenidoCarta(botonCarta, posCarta) {
    botonCarta.classList.remove("anverso");
    botonCarta.classList.add("reverso");
}
function darVuelta(clickBotonCarta, posCarta) {
    //const botonCarta = clickBotonCarta.target;
    //if (botonCarta.)
    //(botonCarta, posCarta);
}