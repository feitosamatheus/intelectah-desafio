using ConcessionariaApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Services
{
    public class HashingService : IHashingService
    {
        private const int SaltTamanho = 128 / 8;
        private const int KeyTamanho = 256 / 8;
        private const int Interacoes = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char Delemitador = ';';

        public string GerarHash(string valor)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltTamanho);
            var hash = Rfc2898DeriveBytes.Pbkdf2(valor, salt, Interacoes, _hashAlgorithmName, KeyTamanho);

            return string.Join(Delemitador, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool ValidarHash(string valorRepassado, string HashAtual)
        {
            var elemento = HashAtual.Split(Delemitador);
            var salt = Convert.FromBase64String(elemento[0]);
            var hash = Convert.FromBase64String(elemento[1]);

            var valorHash = Rfc2898DeriveBytes.Pbkdf2(valorRepassado, salt, Interacoes, _hashAlgorithmName, KeyTamanho);

            return CryptographicOperations.FixedTimeEquals(hash, valorHash);
        }
    }
}
