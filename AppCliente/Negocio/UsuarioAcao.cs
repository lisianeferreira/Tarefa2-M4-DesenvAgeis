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
        private static volatile UsuarioAcao fObjeto;
        private static object syncRoot = new Object();

        public static UsuarioAcao Instance
        {
            get
            {
                if (fObjeto == null)
                {
                    lock (syncRoot)
                    {
                        if (fObjeto == null)
                        {
                            fObjeto = new UsuarioAcao();
                        }
                    }
                }
                return fObjeto;
            }
        }

        public ParametroRetorno VeririficarPermissaoUsuario(Usuario usuarioLogado)
        {
            var retorno = new ParametroRetorno();
            try
            {
                if (usuarioLogado.TipoUsuario == (int)TipoUsuario.Administrativo ||
                    usuarioLogado.TipoUsuario == (int)TipoUsuario.Medico ||
                    usuarioLogado.TipoUsuario == (int)TipoUsuario.Enfermeiro)
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
    }
}
