using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Product
{
    public  class UpdateProduct 
    {
     
        public string Nombre { get; set; } = String.Empty;


        public string Descripcion { get; set; } = String.Empty;
   
        public float PrecioUnitario { get; set; }

        public float CantidadUnidad { get; set; }

        public string Medida { get; set; } = null!;
        public int IdCategoria { get; set; } 

    }
}
