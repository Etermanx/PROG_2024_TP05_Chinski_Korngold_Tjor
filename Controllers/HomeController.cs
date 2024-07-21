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
        Escape.IniciarJuego();
        return View("Habitacion1");
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        bool derrotado = Escape.GetDerrota();
        int estadoJuego = Escape.GetEstadoJuego();
        
        if (!derrotado && sala == estadoJuego && Escape.ResolverSala(sala, clave))
        {
            estadoJuego++;
            if (estadoJuego > Escape.GetCantidadSalas())
                return View("Victoria");
            else
                return View("Habitacion" + estadoJuego);
        }
        else if (!derrotado)
        {
            ViewBag.Error = "Respuesta incorrecta";
            return View("Habitacion" + estadoJuego);
        }
        else
            return View("Derrota");
    }

    public IActionResult SegundosFaltantes()
    {
        return Content(Escape.GetSegundosFaltantes().ToString(), "text/plain");
    }
}
