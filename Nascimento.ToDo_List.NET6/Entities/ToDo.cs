﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDo
    {
        public ToDo()
        {

        }
        public ToDo(int id, string nome, string descricao, string userId, DateTime registro, DateTime? atualizacao, bool foiFinalizado)
        {
            this.Id = id;
            this.Nome = nome;   
            this.Descricao = descricao; 
            this.UserId = userId;   
            this.DataAtualizacao = atualizacao;
            this.DataRegistro = registro;
            this.FoiFinalizado = foiFinalizado;  
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UserId { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool FoiFinalizado { get; set; }
    }
}
