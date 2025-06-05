using AutoMapper;
using GeoAlertaC.Application.DTOs.Request;
using GeoAlertaC.Application.DTOs.Response;
using GeoAlertaC.Domain.Entities;
using GeoAlertaC.Infrastructure.Context;

namespace GeoAlertaC.Application.Services
{
    public class EnderecoService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<EnderecoResponse> ObterTodos()
        {
            var enderecos = _context.Enderecos.ToList();
            return _mapper.Map<List<EnderecoResponse>>(enderecos);
        }

        public EnderecoResponse? ObterPorId(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            return endereco == null ? null : _mapper.Map<EnderecoResponse>(endereco);
        }

        public EnderecoResponse Criar(EnderecoRequest request)
        {
            var endereco = _mapper.Map<Endereco>(request);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<EnderecoResponse>(endereco);
        }

        public bool Atualizar(int id, EnderecoRequest request)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return false;

            _mapper.Map(request, endereco);
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return false;

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return true;
        }
    }
}
