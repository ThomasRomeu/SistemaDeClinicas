using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;

namespace SistemaDeClinicas._Pages_Medicos
{
    public class EditModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        [TempData]
        public string MensajeEditado { get; set; }

        public EditModel(SistemaDeClinicas.Entidades.ClinicaDbContext context)
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

            var medico =  await _context.Medicos.FirstOrDefaultAsync(m => m.idMedico == id);
            if (medico == null)
            {
                return NotFound();
            }
            Medico = medico;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {


            _context.Attach(Medico).State = EntityState.Modified;
            MensajeEditado = "Se edito correctamente el Medico" + " " + Medico.NombreCompleto;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(Medico.idMedico))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicoExists(int id)
        {
          return (_context.Medicos?.Any(e => e.idMedico == id)).GetValueOrDefault();
        }
    }
}
