using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers;

public class JoueurController : Controller
{
    private IJoueurRepository _joueurRepository;
    public JoueurController(IJoueurRepository joueurRepository)
    {
        _joueurRepository = joueurRepository;
    }
    public IActionResult Index()
    {
        return View(_joueurRepository.ListeJoueurs);
    }
}
