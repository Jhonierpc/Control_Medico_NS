using System.Linq;
using System.Threading.Tasks;
using Control_Medico_NS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Control_Medico_NS.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly ControlMedicoContext _context;
        public EspecialidadController(ControlMedicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost] //Metodo editar encargado del proceso POST al formulario BD
        public async Task<IActionResult> Edit (int id, [Bind("PubIntIdEspecialidad,PubStrDescripcion")] Especialidad especialidad)
        {
            if (id != especialidad.PubIntIdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(e => e.PubIntIdEspecialidad == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost] //Metodo Eliminar encargado del proceso POST al formulario BD
        public async Task<IActionResult> Delete (int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PubIntIdEspecialidad,PubStrDescripcion")] Especialidad especialidad)
        {
            if(ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
    }
}