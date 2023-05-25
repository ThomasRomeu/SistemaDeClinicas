using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeClinicas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeClinicas.Servicios
{
    public interface IPacienteServicio
    {
        List<Paciente> MostrarPacientes();
    }

    public class PacienteServicio : IPacienteServicio
    {
        private readonly ClinicaDbContext _context;

        public PacienteServicio(ClinicaDbContext context)
        {
            _context = context;
        }

        public List<Paciente> MostrarPacientes()
        {
            return _context.Pacientes.ToList();
        }
    }
}