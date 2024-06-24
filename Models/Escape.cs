static class Escape {
    private static string[] incognitasSalas = new string[5];
    private static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas[0] = "brújula";
        incognitasSalas[1] = "misterio";
    }
    public static int GetEstadoJuego(){
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        InicializarJuego();
        bool resuelto = incognitasSalas[Sala-1] == Incognita;
        if (resuelto)
            estadoJuego++;
        return resuelto;
    }
}