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
        bool noDerrotado = Escape.GetNoDerrota();
        bool salaResuelta = false;
        int? estadoJuego = Escape.GetEstadoJuego();
        int cantidadSalas = Escape.GetCantidadSalas();

        if (noDerrotado && sala == estadoJuego && Escape.ResolverSala(sala, clave))
        {
            estadoJuego++;
            salaResuelta = true;
        }
        
        if (noDerrotado && estadoJuego <= cantidadSalas)
        {
            if (!salaResuelta)
                ViewBag.Error = "Respuesta incorrecta";
            return View("Habitacion" + estadoJuego);
        }
        else if (noDerrotado)
        {
            ViewBag.IntentosFallidos = Escape.GetIntentosFallidos();
            return View("Victoria");
        }
        else if (estadoJuego != null)
            return View("Derrota");
        else
            return RedirectToAction("Comenzar");
    }

    public IActionResult SegundosFaltantes()
    {
        return Content(Escape.GetSegundosFaltantes().ToString(), "text/plain");
    }
}