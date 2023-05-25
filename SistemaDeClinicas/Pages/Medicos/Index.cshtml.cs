using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;
using SistemaDeClinicas.Servicios;

namespace SistemaDeClinicas._Pages_Medicos
{
    public class IndexModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        private IMedicoServicio _medicoServicio;
        public string NombreOrden;
        public string ApellidoOrden;

        [TempData]
        public string MensajeExitoso { get; set; }
        [TempData]
        public string MensajeBorrado { get; set; }
        [TempData]
        public string MensajeEditado { get; set; }

        public IndexModel(SistemaDeClinicas.Entidades.ClinicaDbContext context, IMedicoServicio medicoSrv)
        {
            _context = context;
            _medicoServicio = medicoSrv;
        }

        public IList<Medico> Medico { get;set; } = default!;

        public async Task OnGetAsync(string FiltroNombre, string FiltroApellido, string CampoOrden, string LimpiarFiltros)
        {
            NombreOrden = (CampoOrden == "Nombre_Asc") ? "Nombre_Desc" : "Nombre_Asc";

            if (_context.Medicos != null)
            {
                Medico = await _context.Medicos.ToListAsync();
            }

            // Logica para filtrar por x paramatro 

            if (LimpiarFiltros != null && LimpiarFiltros.Length > 0)
            {
                Medico = _medicoServicio.MostrarMedicos();
            }

            if (FiltroNombre != null && FiltroNombre.Length > 0)
            {
                Medico = Medico.Where(x => x.Nombre.ToUpper().Contains(FiltroNombre.ToUpper())).ToList();
            }

            if (FiltroApellido != null && FiltroApellido.Length > 0)
            {
                Medico = Medico.Where(x => x.Apellido.ToUpper().Contains(FiltroApellido.ToUpper())).ToList();
            }

            // Logica para ordernar por campos
            switch (CampoOrden)
            {
                case "Nombre_Asc":
                    Medico = Medico.OrderBy(x => x.Nombre).ToList();
                    break;
                case "Nombre_Desc":
                    Medico = Medico.OrderByDescending(x => x.Nombre).ToList();
                    break;
                case "Apellido_Asc":
                    Medico = Medico.OrderBy(x => x.Apellido).ToList();
                    break;
                case "Apellido_Desc":
                    Medico = Medico.OrderByDescending(x => x.Apellido).ToList();
                    break;
                default:
                    Medico = Medico.OrderBy(x => x.idMedico).ToList();
                    break;
            }
        }
    }
}
