using AppCliente.Models;
using AppCliente.Negocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTestador
{
    public class UnitTestCenario5
    {
        private Tutor responsavel;

        [SetUp]
        public void Setup()
        {
            responsavel = new Tutor();
        }

        #region Metodos de teste que Falham

        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto TUTOR na propriedade
        /// Institucionalizado não foi informada.
        /// </summary>
        [Test]
        public void CamposObrigatoriosInvalidosCadastroTutorFalha()
        {
            responsavel.Id = 0;
            responsavel.Cpf = 72552527027;
            responsavel.CI = 884857278;
            responsavel.EstadoCivil = 3;
            responsavel.DataNascimento = Convert.ToDateTime("05/08/1948");
            responsavel.Nome = "Dilma Rusself";
                        
            var retornoEsperado = TutorAcao.Instance.SalvarItem(responsavel);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

        #region Metodos de teste de Sucesso

        /// <summary>
        /// Esse metodo de teste foi programado para SUCESSO, pois no objeto TUTOR na propriedade
        /// Institucionalizado foi informada.
        /// </summary>
        [Test]
        public void CamposObrigatoriosInvalidosCadastroTutorSucesso()
        {
            responsavel.Id = 0;
            responsavel.Cpf = 72552527027;
            responsavel.CI = 884857278;
            responsavel.EstadoCivil = 3;
            responsavel.DataNascimento = Convert.ToDateTime("05/08/1948");
            responsavel.Nome = "Dilma Rusself";
            responsavel.InstitucionalizadoId = 1;
                        
            var retornoEsperado = TutorAcao.Instance.SalvarItem(responsavel);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

    }
}
