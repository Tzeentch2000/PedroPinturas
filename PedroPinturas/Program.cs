using PedroPinturas.Exceptions;
using PedroPinturas.Functions;
using PedroPinturas.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace PedroPinturas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> users = new List<Usuario>();
            Usuario usuario = new Usuario();

            do
            {
                int number = Metodos.CheckNumber(DisplayMenu.Initial(), 2);
                switch (number)
                {
                    case 1:
                        try
                        {
                            //Login
                            usuario = DisplayInteractiveMenu.login(users);
                            Console.WriteLine($"Bienvenido {usuario.NombreApellidos}");
                            //metodo
                            DisplayInteractiveMenu.InitialMenu(usuario);
                        }
                        catch (IncorrectUserException e)
                        {
                            Console.WriteLine(e.Message);
                            Metodos.Olog.Add(e.Message);
                        }
                        break;
                    case 2:
                        //Register
                        usuario = DisplayInteractiveMenu.Registrarse(users);
                        Console.WriteLine("¡Usuario registrado con éxito!");
                        users.Add(usuario);
                        DisplayInteractiveMenu.InitialMenu(usuario);
                        break;
                        //metodo
                }
            } while (true);
        }
    }
}