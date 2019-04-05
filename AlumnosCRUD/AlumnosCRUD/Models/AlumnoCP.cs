using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumnosCRUD.Models
{
    public class AlumnoCP
    {
        [Required]
        [Display(Name = "Inserte un nombre")]
        public string NombreAlumno { get; set; }
        [Required]
        [Display(Name = "Inserte apellidos")]
        public string ApellidoAlumno { get; set; }
        [Required]
        [Display(Name = "Inserte su edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Inserte su sexo Masculino o Femenino")]
        public string Sexo { get; set; }
    }
    [MetadataType(typeof(AlumnoCP))]
    public partial class Alumno {
        public string NombreCompleto { get { return NombreAlumno + " " + ApellidoAlumno; } }
    }
}