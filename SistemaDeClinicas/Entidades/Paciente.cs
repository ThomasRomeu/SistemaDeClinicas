using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeClinicas.Entidades
{
    public sealed class Paciente : Persona
    {
        [Key]
        public int idPaciente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Numero de Historia Clinica"),
        Range(1, 99999, ErrorMessage = "Debe ser un Numero de Historia Clinica entre los rangos 1 y 99999")]
        public int NroHistoriaClinica { get; set; }
        public List<Consulta> ConsultasRealizadas { get; set; }


        public Paciente()
        {

        }

        public Paciente(string nombre, string apellido, int nroDoc, int nroHistoriaClinica)
            : base(nombre, apellido, nroDoc)
        {
            this.NroHistoriaClinica = nroHistoriaClinica;
            this.ConsultasRealizadas = new List<Consulta>();
        }

        
    }
}