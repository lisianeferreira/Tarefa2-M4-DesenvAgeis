using System;
using System.Collections.Generic;
using System.Text;

namespace AppCliente.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int TipoUsuario { get; set; }

        public string UserName { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime DataAlteracao { get; set; }

    }
}
