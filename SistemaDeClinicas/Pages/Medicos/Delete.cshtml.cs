using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;

namespace SistemaDeClinicas._Pages_Medicos
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
      public Medico Medico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.idMedico == id);

            if (medico == null)
            {
                return NotFound();
            }
            else 
            {
                Medico = medico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }
            var medico = await _context.Medicos.FindAsync(id);

            if (medico != null)
            {
                Medico = medico;
                MensajeBorrado = "Se elimino correctamente el Medico";
                _context.Medicos.Remove(Medico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
