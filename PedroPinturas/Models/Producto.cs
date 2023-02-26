using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PedroPinturas.Models
{
    public class Producto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public Color Color { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }

        public string Calidad { get; set; }

        public string Productos { get; set; }

        public Producto()
        {

        }

        public Producto(Color color, string calidad , string productos){
            //this.Id = idNumberSeed.ToString();
            //idNumberSeed++;
            this.Color = color;    
            this.Calidad = calidad;
            this.Productos = productos;
            this.Descripcion = "";
        }

    }
}
