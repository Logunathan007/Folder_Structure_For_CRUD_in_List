using AutoMapper;
using SITS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS.Application.Models
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<Student, StudentCombained>().ReverseMap();
            CreateMap<StudentDetail, StudentCombained>().ReverseMap();
        }
    }
}
