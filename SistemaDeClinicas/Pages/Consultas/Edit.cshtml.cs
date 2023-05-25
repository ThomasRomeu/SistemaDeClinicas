using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;
using SistemaDeClinicas.Servicios;

namespace SistemaDeClinicas._Pages_Consultas
{
    public class EditModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        [TempData]
        public string MensajeEditado { get; set; }

        private IMedicoServicio _medicoSrv;
        private IPacienteServicio _pacienteSrv;

        public List<SelectListItem> MedicosLista { get; set; }
        public List<SelectListItem> PacientesLista { get; set; }

        public EditModel(SistemaDeClinicas.Entidades.ClinicaDbContext context, IMedicoServicio medicoSrv, IPacienteServicio pacienteSrv)
        {
            _context = context;
            _medicoSrv = medicoSrv;
            _pacienteSrv = pacienteSrv;
        }

        [BindProperty]
        public Consulta Consulta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }
            Consulta = consulta;
            MedicosLista = _medicoSrv.MostrarMedicos().Select(a => new SelectListItem { Value = a.idMedico.ToString(), Text = a.NombreCompleto }).ToList();
            PacientesLista = _pacienteSrv.MostrarPacientes().Select(a => new SelectListItem { Value = a.idPaciente.ToString(), Text = a.NombreCompleto }).ToList();
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "idMedico", "idMedico");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "idPaciente", "idPaciente");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {


            _context.Attach(Consulta).State = EntityState.Modified;
            MensajeEditado = "Se edito correctamente la Consulta";

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(Consulta.IdConsulta))
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

        private bool ConsultaExists(int id)
        {
            return (_context.Consultas?.Any(e => e.IdConsulta == id)).GetValueOrDefault();
        }
    }
}
