static class Escape {
    private static string[] incognitasSalas = new string[5];
    private static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas[0] = "brujula";
        incognitasSalas[1] = "misterio";
        incognitasSalas[2] = "cofre";
    }
    public static int GetEstadoJuego(){
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita){
        
        InicializarJuego();
        bool resuelto = incognitasSalas[Sala-1] == Incognita.ToLower();
        if (resuelto)
            estadoJuego++;
        return resuelto;
    }
}