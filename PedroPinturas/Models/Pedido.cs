using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PedroPinturas.Models
{
    class Pedido
    {
        public string Id { get; set; }

        //Date de hoy
        public DateTime Fecha { get; set; }
        //thisDay.ToString("g");
   

        //Lista de productos
        public List<Producto> productos { get; set; }

        public bool Entrega24h { get; set; }

        public string Direccion { get; set; }

        public decimal precio { get {
                decimal p = 0m;
                foreach (var producto in this.productos)
                {
                    p += producto.precio;
                }
                return p;
            }
        }

        private static int idNumberSeed = 1;
        public Pedido()
        {
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            //this.Fecha = DateTime.Today;
            this.productos = new List<Producto>();
            this.Entrega24h= false;
        }
        /*public Pedido(List<Producto> productos, Boolean entrega, string direccion, decimal precio)
        {
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            this.productos = productos;
            this.Entrega24h = entrega;
            this.Direccion = direccion;
            this.Fecha = DateTime.Today;
        }*/
    }
}