using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Entidades;
using SistemaDeClinicas.Servicios;

namespace SistemaDeClinicas._Pages_Consultas
{
    public class IndexModel : PageModel
    {
        private readonly SistemaDeClinicas.Entidades.ClinicaDbContext _context;
        private IConsultaServicio _consultaServicio;
        public string FechaOrden;
            
        [TempData]
        public string MensajeExitoso { get; set; }
        [TempData]
        public string MensajeBorrado { get; set; }
        [TempData]
        public string MensajeEditado { get; set; }

        public IndexModel(SistemaDeClinicas.Entidades.ClinicaDbContext context, IConsultaServicio consultaSrv)
        {
            _context = context;
            _consultaServicio = consultaSrv;
        }

        public IList<Consulta> Consulta { get;set; } = default!;

        public async Task OnGetAsync(DateTime FiltroFecha, string CampoOrden, string LimpiarFiltros)
        {
            FechaOrden = (CampoOrden == "Fecha_Asc") ? "Fecha_Desc" : "Fecha_Asc";

            if (_context.Consultas != null)
            {
                Consulta = await _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente).ToListAsync();
            }


            // Logica para filtrar por x paramatro 

            if (LimpiarFiltros != null && LimpiarFiltros.Length > 0)
            {
                Consulta = _consultaServicio.MostrarConsultas();
            }

            if (FiltroFecha != DateTime.MinValue)
            {
                Consulta = Consulta.Where(x => x.Fecha.Date == FiltroFecha.Date).ToList();
            }
        }
    }
}
