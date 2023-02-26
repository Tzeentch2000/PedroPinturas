using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.API
{
    internal static class ApiURL
    {
        public const string USER = "https://localhost:7028/Usuario";
        public const string USERNAME = "https://localhost:7028/Usuario/Username/";
        public const string GETUSER = "https://localhost:7028/Usuario/";
        public const string LOGIN = "https://localhost:7028/Usuario/Login";
        public const string GETUSERPEDIDOS = "https://localhost:7028/Usuario/pedidos/";
        public const string COLOR = "https://localhost:7028/Color";
        public const string PASSWORD = "https://localhost:7028/Color";
        public const string CHECKPRODUCT = "https://localhost:7028/Producto/CheckProduct";
        public const string PEDIDO = "https://localhost:7028/Pedido";
    }
}
