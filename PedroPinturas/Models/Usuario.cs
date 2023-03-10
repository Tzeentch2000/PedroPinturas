﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PedroPinturas.Models
{
    public class Usuario
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public string User { get; set; }
        public string Contrasenia { get; set; }
        public string NombreApellidos { get; set; }
        public int Telefono { get; set; }
        public bool IsAdmin { get
            {
                return false;
            }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Pedido> Pedidos { get; set; }

        //Listado de pedidos

        //private static int idNumberSeed = 1;

        public Usuario()
        {
            //Id = idNumberSeed.ToString();
            //idNumberSeed++;
            this.User = "";
            this.Contrasenia = "";
            this.NombreApellidos = "";
            this.Telefono = -1;
            this.Pedidos = new List<Pedido>();
        }

        public Usuario(int id,string username, string password, string nameSurname, int phone)
        {
            //Id = idNumberSeed.ToString();
            //idNumberSeed++;
            //Id = "2";
            Id = id;
            User = username;
            Contrasenia = password;
            NombreApellidos = nameSurname;
            Telefono = phone;
            Pedidos = new List<Pedido>();
            //Listado de pedidos declarado
        }

        public Usuario(string username, string password, string nameSurname, int phone)
        {
            //Id = idNumberSeed.ToString();
            //idNumberSeed++;
            //Id = "2";
            User = username;
            Contrasenia = password;
            NombreApellidos = nameSurname;
            Telefono = phone;
            Pedidos = new List<Pedido>();
            //Listado de pedidos declarado
        }
    }
}
