using PacoPinturas.Exceptions;
using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Functions
{
    internal static class DisplayMenu
    {

        //MENU PRINCIPAL DE LOGEO 
        public static string Initial()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("|BIENVENID@ A PACO EL PINTURAS|");
            initialMenu.AppendLine("1- INICIAR SESÍON");
            initialMenu.AppendLine("2- REGISTRARSE");

            return initialMenu.ToString();
        }
        //MENU OPCIONES DE LA APLICACION 
        public static string Menu()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUE DESEA REALIZAR?:");
            initialMenu.AppendLine("1- HACER PEDIDO DE MATERIAL");
            initialMenu.AppendLine("2- VER INVENTARIO PERSONAL");
            initialMenu.AppendLine("3- VER COLORES DISPONIBLES");
            initialMenu.AppendLine("4- CERRAR SESIÓN");

            return initialMenu.ToString();
        }
        //MENU PRODUCTOS PARA HACER PEDIDO 
        public static string Productos()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUE PRODUCTO DESA COMPRAR?:");
            initialMenu.AppendLine("1- SPRAY");
            initialMenu.AppendLine("2- CUBO");
            initialMenu.AppendLine("3- ROTULADOR");

            return initialMenu.ToString();
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
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUE TIPO DE SPARY QUIERE?:");
            initialMenu.AppendLine("1- ESTANDAR: SPRAY DE 300ML // 3.40€");
            initialMenu.AppendLine("2- PREMIUM: SPRAY DE 600ML // 6.50€");

            return initialMenu.ToString();
        }
        //MENU SELECCION CUBO 
        public static string Cubo()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUE TIPO DE CUBO QUIERE?:");
            initialMenu.AppendLine("1- ESTANDAR: CUBO DE 4L // 13.00€");
            initialMenu.AppendLine("2- PREMIUM: CUBO DE 10L // 23.00€");

            return initialMenu.ToString();
        }
        //MENU SELECCION ROTULADOR 
        public static string Rotulador()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUE TIPO DE ROTULADOR QUIERE?:");
            initialMenu.AppendLine("1- ESTANDAR: ROTULADOR CON PUNTA 3MM // 3.45€");
            initialMenu.AppendLine("2- PREMIUM: ROTULADOR CON PUNTA 7MM // 5.10€");

            return initialMenu.ToString();
        }
        //MENU SELECCION CANTIDAD
        public static string Cantidad()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("INTRODUZCA LA CANTIDAD QUE DESEE COMPRAR PARA EL PRODUCTO");
            return initialMenu.ToString();
        }
        //MENU SEGUIR AÑADIENDO PRODUCTOS AL PEDIDO
        public static string SeguirComprando()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿DESEA SEGUIR COMPRANDO?");
            initialMenu.AppendLine("1- SÍ");
            initialMenu.AppendLine("2- NO");
            return initialMenu.ToString();
        }
        //MENU ENTREGAR PEDIDO EN 24H
        public static string Entrega24H()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("¿QUIERE QUE SU PEDIDO SE ENTREGUE EN 24H?:");
            initialMenu.AppendLine("1- SÍ");
            initialMenu.AppendLine("2- NO");
            return initialMenu.ToString();
        }
        //MENU INSERTAR DIRECCION DE ENTREGA
        public static string Direccion()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("INTRODUZCA LA DIRECCION PARA LA ENTREGA DEL PEDIDO:");
            return initialMenu.ToString();
        }
    }
}