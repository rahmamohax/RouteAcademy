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
<<<<<<< HEAD
                .ForMember(d => d.CreatedOn, op => op.MapFrom(s => s.CreatedOn.ToString()))
                .ForMember(d => d.Department, op => op.MapFrom(s => s.Department != null ? s.Department.Name : null));
            //.ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.ToString()));
=======
                .ForMember(d => d.CreatedOn, op => op.MapFrom(s => s.CreatedOn.ToString()));
                //.ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.ToString()));
>>>>>>> parent of 6ec52a5 (Demo Session 07)

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(d => d.HiringDate, op => op.MapFrom(s => s.HiringDate.ToDateTime(new TimeOnly())));
                //.ForMember(d => d.ImgName, op => op.MapFrom(s => s.HiringDate.ToDateTime(new TimeOnly())));


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
