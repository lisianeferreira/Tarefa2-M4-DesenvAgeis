using AppCliente.Models;
using AppCliente.Negocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTestador
{
    public class UnitTestCenario3
    {
        private Usuario usuario;

        [SetUp]
        public void Setup()
        {
        }

        #region Metodos de teste que Falham
        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto USUARIO foi informado
        /// um tipo de usuário que não esta autorizado a acessar a tela de cadastro de institucionalizado
        /// </summary>
        [Test]
        public void UsuarioNaoAutorizadoFalha()
        {
            usuario = new Usuario()
            {
                Ativo = true,
                Id = 12345,
                TipoUsuario = 4, // tipo de usuario não autorizado
                Email = "joeBidden@gmail.com",
                UserName = "JoeBidden"
            };

            var usuarioAcao = new UsuarioAcao();
            var retornoEsperado = usuarioAcao.AcessarPaginaFichaCadastral(usuario);
            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion

        #region Metodos de teste de Sucesso

        /// <summary>
        /// Esse metodo de teste foi programado para ter SUCESSO, pois no objeto USUARIO foi informado
        /// um tipo de usuário autorizado a acessar a tela de cadastro de institucionalizado
        /// </summary>
        [Test]
        public void UsuarioNaoAutorizadoSucesso()
        {
            usuario = new Usuario()
            {
                Ativo = true,
                Id = 528593,
                TipoUsuario = 0,  //tipo de usuario autorizado
                Email = "angelaMerkel@gmail.com",
                UserName = "angelaMerkel"
            };

            var usuarioAcao = new UsuarioAcao();
            var retornoEsperado = usuarioAcao.AcessarPaginaFichaCadastral(usuario);
            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion
    }
}
