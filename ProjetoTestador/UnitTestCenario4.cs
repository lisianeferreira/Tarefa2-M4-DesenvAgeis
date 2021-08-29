using AppCliente.Models;
using AppCliente.Negocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTestador
{
    public class UnitTestCenario4
    {
        private Institucionalizado idoso;

        [SetUp]
        public void Setup()
        {

        }

        #region Metodos de teste que Falham

        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto INSTITUCIONALIZADO na propriedade
        /// DATANASCIMENTO foi informado uma data inválida
        /// </summary>
        [Test]
        public void CamposObrigatoriosInvalidosCadastroInstitucionalizadoFalha()
        {
            idoso = new Institucionalizado
            {
                Id = 0,
                Cpf = 72552527027,
                CI = 884857278,
                EstadoCivil = 3,
                DataNascimento = Convert.ToDateTime("01/01/0001"), // data inválida
                Nome = "Dilma Rusself",
            };

            var institucionalizadoAcao = new InstitucionalizadoAcao();
            var retornoEsperado = institucionalizadoAcao.SalvarItem(idoso);
            
            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

        #region Metodos de teste de Sucesso

        /// <summary>
        /// Esse metodo de teste foi programado para SUCESSO, pois no objeto INSTITUCIONALIZADO na propriedade
        /// DATANASCIMENTO foi informado uma data válida
        /// </summary>
        [Test]
        public void CamposObrigatoriosInvalidosCadastroInstitucionalizadoSucesso()
        {
            idoso = new Institucionalizado
            {
                Id = 0,
                Cpf = 72552527027,
                CI = 884857278,
                EstadoCivil = 3,
                DataNascimento = Convert.ToDateTime("01/01/1946"), // data válida
                Nome = "Dilma Rusself",
            };

            var institucionalizadoAcao = new InstitucionalizadoAcao();
            var retornoEsperado = institucionalizadoAcao.SalvarItem(idoso);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

    }
}
