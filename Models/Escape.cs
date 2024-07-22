using System.Timers;

static class Escape {
    const int SALAS = 5;
    const int SEGUNDOS_MAX = 5400; // 1:30h
    private static string[] incognitasSalas = new string[SALAS];
    private static int estadoJuego;
    private static System.Timers.Timer reloj;
    private static int segundosFaltantes = 0;

    private static void InicializarJuego()
    {
        incognitasSalas[0] = "brujula";
        incognitasSalas[1] = "misterio";
        incognitasSalas[2] = "cofre";
        incognitasSalas[3] = "capitan";
        incognitasSalas[4] = "felicidades";
    }
    public static void IniciarJuego()
    {
        InicializarJuego();
        estadoJuego = 1;
        ComenzarContador(out reloj, SEGUNDOS_MAX);
    }
    public static int GetCantidadSalas()
    {
        return SALAS;
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool GetDerrota()
    {
        return estadoJuego <= SALAS && segundosFaltantes <= 0;
    }
    public static int GetSegundosFaltantes()
    {
        return segundosFaltantes;
    }
    public static bool ResolverSala(int Sala, string Incognita)
    {
        bool resuelto;
        resuelto = incognitasSalas[Sala-1] == Incognita.ToLower();
        if (resuelto)
            estadoJuego++;
        return resuelto;
    }

    private static void ComenzarContador(out System.Timers.Timer reloj, int segundosMax)
    {
        reloj = new System.Timers.Timer(1000); // 1 segundo
        segundosFaltantes = segundosMax;

        reloj.Elapsed += Tick;
        reloj.AutoReset = true;
        reloj.Enabled = true;
    }
    private static void FinalizarContador(System.Timers.Timer reloj)
    {
        reloj.Stop();
        reloj.Dispose();
    }
    private static void Tick(Object source, ElapsedEventArgs e)
    {
        segundosFaltantes--;
        if (segundosFaltantes < 0)
            FinalizarContador(reloj);
    }
}