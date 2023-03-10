using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.API
{
    internal static class ApiURL
    {
        const string GENERAL = "https://apipedropinturas.azurewebsites.net/";
        public const string USER = GENERAL+"/Usuario";
        public const string USERNAME = GENERAL + "/Usuario/Username/";
        public const string GETUSER = GENERAL + "/Usuario/";
        public const string LOGIN = GENERAL + "/Usuario/Login";
        //public const string GETUSERPEDIDOS = "/Usuario/pedidos/";
        public const string GETUSERPEDIDOS = GENERAL + "/Pedido/user/";
        public const string COLOR = GENERAL + "/Color";
        public const string PASSWORD = GENERAL + "/Color";
        public const string CHECKPRODUCT = GENERAL + "/Producto/CheckProduct";
        public const string PEDIDO = GENERAL + "/Pedido";
        public const string PEDIDOFILTROFECHA = GENERAL + "/Pedido/date/";

    }
}
