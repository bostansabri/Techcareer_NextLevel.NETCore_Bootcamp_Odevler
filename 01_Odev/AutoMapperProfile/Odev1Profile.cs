using AutoMapper;
using Odev1.Entities;
using Odev1.Models.DTO_s;

namespace Odev1.AutoMapperProfile
{
    public class Odev1Profile : Profile
    {
        public Odev1Profile()
        {
            CreateMap<EmployeeCreateDTO, Employee>();
        }
    }
}
