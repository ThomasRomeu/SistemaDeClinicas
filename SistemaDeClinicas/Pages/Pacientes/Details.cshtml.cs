using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;
using System.Linq;

namespace SistemaDeClinicas._Pages_Pacientes
{
    public class DetailsModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;

        public List<Consulta> Consultas { get; set; }

        public DetailsModel(SistemaDeClinicas.Entidades.ClinicaDbContext context)
        {
            _context = context;
        }

        public Paciente Paciente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            Paciente = await _context.Pacientes.Include(p => p.ConsultasRealizadas).ThenInclude(c => c.Medico).FirstOrDefaultAsync(m => m.idPaciente == id);

            
            if (Paciente == null)
            {
                return NotFound();
            }
            
            Consultas = Paciente.ConsultasRealizadas.ToList();

            return Page();
        }
    }
}
