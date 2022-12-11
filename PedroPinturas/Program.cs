using PedroPinturas.Exceptions;
using PedroPinturas.Functions;
using PedroPinturas.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PedroPinturas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            Usuario usuario = new Usuario();

            do
            {
                string accion = DisplayMenu.Initial();

                if(accion.Equals("Iniciar Sesión"))
                {
                    try
                    {
                        //Login
                        usuario = DisplayInteractiveMenu.Login();
                        // Asynchronous
                        await AnsiConsole.Progress()
                            .StartAsync(async ctx =>
                            {
                                // Define tasks
                                var task1 = ctx.AddTask("[green]Iniciando sesión[/]");

                                while (!ctx.IsFinished)
                                {
                                    // Simulate some work
                                    await Task.Delay(100);

                                    // Increment
                                    task1.Increment(5);
                                }
                            });
                        AnsiConsole.MarkupLine($"Bienvenido [green bold]{usuario.NombreApellidos}[/]");
                        //metodo
                        DisplayInteractiveMenu.InitialMenu(usuario);
                    }
                    catch (IncorrectUserException e)
                    {
                        AnsiConsole.MarkupLine($"[bold red]{e.Message}[/]");
                        Console.WriteLine("\n");
                        Metodos.Olog.Add(e.Message);
                    }
                } else if(accion.Equals("Registrarse"))
                {
                    //Register
                    usuario = DisplayInteractiveMenu.Registrarse();
                    AnsiConsole.MarkupLine($"[green bold]¡Usuario {usuario.NombreApellidos} registrado![/]");
                    Metodos.users.Add(usuario);
                    DisplayInteractiveMenu.InitialMenu(usuario);
                    Metodos.WriteUser();
                } else
                {
                    break;
                }
            } while (true);
        }
    }
}