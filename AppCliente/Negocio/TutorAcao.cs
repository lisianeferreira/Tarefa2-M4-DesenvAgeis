using AppCliente.Models;
using AppCliente.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCliente.Negocio
{
    public class TutorAcao
    {
  
        public ParametroRetorno SalvarItem(Tutor responsavel)
        {
            var retorno = new ParametroRetorno();
            try
            {
                if (ValidarCamposObrigatorios(responsavel).Sucesso)
                {
                    if (ValidarCampos(responsavel).Sucesso)
                    {
                        if (RetornarItem(responsavel.Cpf).Sucesso)
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
                retorno.Mensagem = "Tutor já cadastrado.";
                retorno.Sucesso = false;
            }
            return retorno;
        }


        private ParametroRetorno ValidarCamposObrigatorios(Tutor responsavel)
        {
            var retorno = new ParametroRetorno() { Sucesso = true };

            if (string.IsNullOrEmpty(responsavel.Cpf.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Cpf não preechido";
                return retorno;
            }

            if (string.IsNullOrEmpty(responsavel.CI.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo CI não preechido";
                return retorno;
            }

            if (string.IsNullOrEmpty(responsavel.Nome.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Nome não preechido";
                return retorno;
            }

            if (string.IsNullOrEmpty(responsavel.DataNascimento.ToString()))
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Data Nascimento não preechido";
                return retorno;
            }

            if (responsavel.InstitucionalizadoId < 1)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Campo Institucionalizado não preechido";
                return retorno;
            }

            return retorno;
        }

        private ParametroRetorno ValidarCampos(Tutor responsavel)
        {

            var retorno = new ParametroRetorno { Sucesso = true };
            if (responsavel.Cpf < 0)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Cpf inválido";
            }

            if (responsavel.CI < 0)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "CI inválida";
            }

            if (responsavel.DataNascimento == DateTime.MinValue)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = "Data de Nascimento inválida";
            }

            return retorno;
        }

    }
}
