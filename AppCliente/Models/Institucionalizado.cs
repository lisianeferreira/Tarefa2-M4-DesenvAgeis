using System;
using System.Collections.Generic;
using System.Text;

namespace AppCliente.Models
{
    public class Institucionalizado
    {
        public int Id { get; set; }
        public double Cpf { get; set; }
        public double CI { get; set; }
        public int EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool PossuiFilhos { get; set; }
        public bool PossuiDoencas { get; set; }
        public bool PossuiBens { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
