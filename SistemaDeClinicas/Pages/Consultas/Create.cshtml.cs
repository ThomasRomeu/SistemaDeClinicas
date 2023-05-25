using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeClinicas.Entidades;
using SistemaDeClinicas.Servicios;

namespace SistemaDeClinicas._Pages_Consultas
{
    public class CreateModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        [TempData]
        public string MensajeExitoso { get; set; }
        private IMedicoServicio _medicoSrv;
        private IPacienteServicio _pacienteSrv;

        public List<SelectListItem> MedicosLista { get; set; }
        public List<SelectListItem> PacientesLista { get; set; }

        public CreateModel(SistemaDeClinicas.Entidades.ClinicaDbContext context, IMedicoServicio medicoSrv, IPacienteServicio pacienteSrv)
        {
            _context = context;
            _medicoSrv = medicoSrv;
            _pacienteSrv = pacienteSrv;
            MedicosLista = _medicoSrv.MostrarMedicos().Select(a => new SelectListItem { Value = a.idMedico.ToString(), Text = a.NombreCompleto }).ToList();
            PacientesLista = _pacienteSrv.MostrarPacientes().Select(a => new SelectListItem { Value = a.idPaciente.ToString(), Text = a.NombreCompleto }).ToList();
        }

        public IActionResult OnGet()
        {           
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "idMedico", "idMedico");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "idPaciente", "idPaciente");
            return Page();
        }

        [BindProperty]
        public Consulta Consulta { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {

            _context.Consultas.Add(Consulta);
            MensajeExitoso = "Se creo correctamente la Consulta";
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
