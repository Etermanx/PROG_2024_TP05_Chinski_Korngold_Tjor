using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROG_2024_TP05_Tjor.Models;

namespace PROG_2024_TP05_Tjor.Controllers;

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

    public IActionResult Comenzar()
    {
        return View("Habitacion" + (Escape.GetEstadoJuego() + 1));
    }
}
