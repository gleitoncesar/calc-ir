using System;
using CalcIR.Domain;

namespace CalcIR.Service.Validacao
{
    internal class Mensagem
    {
        internal const string ResulatdoAcumuladoDeveSerMaiorQue2015 = "A data do resultado deve ser maior que 01/01/2015";
        internal const string UsuarioDeveSerInformado = "Usuário não informado";
        internal const string ResulatdoAcumuladoPosteriorJaExiste = "Já existe um resultado posterior";
    }
}