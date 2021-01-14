using Microsoft.AspNetCore.Mvc;

namespace Control_Medico_NS.Controllers
{
    public class CtlEspecialidadController : Controller
    {
        public CtlEspecialidadController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}