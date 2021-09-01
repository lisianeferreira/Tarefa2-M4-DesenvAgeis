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
            idoso = new Institucionalizado();
        }

        #region Metodos de teste que Falham

        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto INSTITUCIONALIZADO na propriedade
        /// DATANASCIMENTO foi informado uma data inválida
        /// </summary>
        [Test]
        public void CamposObrigatoriosInvalidosCadastroInstitucionalizadoFalha()
        {
            idoso.Id = 0;
            idoso.Cpf = 72552527027;
            idoso.CI = 884857278;
            idoso.EstadoCivil = 3;
            idoso.DataNascimento = Convert.ToDateTime("01/01/0001"); // data inválida
            idoso.Nome = "Dilma Rusself";

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
            idoso.Id = 0;
            idoso.Cpf = 72552527027;
            idoso.CI = 884857278;
            idoso.EstadoCivil = 3;
            idoso.DataNascimento = Convert.ToDateTime("01/01/1946"); // data válida
            idoso.Nome = "Dilma Rusself";

            var institucionalizadoAcao = new InstitucionalizadoAcao();
            var retornoEsperado = institucionalizadoAcao.SalvarItem(idoso);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

    }
}
