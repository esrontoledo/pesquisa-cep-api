using AutoMapper;
using Es.PesquisaCep.Application.Models;
using Es.PesquisaCep.Domain.DbModel;

namespace Es.PesquisaCep.Application.Mapping
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<UserDbModel, UserModel>().ReverseMap();
        }
    }
}
