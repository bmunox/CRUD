using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class NuevoViewModel
    {
        public int idCurso { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="Curso")]
        public string nombre { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public Nullable<int> bhabilitado { get; set; }
    }
}