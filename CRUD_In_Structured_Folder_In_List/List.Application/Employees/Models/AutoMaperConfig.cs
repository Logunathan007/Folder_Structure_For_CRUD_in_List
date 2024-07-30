using AutoMapper;
using List.Domain.Entities;

namespace List.Application.Employees.Models
{ 
    public class AutoMaperConfig : Profile
    {
        public AutoMaperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
