﻿using CS.Domain.Enums;

namespace CS.Application.Response
{
    public class EnderecoResponse
    {
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public EnumeradorEstado Estado { get; set; }

        public string CEP { get; set; }
    }
}
