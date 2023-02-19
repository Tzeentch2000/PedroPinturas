using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Models
{
    public class Usuario
    {
        public string Id { get; }
        public string User { get; set; }
        public string Contrasenia { get; set; }
        public string NombreApellidos { get; set; }
        public int Telefono { get; set; }

        public List<Pedido> Pedidos { get; set; }

        //Listado de pedidos

        //private static int idNumberSeed = 1;

        public Usuario()
        {
            //Id = idNumberSeed.ToString();
            //idNumberSeed++;
            this.User = "a";
            this.Contrasenia = "a";
            this.NombreApellidos = "a";
            this.Telefono = -1;
            this.Pedidos = new List<Pedido>();
        }

        public Usuario(string username, string password, string nameSurname, int phone)
        {
            //Id = idNumberSeed.ToString();
            //idNumberSeed++;
            User = username;
            Contrasenia = password;
            NombreApellidos = nameSurname;
            Telefono = phone;
            Pedidos = new List<Pedido>();
            //Listado de pedidos declarado
        }
    }
}
