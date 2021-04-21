using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class TablaViewModel
    {
        public int idCurso {get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> bhabilitado { get; set; }
    }
}