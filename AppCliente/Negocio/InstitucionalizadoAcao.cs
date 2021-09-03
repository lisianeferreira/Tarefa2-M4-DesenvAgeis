using AppCliente.Models;
using AppCliente.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCliente.Negocio
{
    public class InstitucionalizadoAcao
    {
        private List<Institucionalizado> listaBD = new List<Institucionalizado>();
        private static volatile InstitucionalizadoAcao fObjeto;
        private static object syncRoot = new Object();

        public static InstitucionalizadoAcao Instance
        {
            get
            {
                if (fObjeto == null)
                {
                    lock (syncRoot)
                    {
                        if (fObjeto == null)
                        {
                            fObjeto = new InstitucionalizadoAcao();
                        }
                    }
                }

                return fObjeto;
            }
        }

        public InstitucionalizadoAcao()
        {
            this.listaBD.Add(new Institucionalizado
            {
                Id = 15454884,
                Cpf = 44096023060,
                CI = 1254887,
                EstadoCivil = 1,
                DataNascimento = Convert.ToDateTime("05/08/1948"),
                Nome = "Barak Obama da Silva",
            });
        }

        public ParametroRetorno SalvarItem(Institucionalizado idoso)
        {
            var retorno = new ParametroRetorno();
            try
            {
                if (VerificarCamposObrigatorios(idoso).Sucesso)
                {
                    if (ValidarCampos(idoso).Sucesso)
                    {
                        if (RetornarItem(idoso.Cpf).Sucesso)
                        {
                            //add na lista
                            listaBD.Add(idoso);
                            
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

        public ParametroRetorno RetornarItem(double cpf)
        {
            var retorno = new ParametroRetorno() { Sucesso = true };
            var idoso = listaBD.Where(p => p.Cpf == cpf).FirstOrDefault();
            if (idoso != null)
            {
                retorno.Mensagem = "Institucionalizado já cadastrado.";
                retorno.Sucesso = false;
            }
            return retorno;
        }

        private ParametroRetorno VerificarCamposObrigatorios(Institucionalizado idoso)
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
