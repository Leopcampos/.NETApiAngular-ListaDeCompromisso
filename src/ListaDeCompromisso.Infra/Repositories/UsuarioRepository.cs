﻿using ListaDeCompromisso.Domain.Entities;
using ListaDeCompromisso.Infra.Contexts;
using ListaDeCompromisso.Infra.Interfaces;

namespace ListaDeCompromisso.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlServerContext _context;

        public UsuarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Usuario Get(string email)
        {
            return _context.Usuario
                .Where(u => u.Email.Equals(email))
                .FirstOrDefault();
        }

        public Usuario Get(string email, string senha)
        {
            return _context.Usuario
                .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                .FirstOrDefault();
        }
    }
}