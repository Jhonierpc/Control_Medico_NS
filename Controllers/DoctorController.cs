using Control_Medico_NS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Medico_NS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ControlMedicoContext _context;

         public DoctorController(ControlMedicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctor.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.Where(p => p.PubIntIdDoctor == id).Include(de => de.DoctorEspecialidad)
                .ThenInclude(e => e.Especialidad).FirstOrDefaultAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad,"PubIntIdEspecialidad", "PubStrDescripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevenimos cambios externos
        public async Task<IActionResult> Create([Bind("PubIntIdDoctor,PubStrNombre,PubStrCredencial,PubStrHospital,PubStrTelefono,PubStrEmail")] Doctor doctor, int PubIntIdEspecialidad)
        {
            if(ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();

                var doctorEspecialidad = new DoctorEspecialidad();
                doctorEspecialidad.PubIntIdDoctor = doctor.PubIntIdDoctor;
                doctorEspecialidad.PubIntIdEspecialidad = PubIntIdEspecialidad;

                _context.Add(doctorEspecialidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.Where(m => m.PubIntIdDoctor == id)
                .Include(mx => mx.DoctorEspecialidad).FirstOrDefaultAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad,"PubIntIdEspecialidad","PubStrDescripcion", doctor.DoctorEspecialidad[0].PubIntIdEspecialidad);

            return View(doctor);
        }

        [HttpPost] //Metodo editar encargado del proceso POST al formulario BD
        [ValidateAntiForgeryToken] //Prevenimos cambios externos
        public async Task<IActionResult> Edit (int id, [Bind("PubIntIdDoctor,PubStrNombre,PubStrCredencial,PubStrHospital,PubStrTelefono,PubStrEmail")] Doctor doctor, int PubIntIdEspecialidad)
        {
            if (id != doctor.PubIntIdDoctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();

                    var doctorEspecialidad = await _context.DoctorEspecialidad
                    .FirstOrDefaultAsync(me => me.PubIntIdDoctor == id);

                    _context.Remove(doctorEspecialidad);
                    await _context.SaveChangesAsync();

                    doctorEspecialidad.PubIntIdEspecialidad = PubIntIdEspecialidad;

                    _context.Add(doctorEspecialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.PubIntIdDoctor))
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

            return View(doctor);
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FirstOrDefaultAsync(e => e.PubIntIdDoctor == id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpPost] //Metodo Eliminar encargado del proceso POST al formulario BD
        [ValidateAntiForgeryToken] //Prevenimos cambios externos
        public async Task<IActionResult> Delete (int id)
        {
            var doctorEspecialidad = await _context.DoctorEspecialidad
                .FirstOrDefaultAsync(mx => mx.PubIntIdDoctor == id);

            _context.DoctorEspecialidad.Remove(doctorEspecialidad);
            await _context.SaveChangesAsync();

            var doctor = await _context.Doctor.FindAsync(id);

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.PubIntIdDoctor == id);
        }
    }
    
}