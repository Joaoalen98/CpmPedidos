﻿namespace CpmPedidos.Domain
{
    public abstract class CategoriaProduto : BaseDomain, IExibivel
    {

        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}