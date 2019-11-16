using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Domain.ValueObjects.Localization
{
    public class CPFValueObject
        : GovernamentalNumberValueObject
    {
        public override bool IsValid()
        {
            var cpf = DocumentNumber;
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim().GetOnlyNumericDigits();

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
