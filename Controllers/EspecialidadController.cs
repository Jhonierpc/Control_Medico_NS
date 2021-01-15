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

        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = _context.Especialidad.Find(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost] //Metodo editar encargado del proceso POST al formulario BD
        public IActionResult Edit (int id, [Bind("PubIntIdEspecialidad,PubStrDescripcion")] Especialidad especialidad)
        {
            if (id != especialidad.PubIntIdEspecialidad)
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