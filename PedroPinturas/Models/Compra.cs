using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PedroPinturas.Models
{
    public class Compra
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public Producto? Producto {get; set;}
        public int Cantidad { get; set; }

        public Compra() {
            this.Producto = new Producto();
            this.Cantidad= 0;
        }
    }
}
