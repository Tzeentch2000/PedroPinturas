using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Models.DTO
{
    internal class PedidoDTO : Pedido
    {
        public int IdUsuario { get; set; }
        public PedidoDTO() : base()
        { 
            
        }
    }
}
