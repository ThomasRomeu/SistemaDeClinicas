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
    public class DetailsModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;

        public DetailsModel(SistemaDeClinicas.Entidades.ClinicaDbContext context)
        {
            _context = context;
        }

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
    }
}
