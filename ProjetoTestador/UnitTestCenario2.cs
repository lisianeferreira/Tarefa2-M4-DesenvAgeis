using AppCliente.Models;
using AppCliente.Negocio;
using AppCliente.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTestador
{
    public class UnitTestCenario2
    {
        private Tutor responsavel;

        [SetUp]
        public void Setup()
        {

        }

        #region Metodos de teste que Falham

        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto Tutor(a) foi informado
        /// um número de CPF que já existe na base de dados
        /// </summary>
        [Test]
        public void TutorJaExisteNoSistemaFalha()
        {
            responsavel = new Tutor
            {
                Id = 0,
                Cpf = 44096023060, // CPF já existente na base de dados
                CI = 1254887,
                EstadoCivil = 1,
                DataNascimento = Convert.ToDateTime("05/08/1975"),
                Nome = "Joe Biden da Silva",
                InstitucionalizadoId = 1,
            };

            var tutorAcao = new TutorAcao();
            var retornoEsperado = tutorAcao.SalvarItem(responsavel);
            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

        #region Metodos de teste de Sucesso

        /// <summary>
        /// Esse metodo de teste foi programado para teste SUCESSO, pois no objeto TUTOR foi informado
        /// um número de CPF que ainda não existe na base de dados
        /// </summary>
        [Test]
        public void TutorJaExisteNoSistemaSucesso()
        {
            responsavel = new Tutor
            {
                Id = 0,
                Cpf = 62243785099, // CPF não existente  na base de dados
                CI = 248745587,
                EstadoCivil = 2,
                DataNascimento = Convert.ToDateTime("01/10/1950"),
                Nome = "Donald Trump de Oliveira",
                InstitucionalizadoId = 1,
            };

            var tutorAcao = new TutorAcao();
            var retornoEsperado = tutorAcao.SalvarItem(responsavel);
            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion
    }
}
