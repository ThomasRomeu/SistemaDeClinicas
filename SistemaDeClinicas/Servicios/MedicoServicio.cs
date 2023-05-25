using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeClinicas.Entidades;
using Microsoft.EntityFrameworkCore;


namespace SistemaDeClinicas.Servicios
{
    public interface IMedicoServicio
    {
        List<Medico> MostrarMedicos();
    }

    public class MedicoServicio : IMedicoServicio
    {
        private readonly ClinicaDbContext _context;

        public MedicoServicio(ClinicaDbContext context)
        {
            _context = context;
        }

        public List<Medico> MostrarMedicos()
        {
            return _context.Medicos.ToList();
        }

    }
}