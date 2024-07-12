static class Escape {
    private static string[] incognitasSalas = new string[5];
    private static int estadoJuego = 1;
    private static bool juegoInicializado = false;

    private static void InicializarJuego()
    {
        incognitasSalas[0] = "brujula";
        incognitasSalas[1] = "misterio";
        incognitasSalas[2] = "cofre";
        incognitasSalas[3] = "capitan";
        incognitasSalas[4] = "felicidades";
        juegoInicializado = true;
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static void ReiniciarJuego()
    {
        estadoJuego = 1;
        juegoInicializado = false;
    }
    public static bool ResolverSala(int Sala, string Incognita)
    {
        bool resuelto;
        InicializarJuego();
        resuelto = incognitasSalas[Sala-1] == Incognita.ToLower();
        if (resuelto)
            estadoJuego++;
        return resuelto;
    }
}