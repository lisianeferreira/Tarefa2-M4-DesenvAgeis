using System;
using System.Collections.Generic;
using System.Text;

namespace AppCliente.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public int InstitucionalizadoId { get; set; }
        public double Cpf { get; set; }
        public double CI { get; set; }
        public int EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TelefoneContato { get; set; }
        public int Sexo { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
