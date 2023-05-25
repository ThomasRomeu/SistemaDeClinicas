using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeClinicas.Entidades;

namespace SistemaDeClinicas._Pages_Medicos
{
    public class CreateModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        [TempData]
        public string MensajeExitoso { get; set; }

        public CreateModel(SistemaDeClinicas.Entidades.ClinicaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Medico Medico { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          
            _context.Medicos.Add(Medico);
            MensajeExitoso = "Se creo correctamente el Medico" + " " + Medico.NombreCompleto;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
