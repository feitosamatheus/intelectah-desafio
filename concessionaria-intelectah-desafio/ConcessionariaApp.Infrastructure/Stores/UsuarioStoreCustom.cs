using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaApp.Infrastructure.Autentications
{
    public class UsuarioStoreCustom : IUserStore<Usuario>, IUserPasswordStore<Usuario>, IUserRoleStore<Usuario>, IUserEmailStore<Usuario>
    {
        private readonly ContextApp _context;

        public UsuarioStoreCustom(ContextApp context)
        {
            _context = context;
        }

        public Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            _context.AddAsync(user, cancellationToken);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            _context.Remove(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            _context.Update(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public async Task<Usuario> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == int.Parse(userId));
        }

        public async Task<Usuario> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.NomeUsuario.Equals(normalizedUserName));

        }

        public async Task<string> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == user.Id);
            return resultado.NomeUsuario;

        }

        public async Task<string> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {
            var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == user.Id);
            return resultado.Senha;
        }

        public async Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(user.Email), cancellationToken);
            return resultado.Id.ToString();
        }

        public async Task<string> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(user.Email), cancellationToken);
            return resultado.NomeUsuario;
        }

        public async Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            var resultado = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email.Equals(user.Email) && u.Id == user.Id, cancellationToken);
            return resultado.Senha != null;
        }

        public Task SetNormalizedUserNameAsync(Usuario user, string normalizedName, CancellationToken cancellationToken)
        {
            //var novoUser = Usuario.Criar(normalizedName, user.Senha, user.Email.EnderecoEmail, user.NivelAcesso);
            //_context.Usuarios.Add(novoUser);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task SetPasswordHashAsync(Usuario user, string passwordHash, CancellationToken cancellationToken)
        {
            //var novoUser = new Usuario(user.NomeUsuario, passwordHash, user.Email, user.NivelAcesso);
            //_context.Usuarios.Add(novoUser);

            return Task.FromResult(IdentityResult.Success);

        }

        public Task SetUserNameAsync(Usuario user, string userName, CancellationToken cancellationToken)
        {
            //var novoUser = new Usuario(userName, user.Senha, user.Email, user.NivelAcesso);
            //_context.Usuarios.Add(novoUser);

            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task AddToRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Usuario>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(Usuario user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(Usuario user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Email.Equals(normalizedEmail));
        }

        public Task<string> GetNormalizedEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(Usuario user, string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
