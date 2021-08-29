using AppCliente.Models;
using AppCliente.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCliente.Negocio
{
    public class InstitucionalizadoAcao
    {        

        public ParametroRetorno SalvarItem(Institucionalizado idoso)
        {
            var retorno = new ParametroRetorno();
            try
            {
                if (ValidarCamposObrigatorios(idoso).Sucesso)
                {
                    if (ValidarCampos(idoso).Sucesso)
                    {
                        if (RetornarItem(idoso.Cpf).Sucesso)
                        {
                            //aqui segue rotina de salvar na base
                            retorno.Mensagem = "Registro salvo com sucesso.";
                            retorno.Sucesso = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = e.Message;
            }
            return retorno;
        }


        private ParametroRetorno RetornarItem(double cpf)
        {
            var retorno = new ParametroRetorno() { Sucesso = true };
            double cpfExistente = 44096023060;

            if (cpf == cpfExistente)
            {
                retorno.Mensagem = "Institucionalizado já cadastrado.";
                retorno.Sucesso = false;
            }
            return retorno;
        }


        private ParametroRetorno ValidarCamposObrigatorios(Institucionalizado idoso)
        {
            var retorno = new ParametroRetorno() { Sucesso = true };

            if (string.IsNullOrEmpty(idoso.Cpf.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Cpf não preechido";
                return retorno;
            }

            if (string.IsNullOrEmpty(idoso.CI.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo CI não preechido";
                return retorno;
            }

            if (string.IsNullOrEmpty(idoso.Nome.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Nome não preechido";
                return retorno;
            }

            if (string.IsNullOrEmpty(idoso.DataNascimento.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Data Nascimento não preechido";
                return retorno;
            }

            return retorno;
        }

        private ParametroRetorno ValidarCampos(Institucionalizado idoso)
        {

            var retorno = new ParametroRetorno { Sucesso = true };
            if (idoso.Cpf < 0)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Cpf inválido";
            }

            if (idoso.CI < 0)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "CI inválida";
            }

            if (idoso.DataNascimento == DateTime.MinValue)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Data de Nascimento inválida";
            }

            return retorno;
        }
    }
}
