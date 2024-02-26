﻿using SQLite;

namespace ListaDeCompra.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Descricao {  get; set; }
        public double Quantidade { get; set; }
        public string Preco { get; set; }
    }
}