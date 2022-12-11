using PedroPinturas.Exceptions;
using PedroPinturas.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Functions
{
    internal static class DisplayMenu
    {
        private static Style highlightStyle = new Style().Foreground(Spectre.Console.Color.White);
        //MENU PRINCIPAL DE LOGEO 
        public static string Initial()
        {
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold underline fuchsia]BIENVENIDO A PACO PINTURAS[/]")
                    .AddChoices(new[] {
                        "Iniciar Sesión", "Registrarse", "Salir",}));

            return accion;
        }
        //MENU OPCIONES DE LA APLICACION 
        public static string Menu()
        {
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices(new[] {
                        "Hacer pedido", "Historial de pedidos", 
                        "Filtrar pedidos por fecha","Colores disponibles","Cerrar sesión"}));

            return accion;
        }
        //MENU PRODUCTOS PARA HACER PEDIDO 
        public static string Productos()
        {
            AnsiConsole.MarkupLine("[fuchsia]Elija un producto[/]");
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .HighlightStyle(highlightStyle)
                    .AddChoices(new[] {
                        "Spray", "Cubo", "Rotulador",}));

            return accion;
        }
        //MENU COLOR PARA PRODUCTO 
        public static string Color()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUE COLOR QUIERE PARA SU PRODUCTO?:");
            return initialMenu.ToString();
        }
        //MENU SELECCION SPRAY 
        public static string Spray()
        {
            AnsiConsole.MarkupLine("Tipo de [fuchsia]spray[/]");
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .HighlightStyle(highlightStyle)
                    .AddChoices(new[] {
                       "Estandar: spray de 300ML // 3.40$", "Premium: spray de 600ML // 6.50$",}));

            return accion;
        }
        //MENU SELECCION CUBO 
        public static string Cubo()
        {
            AnsiConsole.MarkupLine("Tipo de [fuchsia]cubo[/]");
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .HighlightStyle(highlightStyle)
                   .AddChoices(new[] {
                       "Estandar: cubo de 4L // 13.00$", "Premium: cubo de 10L // 23.00$",}));

            return accion;
        }
        //MENU SELECCION ROTULADOR 
        public static string Rotulador()
        {
            AnsiConsole.MarkupLine("Tipo de [fuchsia]rotulador[/]");
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .HighlightStyle(highlightStyle)
                   .AddChoices(new[] {
                       "Estandar: rotulador con punta de 3MM // 3.45$", "Premium: rotulador con punta de 7MM // 5.10$",}));

            return accion;
        }
        //MENU SELECCION CANTIDAD
        public static string Cantidad()
        {
           return "[fuchsia]Cantidad[/]";
        }
        //MENU SEGUIR AÑADIENDO PRODUCTOS AL PEDIDO
        public static string SeguirComprando()
        {
            var accion = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .Title("[fuchsia]¿Seguir comprando?[/]")
                  .AddChoices(new[] {
                       "Si", "No",}));

            return accion;
        }
        //MENU ENTREGAR PEDIDO EN 24H
        public static string Entrega24H()
        {
            AnsiConsole.MarkupLine("[fuchsia]Entrega en 24 horas[/]");
            // Seleccion de categorias
            var accion = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .AddChoices(new[] {
                       "Si", "No",}));

            return accion;
        }
        //MENU INSERTAR DIRECCION DE ENTREGA
        public static string Direccion()
        {
            return "[fuchsia]Direccion[/]";
        }
    }
}