const CARTAS_IGUALES = 2;
const SIMBOLOS = ["⚔", "⛵", "🕳", "🦜", "🕷"];
const SENIUELO = "☠";
const REVERSO = "reverso";
const ANVERSO = "anverso";
const memotest = document.getElementById("memotest");
var i = 0;
var longitudCartas = SIMBOLOS.length * CARTAS_IGUALES;
var gruposEncontrados = 0;
var cartas = new Array(longitudCartas);
var grupo = []; // 1 grupo = 1 par


function crearBotonesCarta(posCarta) {
    var botonCarta = document.createElement("button");
    botonCarta.innerText = SENIUELO;

    botonCarta.classList.add("carta");
    botonCarta.classList.add(REVERSO);

    botonCarta.addEventListener("click", clickBotonCarta => presionarBotonCarta(clickBotonCarta, posCarta));
    memotest.appendChild(botonCarta);
}
function crearCarta(posCarta) {
    var posSimbolo = posCarta;
    cartas[posCarta] = SIMBOLOS[i];
    if (posSimbolo % CARTAS_IGUALES != 0)
        i++;
}
function barajarVector(vector) {
    var iRandom;
    var longitud = vector.length;
    var nuevoVector = new Array(longitud);

    for (let i = 0; i < longitud; i++) {
        iRandom = Math.floor(Math.random() * longitud);
        while (typeof nuevoVector[iRandom] !== "undefined")
            iRandom = Math.floor(Math.random() * longitud);
        nuevoVector[iRandom] = vector[i];
    }

    return nuevoVector;
}

function mostrarContenidoCarta(botonCarta, posCarta) {
    botonCarta.classList.remove(REVERSO);
    botonCarta.classList.add(ANVERSO);

    botonCarta.innerText = cartas[posCarta];
}
function ocultarContenidoCarta(botonCarta, posCarta) {
    botonCarta.classList.remove(ANVERSO);
    botonCarta.classList.add(REVERSO);

    botonCarta.innerText = SENIUELO;
}
function activarSecuenciaVictoria() {
    const imagenLoro = document.getElementById("imagenLoroH3");
    const audioLoro = document.getElementById("audioLoro");
    const fuenteAudioLoro = audioLoro.getElementsByTagName("source")[0];
    const inputs = document.getElementsByTagName("input");

    imagenLoro.src = "/img/h3-loro_derrotado.jpg";
    fuenteAudioLoro.src = "/audio/h3-loro_llorando_real.mp3";
    inputs[1].value = window.atob("Y29mcmU=" );

    audioLoro.load();
    audioLoro.play();
}
function presionarBotonCarta(clickBotonCarta, posCarta) {
    const botonCarta = clickBotonCarta.target;
    const botonesCartas = document.getElementsByClassName("carta");

    if (botonCarta.classList.contains(REVERSO) && grupo.length < CARTAS_IGUALES && !grupo.includes(posCarta)) {
        grupo.push(posCarta);
        mostrarContenidoCarta(botonCarta, posCarta);
        setTimeout(() => {
            if (grupo.length == CARTAS_IGUALES && cartas[grupo[0]] == cartas[grupo[1]]) {
                botonesCartas[grupo[0]].setAttribute("disabled", true);
                botonesCartas[grupo[1]].setAttribute("disabled", true);
                gruposEncontrados++;
                grupo = [];
            } else if (grupo.length == CARTAS_IGUALES) {
                ocultarContenidoCarta(botonesCartas[grupo[0]], grupo[0]);
                ocultarContenidoCarta(botonesCartas[grupo[1]], grupo[1]);
                grupo = [];
            }

            if (gruposEncontrados == SIMBOLOS.length) {
                activarSecuenciaVictoria();
            }
        }, 1000);
    }
}


for (let posCarta = 0; posCarta < longitudCartas; posCarta++) {
    crearCarta(posCarta);
}
cartas = barajarVector(cartas);
for (let posCarta = 0; posCarta < longitudCartas; posCarta++) {
    crearBotonesCarta(posCarta);
}