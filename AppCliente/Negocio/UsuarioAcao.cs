using AppCliente.Models;
using AppCliente.Utils;
using AppCliente.Utils.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCliente.Negocio
{
    public class UsuarioAcao
    {
        public ParametroRetorno AcessarPaginaFichaCadastral(Usuario usuario)
        {
            var retorno = new ParametroRetorno();
            try
            {
                if (VerificarUsuarioAutorizado(usuario.TipoUsuario))
                {
                    retorno.Sucesso = true;
                }
                else
                {
                    retorno.Mensagem = "Usuário logado sem acesso autorizado!";
                }
            }
            catch (Exception e)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = e.Message;                
            }
            return retorno;
        }


        private bool VerificarUsuarioAutorizado(int tipoUsuario)
        {
            if (tipoUsuario == (int)TipoUsuario.Administrativo ||
                tipoUsuario == (int)TipoUsuario.Medico ||
                tipoUsuario == (int)TipoUsuario.Enfermeiro)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
