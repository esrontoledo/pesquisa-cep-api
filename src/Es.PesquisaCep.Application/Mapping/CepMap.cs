using AutoMapper;
using Es.PesquisaCep.Application.Models;
using Es.PesquisaCep.Domain.Entities;

namespace Es.PesquisaCep.Application.Mapping
{
    public class CepMap : Profile
    {
        public CepMap()
        {
            CreateMap<CepModel, CepEntity>().ReverseMap();
        }
    }
}
