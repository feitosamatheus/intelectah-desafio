﻿using ConcessionariaApp.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace ConcessionariaApp.Domain.ValueObjects
{
    public class CPF
    {
        public string Numero { get; }

        private CPF(string numero)
        {
            if (!ValidarCpf(numero))
                throw new CpfInvalidoException();
            
            Numero = RemoverMascara(numero);
        }

        public static CPF Criar(string numero)
        {
            return new CPF(numero);
        }

        public override bool Equals(object obj)
        {
            if (obj is not CPF cpf)
                return false;

            return Numero == cpf.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numero);
        }

        public bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], 11) == cpf)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

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

        public static string RemoverMascara(string cpf)
        {
            var cpfSemMascara = Regex.Replace(cpf, @"\D", "");

            return cpfSemMascara;
        }
    }
}
