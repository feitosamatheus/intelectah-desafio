using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextApp _context;

        public UnitOfWork(ContextApp context)
        {
            _context = context;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                var error = FormatandoMenssagemRegistroDuplicado(sqlEx);
                throw new Exception(error);
            }
        }
        private string FormatandoMenssagemRegistroDuplicado(SqlException sqlEx)
        {
            var mensagem = sqlEx.Message;
            var padraoChave = "O valor de chave duplicada é \\(([^)]+)\\)";
            var correspondencia = System.Text.RegularExpressions.Regex.Match(mensagem, padraoChave);
            if (correspondencia.Success)
            {
                var valorDuplicado = correspondencia.Groups[1].Value;
                return $"O valor '{valorDuplicado}' já existe no banco de dados.";
            }

            return "Ocorreu um erro ao tentar salvar o registro. O valor já pode existir.";
        }
    }
}
