using PedroPinturas.Exceptions;
using PedroPinturas.Models;
using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace PedroPinturas.Functions
{
    internal static class Metodos
    {
        public static List<Usuario> users = LoadUsers();
        public static Log Olog = new Log(@"./Log");
        //Comprobar que se ha introducido un número valido y si no preguntar hasta que se introduzca
        public static int CheckNumber(string menu, int range)
        {
            bool check = true;
            int number = 0;
            do
            {
                try
                {
                    AnsiConsole.MarkupLine(menu);
                    number = Convert.ToInt32(Console.ReadLine());
                    if(CheckRange(number, range))
                    {
                        check = false;
                    }
                }
                catch (FormatException e)
                {
                    AnsiConsole.MarkupLine($"Número incorrecto [bold red]{e.Message}[/]");
                    Olog.Add(e.Message);
                }
                catch(OutOfRangeException e)
                {
                    AnsiConsole.MarkupLine($"[bold red]{e.Message}[/]");
                    Olog.Add(e.Message);
                }

            } while (check);
            return number;
        }

        public static string CheckString(string messge)
        {
            bool check = true;
            string characters = "";
            do
            {
                try
                {
                    AnsiConsole.MarkupLine(messge);
                    characters = Console.ReadLine().Trim();
                    CheckEmptyCharacter(characters);
                    check = false;
                }
                catch(EmptyCharacterExceptions e)
                {
                    AnsiConsole.MarkupLine($"[bold red]{e.Message}[/]");
                    Olog.Add("Campo vacío");
                }

            } while (check);
            return characters;
        }

        //Comprobar el phone number
        //Comprobar teléfono
        public static int CheckPhone(string phone)
        {
            int numero = 0;
            try
            {
                if (phone.Length != 9)
                {
                    throw new PhoneException("Phone incorrecto");
                }
                numero = Convert.ToInt32(phone);
            }
            catch (System.FormatException)
            {
                throw new PhoneException("Phone incorrecto");
            }
            return numero;
        }

        //Comprobar si existe ese nombre de usuario
        public static bool CheckUsername(string username)
        {
            var user = users.Find(user => user.User.Equals(username));
            if (user != null)
            {
                throw new UsernameAlreadyExistException("El nombre de usuario que has introducido ya existe");
            }
            return true;
        }
        //Comprobar si el nombre de usuario y la contraseña pertenecen a un usuario
        public static Usuario CheckLogin(string username, string password)
        {
            var user = users.Find(user => user.User.Equals(username) && user.Contrasenia.Equals(password));
            return user;
        }

        public static List<Models.Color> GetColors()
        {
            string fileName = $@"resources/colores.json";
            string jsonString = File.ReadAllText(fileName);
            List<Models.Color>? lista = JsonSerializer.Deserialize<List<Models.Color>>(jsonString)!;
            return lista;
        }
        public static string ReadColors()
        {
                List<Models.Color>? lista = GetColors();
                var colores = new System.Text.StringBuilder();
                int i = 1;
                foreach(var color in lista)
            {
                colores.AppendLine($"[{color.Code}]{i}- {color.Name} {color.Code}[/]");
                i++;
            }
            return colores.ToString();
        }

        public static Table History(List<Pedido> pedidos) {
            var table = new Table();
            // Creamos las columnas
            table.AddColumn(new TableColumn("Precio").Centered());
            table.AddColumn(new TableColumn("Fecha").Centered());
            table.AddColumn(new TableColumn("Direccion").Centered());
            table.AddColumn(new TableColumn("Productos").Centered());
            foreach (var pedido in pedidos)
            {
                var productos = new StringBuilder();
                foreach (var producto in pedido.Productos)
                {
                    productos.AppendLine($"x{producto.Cantidad} {producto.Productos} " +
                        $"{producto.Calidad} [{producto.Color.Code}]{producto.Color.Name}[/] {producto.Precio}$");
                }
                table.AddRow(new Markup($"[paleturquoise1]{pedido.Precio}$[/]"),
                    new Markup($"[paleturquoise1]{pedido.Fecha.ToString("dd/MM/yyyy")}[/]"),
                    new Markup($"[paleturquoise1]{pedido.Direccion}[/]"), 
                    new Panel($"{productos.ToString()}"));
            }
            return table;
        }

        public static bool CheckEmptyCharacter(string text)
        {
            if (text.Length == 0)
            {
                throw new EmptyCharacterExceptions("No puedes dejar campos vacíos");
            }
            return true;
        }

        public static bool CheckRange(int num,int range)
        {
            if(num<1 || num > range)
            {
                throw new OutOfRangeException("Numero fuera de rango");
            }
            return true;
        }

        public static List<Usuario> LoadUsers()
        {
            try
            {
                string fileName = $@"resources/users/usuarios.json";
                string jsonString = File.ReadAllText(fileName);
                List<Usuario>? lista = JsonSerializer.Deserialize<List<Usuario>>(jsonString)!;
                return lista;
            }
            //DirectoryNotFoundException FileNotFoundException
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }

        public static void WriteUser()
        {
            string fileName = $@"resources/users/usuarios.json";
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Pedido> DateFilter(List<Pedido> pedidos, String fecha)
        {
            //thisDate1.ToString("MM/dd/yyyy") + ".");
            List<Pedido> pedidosFiltro = pedidos.FindAll(pedido => pedido.Fecha.ToString("dd/MM/yyyy").Equals(fecha));
            return pedidosFiltro;
        }
    }
}
