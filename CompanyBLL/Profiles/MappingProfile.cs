using AutoMapper;
using CompanyProjectBLL.DTOs.EmployeeDtos;
using CompanyProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            EmployeeMaping();
        }
        private void EmployeeMaping()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(d => d.Gender, op => op.MapFrom(s => s.Gender.ToString()))
                .ForMember(d => d.EmployeeType, op => op.MapFrom(s => s.EmployeeType.ToString()))
                .ForMember(d => d.LastModifiedOn, op => op.MapFrom(s => s.LastModifiedOn.ToString()))
                .ForMember(d => d.CreatedOn, op => op.MapFrom(s => s.CreatedOn.ToString()));
                //.ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.ToString()));

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.ToDateTime(new TimeOnly())));

            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.ToDateTime(new TimeOnly())));

            CreateMap<EmployeeDto, UpdateEmployeeDto>()
                .ForMember(d => d.Gender, op => op.MapFrom(s => Enum.Parse<Gender>(s.Gender)))
                .ForMember(d => d.EmployeeType, op => op.MapFrom(s => Enum.Parse<EmployeeType>(s.EmployeeType)))
                .ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.HasValue
                                                                ? DateOnly.FromDateTime(s.HiringDate.Value)
                                                                : (DateOnly?)null));

        }

    }


}
