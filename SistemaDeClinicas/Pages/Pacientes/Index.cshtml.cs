using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;
using SistemaDeClinicas.Servicios;

namespace SistemaDeClinicas._Pages_Pacientes
{
    public class IndexModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        private IPacienteServicio _pacienteServicio;
        public string NombreOrden;
        public string ApellidoOrden;

        [TempData]
        public string MensajeExitoso { get; set; }
        [TempData]
        public string MensajeBorrado { get; set; }
        [TempData]
        public string MensajeEditado { get; set; }

        public IndexModel(SistemaDeClinicas.Entidades.ClinicaDbContext context, IPacienteServicio pacienteSrv)
        {
            _context = context;
            _pacienteServicio = pacienteSrv;
        }

        public IList<Paciente> Paciente { get; set; } = default!;

        public async Task OnGetAsync(string FiltroNombre, string FiltroApellido, string CampoOrden, string LimpiarFiltros)
        {
            NombreOrden = (CampoOrden == "Nombre_Asc") ? "Nombre_Desc" : "Nombre_Asc";

            if (_context.Pacientes != null)
            {
                Paciente = await _context.Pacientes.ToListAsync();
            }

            // Logica para filtrar por x paramatro

            if (LimpiarFiltros != null && LimpiarFiltros.Length > 0)
            {
                Paciente = _pacienteServicio.MostrarPacientes();
            }

            if (FiltroNombre != null && FiltroNombre.Length > 0)
            {
                Paciente = Paciente.Where(x => x.Nombre.ToUpper().Contains(FiltroNombre.ToUpper())).ToList();
            }

            if (FiltroApellido != null && FiltroApellido.Length > 0)
            {
                Paciente = Paciente.Where(x => x.Apellido.ToUpper().Contains(FiltroApellido.ToUpper())).ToList();
            }

            // Logica para ordernar por campos
            switch (CampoOrden)
            {
                case "Nombre_Asc":
                    Paciente = Paciente.OrderBy(x => x.Nombre).ToList();
                    break;
                case "Nombre_Desc":
                    Paciente = Paciente.OrderByDescending(x => x.Nombre).ToList();
                    break;
                case "Apellido_Asc":
                    Paciente = Paciente.OrderBy(x => x.Apellido).ToList();
                    break;
                case "Apellido_Desc":
                    Paciente = Paciente.OrderByDescending(x => x.Apellido).ToList();
                    break;
                default:
                    Paciente = Paciente.OrderBy(x => x.idPaciente).ToList();
                    break;
            }
        }
    }
}
