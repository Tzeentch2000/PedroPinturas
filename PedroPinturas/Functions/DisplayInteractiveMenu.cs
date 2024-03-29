﻿using PedroPinturas.Exceptions;
using PedroPinturas.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PedroPinturas.Functions
{
    internal static class DisplayInteractiveMenu
    {
        //Menu registro
        public static Usuario Registrarse()
        {
            string username = "";
            string password = "";
            string password2 = "";
            string nameSurname = "";
            bool check = true;
            int phone = 0;
            do
            {
                try
                {
                    username = Metodos.CheckString("Introduce un[bold blue] username [/]");
                    Metodos.CheckUsername(username);
                    check = false;
                }
                catch (UsernameAlreadyExistException e)
                {
                    AnsiConsole.MarkupLine($"[bold red]{e.Message}[/]");
                    Metodos.Olog.Add(e.Message);
                }
            } while (check);
            check = true;
            do
            {
                password = Metodos.CheckString("Introduce una[bold blue] password [/]");
                password2 = Metodos.CheckString("Repite tu[bold blue] password [/]");
                if (!String.Equals(password, password2))
                {
                    AnsiConsole.MarkupLine("[bold red]Las passwords no coinciden[/]");
                    Metodos.Olog.Add("Contraseñas no coinciden");
                }
            } while (!String.Equals(password, password2));
            nameSurname = Metodos.CheckString("Introduce tu[bold blue] name [/]and[bold blue] surname [/]");
            do
            {
                try
                {
                    AnsiConsole.MarkupLine("Introduce tu[bold blue] phone [/]");
                    string tel = Console.ReadLine();
                    phone = Metodos.CheckPhone(tel);
                    check = false;
                }
                catch (PhoneException e)
                {
                    AnsiConsole.MarkupLine($"[bold red]{e.Message}[/]");
                    Metodos.Olog.Add(e.Message);
                }
            } while (check);
            return new Usuario(username, password, nameSurname, phone);
        }

        //Menu login
        public static Usuario Login()
        {
            string username = Metodos.CheckString("Introduce tu[bold blue] username [/]");
            AnsiConsole.MarkupLine("Introduce tu [blue]password[/]");
            string password = AnsiConsole.Prompt(new TextPrompt<string>("").PromptStyle("fuchsia").Secret());

            var usuario = Metodos.CheckLogin(username, password);
            if (usuario == null)
            {
                throw new IncorrectUserException("Incorrect username or password");
            }
            return usuario;
        }

        public static void InitialMenu(Usuario usuario)
        {
            string accion = "";
            do
            {
                accion = DisplayMenu.Menu();
                if (accion.Equals("Hacer pedido"))
                {
                    usuario.Pedidos.Add(MakeOrder());
                    //Console.WriteLine(Metodos.History(usuario.Pedidos));
                    Metodos.WriteUser();
                } else if (accion.Equals("Historial de pedidos"))
                {
                    AnsiConsole.Write(Metodos.History(usuario.Pedidos));
                } else if (accion.Equals("Filtrar pedidos por fecha"))
                {
                    Console.WriteLine("Introduce una fecha con este formato 01/01/2000");
                    string fecha = Console.ReadLine();
                    AnsiConsole.Write(Metodos.History(Metodos.DateFilter(usuario.Pedidos, fecha)));
                } else if (accion.Equals("Colores disponibles"))
                {
                    AnsiConsole.MarkupLine(Metodos.ReadColors());
                } else
                {
                    AnsiConsole.MarkupLine("[paleturquoise1]Cerrando sesión...[/]");
                    Console.WriteLine();
                }
            } while (!accion.Equals("Cerrar sesión"));
        }
        public static Pedido MakeOrder()
        {
            Pedido pedido = new Pedido();
            bool check = true;
            do
            {
                Producto producto = new Producto();
                string tipoProducto = DisplayMenu.Productos();
                Console.WriteLine(tipoProducto);
                string calidad = "";
                if (tipoProducto.Equals("Spray"))
                {
                    producto.productos = Productos.Spray;
                    calidad = DisplayMenu.Spray();
                } else if (tipoProducto.Equals("Cubo"))
                {
                    producto.productos = Productos.Cubo;
                    calidad = DisplayMenu.Cubo();
                } else if (tipoProducto.Equals("Rotulador"))
                {
                    producto.productos = Productos.Rotulador;
                    calidad = DisplayMenu.Rotulador();
                }

                Console.WriteLine(calidad);
                //Si empiza por Estandar ya sabemos que es Estandar, y sino que es Premium
                if (calidad.StartsWith("Estandar"))
                {
                    producto.calidad = Calidad.Estandar;
                } else
                {
                    producto.calidad = Calidad.Premium;
                }
 
                producto.cantidad = Metodos.CheckNumber(DisplayMenu.Cantidad(), 50);
                AnsiConsole.MarkupLine(DisplayMenu.Color());
                int numColor = Metodos.CheckNumber(Metodos.ReadColors(),Metodos.GetColors().Count);
                //Controlar que color no sea null
                var color = Metodos.GetColors().Find(color => color.Id.Equals(numColor.ToString()));
                producto.color = color;
                string seguirComprando = DisplayMenu.SeguirComprando();
                //Si no quiere seguir comprando nos salimos del bucle
                if (seguirComprando.Equals("No"))
                {
                    check = false;
                }
                pedido.productos.Add(producto);
            } while (check);
            string entrega = DisplayMenu.Entrega24H();
            Console.WriteLine(entrega);
            if (entrega.Equals("si"))
            {
                pedido.Entrega24h= true;
            }
            pedido.Direccion = Metodos.CheckString(DisplayMenu.Direccion());
            pedido.Fecha = DateTime.Now;
            return pedido;
        }
    }
}
