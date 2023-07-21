using AutoMapper;
using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Domain.Entites;

namespace Excallibur.Domain.Mappings
{
    public class TesterMappingProfile : Profile
    {
        public TesterMappingProfile()
        {
            CreateMap<TesterRegisterRequestModel, Tester>();
        }
    }
}
