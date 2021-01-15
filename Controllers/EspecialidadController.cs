using System.Linq;
using Control_Medico_NS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Control_Medico_NS.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly ControlMedicoContext _context;
        public EspecialidadController(ControlMedicoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Especialidad.ToList());
        }

        public IActionResult Edit (int? vIntId)
        {
            if (vIntId == null)
            {
                return NotFound();
            }

            var especialidad = _context.Especialidad.Find(vIntId);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        //Metodo editar encargado del proceso POST al formulario BD
        [HttpPost]
        public IActionResult Edit (int vIntId, [Bind("PubIntIdEspecialidad,PubStrDescripcion")] Especialidad especialidad)
        {
            if (vIntId != especialidad.PubIntIdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }
    }
}