using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Models
{
    public class Compra{
    [Key]
    public int Id { get; set; }
    public Producto? Producto;
    public int Cantidad;

    private static int idNumberSeed = 1;

    public Compra(){
        this.Id = idNumberSeed.ToString();
        idNumberSeed++;
        this.Producto=new Producto();
        this.Cantidad= cantidad;
    }

    public Compra(Producto producto, Cantidad cantidad){
        this.Id = idNumberSeed.ToString();
        idNumberSeed++;
        this.Producto = producto;
        this.Cantidad = cantidad;
    }
}
}
