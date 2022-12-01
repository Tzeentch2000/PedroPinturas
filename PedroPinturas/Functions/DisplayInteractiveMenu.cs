using PedroPinturas.Exceptions;
using PedroPinturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
                    username = Metodos.CheckString("Introduce un username");
                    Metodos.CheckUsername(username);
                    check = false;
                }
                catch (UsernameAlreadyExistException e)
                {
                    Console.WriteLine(e.Message);
                    Metodos.Olog.Add(e.Message);
                }
            } while (check);
            check = true;
            do
            {
                password = Metodos.CheckString("Introduce una password");
                password2 = Metodos.CheckString("Repite tu password");
                if (!String.Equals(password, password2))
                {
                    Console.WriteLine("Las password no coinciden");
                    Metodos.Olog.Add("Contraseñas no coinciden");
                }
            } while (!String.Equals(password, password2));
            nameSurname = Metodos.CheckString("Introduce tu name y surname");
            do
            {
                try
                {
                    Console.WriteLine("Introduce tu phone");
                    string tel = Console.ReadLine();
                    phone = Metodos.CheckPhone(tel);
                    check = false;
                }
                catch (PhoneException e)
                {
                    Console.WriteLine(e.Message);
                    Metodos.Olog.Add(e.Message);
                }
            } while (check);
            return new Usuario(username, password, nameSurname, phone);
        }

        //Menu login
        public static Usuario Login()
        {
            string username = Metodos.CheckString("Introduce el username");
            string password = Metodos.CheckString("Introduce tu password");

            var usuario = Metodos.CheckLogin(username, password);
            if (usuario == null)
            {
                throw new IncorrectUserException("Incorrect username or password");
            }
            return usuario;
        }

        public static void InitialMenu(Usuario usuario)
        {
            int numero = 0;
            do
            {
                numero = Metodos.CheckNumber(DisplayMenu.Menu(), 4);
                switch (numero)
                {
                    case 1:
                        {
                            usuario.Pedidos.Add(MakeOrder());
                            Console.WriteLine(Metodos.History(usuario.Pedidos));
                            Metodos.WriteUser();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(Metodos.History(usuario.Pedidos));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(Metodos.ReadColors());
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Cerrando sesión...");
                            break;
                        }
                }
            } while (numero != 4);
        }
        public static Pedido MakeOrder()
        {
            Pedido pedido = new Pedido();
            bool check = true;
            do
            {
                int numero = Metodos.CheckNumber(DisplayMenu.Productos(),3);
                int numProducto = 0;
                Producto producto = new Producto();
                switch (numero)
                {
                    case 1:
                        {
                            producto.productos = Productos.Spray;
                            numProducto = Metodos.CheckNumber(DisplayMenu.Spray(),2);
                            switch (numProducto)
                            {
                                case 1:
                                    {
                                        producto.calidad = Calidad.Estandar;
                                        break;
                                    }
                                case 2:
                                    {
                                        producto.calidad = Calidad.Premium;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2:
                        {
                            producto.productos = Productos.Cubo;
                            numProducto = Metodos.CheckNumber(DisplayMenu.Cubo(), 2);
                            switch (numProducto)
                            {
                                case 1:
                                    {
                                        producto.calidad = Calidad.Estandar;
                                        break;
                                    }
                                case 2:
                                    {
                                        producto.calidad = Calidad.Premium;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            producto.productos = Productos.Rotulador;
                            numProducto = Metodos.CheckNumber(DisplayMenu.Rotulador(), 2);
                            switch (numProducto)
                            {
                                case 1:
                                    {
                                        producto.calidad = Calidad.Estandar;
                                        break;
                                    }
                                case 2:
                                    {
                                        producto.calidad = Calidad.Premium;
                                        break;
                                    }
                            }
                            break;
                        }
                }
                producto.cantidad = Metodos.CheckNumber(DisplayMenu.Cantidad(), 50);
                Console.WriteLine(DisplayMenu.Color());
                int numColor = Metodos.CheckNumber(Metodos.ReadColors(),Metodos.GetColors().Count);
                //Controlar que color no sea null
                var color = Metodos.GetColors().Find(color => color.Id.Equals(numColor.ToString()));
                producto.color = color;
                int numSeguirComprando = Metodos.CheckNumber(DisplayMenu.SeguirComprando(), 2);
                if (numSeguirComprando == 2)
                {
                    check = false;
                }
                pedido.productos.Add(producto);
            } while (check);
            int numEntrega = Metodos.CheckNumber(DisplayMenu.Entrega24H(), 2);
            switch (numEntrega)
            {
                case 1:
                    {
                        pedido.Entrega24h = true;
                        break;
                    }
                case 2:
                    {
                        pedido.Entrega24h = false;
                        break;
                    }
            }
            pedido.Direccion = Metodos.CheckString(DisplayMenu.Direccion());
            pedido.Fecha = DateTime.Now;
            return pedido;
        }
    }
}
