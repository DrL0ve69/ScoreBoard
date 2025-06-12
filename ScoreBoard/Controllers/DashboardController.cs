using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

namespace ScoreBoard.Controllers
{
    public class DashboardController : Controller
    {
        private IJoueurRepository _joueurRepository;
        public DashboardController(IJoueurRepository joueurRepository)
        {
            _joueurRepository = joueurRepository;
        }
        public IActionResult Index()
        {
            return View(_joueurRepository.ListeJoueurs);
        }
        public IActionResult Details(int id) 
        {
            return View(_joueurRepository.GetJoueur(id));
        }
    }
}
