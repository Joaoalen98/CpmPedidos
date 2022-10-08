﻿using System;

namespace CpmPedidos.Domain
{
    public abstract class Pedido : BaseDomain
    {
        public string Numero { get; set; }
        public decimal ValorTotal { get; set; }
        public TimeSpan Entrega { get; set; }
        public int IdCIiente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}