using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROG_2024_TP05_Chinski_Korngold_Tjor.Models;

namespace PROG_2024_TP05_Chinski_Korngold_Tjor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Escape.ReiniciarJuego();
        return View();
    }
    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult Comenzar()
    {
        Escape.ReiniciarJuego();
        return View("Habitacion1");
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        int estadoJuego = Escape.GetEstadoJuego();

        if (sala == estadoJuego && Escape.ResolverSala(sala, clave))
        {
            if (estadoJuego == 5)
                return View("Victoria");
            else
            {
                estadoJuego++;
                return View("Habitacion" + estadoJuego);
            }
        }
        else
        {
            ViewBag.Error = "Respuesta incorrecta";
            return View("Habitacion" + estadoJuego);
        }
    }


    /*static void comenzarTimer(out Timer reloj, int segundos)
    {
        reloj = new Timer(segundos * 1000);

        reloj.Elapsed += tick;
        reloj.AutoReset = true;
        reloj.Enabled = true;
    }
    static void finalizarTimer(Timer reloj)
    {
        reloj.Stop();
        reloj.Dispose();
    }
    static void tick(Object source, ElapsedEventArgs e)
    {
            segundos++;

        if (segundos == SEGUNDOS_MAX)
            Console.WriteLine($"¡Ring! Ya pasaron {SEGUNDOS_MAX / 60} mins. Apretá enter para saltar al final.");
    }*/
}
