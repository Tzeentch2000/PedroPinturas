using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PedroPinturas.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public Producto? Producto {get; set;}
        public int Cantidad { get; set; }

        public Compra() { 
            this.Producto = new Producto();
            this.Cantidad= 0;
        }
    }
}
