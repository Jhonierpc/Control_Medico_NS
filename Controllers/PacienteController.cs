using System.Linq;
using System.Threading.Tasks;
using Control_Medico_NS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Control_Medico_NS.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ControlMedicoContext _context;

        public PacienteController(ControlMedicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.PubIntIdPaciente == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevenimos cambios externos
        public async Task<IActionResult> Create([Bind("PubIntIdPaciente,PubStrNombre,PubStrSeguro,PubStrCodigoPostal,PubStrTelefono,PubStrDireccion,PubStrEmail")] Paciente paciente)
        {
            if(ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost] //Metodo editar encargado del proceso POST al formulario BD
        [ValidateAntiForgeryToken] //Prevenimos cambios externos
        public async Task<IActionResult> Edit (int id, [Bind("PubIntIdPaciente,PubStrNombre,PubStrSeguro,PubStrCodigoPostal,PubStrTelefono,PubStrDireccion,PubStrEmail")] Paciente paciente)
        {
            if (id != paciente.PubIntIdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.PubIntIdPaciente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(e => e.PubIntIdPaciente == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost] //Metodo Eliminar encargado del proceso POST al formulario BD
        [ValidateAntiForgeryToken] //Prevenimos cambios externos
        public async Task<IActionResult> Delete (int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.PubIntIdPaciente == id);
        }
    }
}