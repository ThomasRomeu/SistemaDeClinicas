using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;

namespace SistemaDeClinicas._Pages_Pacientes
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        [TempData]
        public string MensajeBorrado { get; set; }

        public DeleteModel(SistemaDeClinicas.Entidades.ClinicaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Paciente Paciente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FirstOrDefaultAsync(m => m.idPaciente == id);

            if (paciente == null)
            {
                return NotFound();
            }
            else 
            {
                Paciente = paciente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente != null)
            {
                Paciente = paciente;
                MensajeBorrado = "Se elimino correctamente al Paciente";
                _context.Pacientes.Remove(Paciente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
