using AppCliente.Models;
using AppCliente.Negocio;
using AppCliente.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTestador
{
    public class UnitTestCenario1
    {
        private Institucionalizado idoso;

        [SetUp]
        public void Setup()
        {
            idoso = new Institucionalizado();
        }

        #region Metodos de teste que Falham

        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto INSTITUCIONALIZADO foi informado
        /// um número de CPF que já existe na base de dados
        /// </summary>
        [Test]
        public void InstitucionalizadoJaExisteNoSistemaFalha()
        {
            idoso.Id = 0;
            idoso.Cpf = 44096023060; // CPF já existente na base de dados
            idoso.CI = 1254887;
            idoso.EstadoCivil = 1;
            idoso.DataNascimento = Convert.ToDateTime("05/08/1948");
            idoso.Nome = "Barak Obama da Silva";

            var institucionalizadoAcao = new InstitucionalizadoAcao();
            var retornoEsperado = institucionalizadoAcao.SalvarItem(idoso);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

        #region Metodos de teste de Sucesso

        /// <summary>
        /// Esse metodo de teste foi programado para teste SUCESSO, pois no objeto INSTITUCIONALIZADO foi informado
        /// um número de CPF que ainda não existe na base de dados
        /// </summary>
        [Test]
        public void InstitucionalizadoJaExisteNoSistemaSucesso()
        {
            idoso.Id = 0;
            idoso.Cpf = 62243785099; // CPF não existente  na base de dados
            idoso.CI = 248745587;
            idoso.EstadoCivil = 2;
            idoso.DataNascimento = Convert.ToDateTime("01/10/1950");
            idoso.Nome = "Boris Jhonson de Oliveira";

            var institucionalizadoAcao = new InstitucionalizadoAcao();
            var retornoEsperado = institucionalizadoAcao.SalvarItem(idoso);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion
    }
}
