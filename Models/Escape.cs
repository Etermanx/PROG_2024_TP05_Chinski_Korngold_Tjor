static class Escape {
    private static string[] incognitasSalas = {
        "brújula",
        "misterio"

    };
    private static int estadoJuego = 1;

    private static void InicializarJuego(){}
    public static int GetEstadoJuego(){
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        bool resuelto = incognitasSalas[Sala-1] == Incognita;
        if (resuelto)
            estadoJuego++;
        return resuelto;
    }
}