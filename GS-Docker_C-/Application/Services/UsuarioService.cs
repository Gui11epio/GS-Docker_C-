using AutoMapper;
using GeoAlertaC.Application.DTOs.Request;
using GeoAlertaC.Application.DTOs.Response;
using GeoAlertaC.Domain.Entities;
using GeoAlertaC.Infrastructure.Context;

namespace GeoAlertaC.Application.Services
{
    public class UsuarioService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UsuarioResponse> ObterTodos()
        {
            var usuarios = _context.Usuarios.ToList();
            return _mapper.Map<List<UsuarioResponse>>(usuarios);
        }

        public UsuarioResponse? ObterPorId(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return usuario == null ? null : _mapper.Map<UsuarioResponse>(usuario);
        }

        public UsuarioResponse? ObterPorEmail(string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            return usuario == null ? null : _mapper.Map<UsuarioResponse>(usuario);
        }

        public UsuarioResponse Criar(UsuarioRequest request)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Email == request.Email);
            if (usuarioExistente != null)
            {
                return null; // Email já cadastrado
            }
            

            var usuario = _mapper.Map<Usuario>(request);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public bool Atualizar(int id, UsuarioRequest request)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _mapper.Map(request, usuario);
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
    }
}
