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
        private Usuario usuarioLogado;

        [SetUp]
        public void Setup()
        {
            usuarioLogado = new Usuario();
        }

        #region Metodos de teste que Falham
        /// <summary>
        /// Esse metodo de teste foi programado para FALHAR, pois no objeto USUARIO foi informado
        /// um tipo de usuário que não esta autorizado a acessar a tela de cadastro de institucionalizado
        /// </summary>
        [Test]
        public void UsuarioNaoAutorizadoFalha()
        {
            usuarioLogado.Ativo = true;
            usuarioLogado.Id = 12345;
            usuarioLogado.TipoUsuario = 4; // tipo de usuario não autorizado
            usuarioLogado.Email = "joeBidden@gmail.com";
            usuarioLogado.UserName = "JoeBidden";
                        
            var retornoEsperado = UsuarioAcao.Instance.VeririficarPermissaoUsuario(usuarioLogado);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(false));
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
            usuarioLogado.Ativo = true;
            usuarioLogado.Id = 528593;
            usuarioLogado.TipoUsuario = 0;
            usuarioLogado.Email = "angelaMerkel@gmail.com";
            usuarioLogado.UserName = "angelaMerkel";
                        
            var retornoEsperado = UsuarioAcao.Instance.VeririficarPermissaoUsuario(usuarioLogado);

            Assert.That(retornoEsperado.Sucesso, Is.EqualTo(true));
            Assert.Pass();
        }

        #endregion
    }
}
