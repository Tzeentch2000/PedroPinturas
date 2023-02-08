using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Models
{
        public enum Calidad { Estandar,Premium}
        public enum Productos { Spray, Cubo, Rotulador}
    public class Producto
    {
        public string Id { get; set; }
        public Color Color { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio {
            get {
                decimal price = 0;

                if(Productos.Equals(Productos.Spray) && Calidad.Equals(Calidad.Estandar))
                {
                    price = 3.40m;
                }
                if (Productos.Equals(Productos.Spray) && Calidad.Equals(Calidad.Premium))
                {
                    price = 6.50m;
                }
                if (Productos.Equals(Productos.Cubo) && Calidad.Equals(Calidad.Estandar))
                {
                    price = 13;
                }
                if (Productos.Equals(Productos.Cubo) && Calidad.Equals(Calidad.Premium))
                {
                    price = 23;
                }
                if (Productos.Equals(Productos.Rotulador) && Calidad.Equals(Calidad.Estandar))
                {
                    price = 3.45m;
                }
                if (Productos.Equals(Productos.Rotulador) && Calidad.Equals(Calidad.Premium))
                {
                    price = 5.10m;
                }
                return price * Cantidad;
            }
        }
        public string Descripcion { 
            get {

                var description = new StringBuilder();

                if (Productos.Equals(Productos.Spray)) {
                    description.AppendLine("-Aerosol de pintura de altas prestaciones de baja presión y acabado mate.");
                    description.AppendLine("-Maxima precisión.");
                    description.AppendLine("-Secado ultrarápido.");
                    description.AppendLine("-Muelle de presión suave.");
                    description.AppendLine("-Alta cubrición");
                    description.AppendLine("-Excelente resistencia al exterior");
                }
                if (Productos.Equals(Productos.Cubo))
                {
                    description.AppendLine("Pintura plástica mate para uso en interior, con buen anclaje y cubrición.");
                    description.AppendLine("Alta transpirabilidad.");
                    description.AppendLine("Indicada  en obra y mantenimiento de techos, sótanos parkings");
                    description.AppendLine("Alta cubrición.");

                }
                if (Productos.Equals(Productos.Rotulador))
                {
                    description.AppendLine("Rotuladores de pintura al agua.");
                    description.AppendLine("Acabado mate.");
                    description.AppendLine("Rellenables.");
                    description.AppendLine("Gran opacidad.");
                }
                return description.ToString();
            } 
        }

        public Calidad Calidad { get; set; }

        public Productos Productos { get; set; }

        private static int idNumberSeed = 1;

        public Producto()
        {
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            this.Color = new Color();
            this.Cantidad = 0;
            this.Calidad = Calidad.Estandar;
            this.Productos = Productos.Spray;
        }

        public Producto(Color color, int cantidad, Calidad calidad , Productos productos){
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            this.Color = color;
            this.Cantidad = cantidad;     
            this.Calidad = calidad;
            this.Productos = productos;
        }

    }
}
