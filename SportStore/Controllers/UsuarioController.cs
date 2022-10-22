using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpPost]
        public IActionResult Registro()
        {
            return View("Registro");
        }

        [HttpGet]
        public async Task<IActionResult> Registro(RegistroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Registro");
        }


    }
}
