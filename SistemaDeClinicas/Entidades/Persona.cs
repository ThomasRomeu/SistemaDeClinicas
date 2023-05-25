using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SistemaDeClinicas.Entidades
{
    public abstract class Persona
    {
        [Required(ErrorMessage = "Debe ingresar un Nombre"),
        MaxLength(30, ErrorMessage = "El Nombre no debe superar los 30 caracteres"),
        MinLength(2, ErrorMessage = "El Nombre debe contener mas de 1 caracter")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido"),
        MaxLength(30, ErrorMessage = "El Apellido no debe superar los 30 caracteres"),
        MinLength(2, ErrorMessage = "El Apellido debe contener mas de 1 caracter")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Numero de Documento"),
        Range(10000000, 99999999, ErrorMessage = "Debe ser un Numero de Documento valido")]
        public int NroDoc { get; set; }
        

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, int nroDoc)
        {
            Nombre = nombre;
            Apellido = apellido;
            NroDoc = nroDoc;
        }

        [NotMapped]
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }
    }
}