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
        private Institucionalizado idosoExistente;

        [SetUp]
        public void Setup()
        {
            idosoExistente = new Institucionalizado();
        }

        #region Metodos de teste que Falham

        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto INSTITUCIONALIZADO foi informado
        /// um número de CPF que já existe na base de dados
        /// </summary>
        [Test]
        public void InstitucionalizadoJaExisteNoSistemaFalha()
        {
            idosoExistente.Id = 0;
            idosoExistente.Cpf = 44096023060; // CPF já existente na lista
            idosoExistente.CI = 1254887;
            idosoExistente.EstadoCivil = 1;
            idosoExistente.DataNascimento = Convert.ToDateTime("05/08/1948");
            idosoExistente.Nome = "Barak Obama da Silva";            
            
            var retornoEsperado = InstitucionalizadoAcao.Instance.SalvarItem(idosoExistente);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(false));
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
            idosoExistente.Id = 0;
            idosoExistente.Cpf = 62243785099; 
            idosoExistente.CI = 248745587;
            idosoExistente.EstadoCivil = 2;
            idosoExistente.DataNascimento = Convert.ToDateTime("01/10/1950");
            idosoExistente.Nome = "Boris Jhonson de Oliveira";
                        
            var retornoEsperado = InstitucionalizadoAcao.Instance.SalvarItem(idosoExistente);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion
    }
}
