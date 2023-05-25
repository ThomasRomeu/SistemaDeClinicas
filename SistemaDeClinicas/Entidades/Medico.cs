using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeClinicas.Entidades
{
    public sealed class Medico : Persona
    {
        [Key]
        public int idMedico { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Numero de Matricula"),
        Range(10000, 99999, ErrorMessage = "Debe ser un Numero de Matricula entre los rangos 10000 y 99999")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Especialidad")]
        public string Especialidad { get; set; }
        public List<Consulta> ConsultasMedico { get; set; }

        public Medico()
        {

        }

        public Medico(string nombre, string apellido, int nroDoc, int matricula, string especialidad)
            : base(nombre, apellido, nroDoc)
        {
            this.Matricula = matricula;
            this.Especialidad = especialidad;
        }

        
    }
}