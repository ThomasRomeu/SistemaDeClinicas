using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;

namespace SistemaDeClinicas._Pages_Consultas
{
    public class DetailsModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;

        public DetailsModel(SistemaDeClinicas.Entidades.ClinicaDbContext context)
        {
            _context = context;
        }

      public Consulta Consulta { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            Consulta = await _context.Consultas.Include(p => p.Medico).Include(m => m.Paciente).FirstOrDefaultAsync(m => m.IdConsulta == id);

            if (Consulta == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
