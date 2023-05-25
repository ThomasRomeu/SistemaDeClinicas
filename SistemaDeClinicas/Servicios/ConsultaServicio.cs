using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeClinicas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeClinicas.Servicios
{
        public interface IConsultaServicio
    {
        List<Consulta> MostrarConsultas();   
    }

    public class ConsultaServicio : IConsultaServicio
    {
        private readonly ClinicaDbContext _context;

        public ConsultaServicio(ClinicaDbContext context)
        {
            _context = context;
        }

        public List<Consulta> MostrarConsultas()
        {
            return _context.Consultas.ToList();
        }

    }
}