﻿using CS.Domain.ValueObjects;

namespace CS.Domain.Entidades
{
    public abstract class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
