using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeClinicas.Entidades
{
    public sealed class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Costo")]
        public int Costo { get; set; }
        public bool ConsolturioOPractica { get; set; }
        public string Descripcion { get; set; }
        public int CostoMaterialDescartable { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

    }
}