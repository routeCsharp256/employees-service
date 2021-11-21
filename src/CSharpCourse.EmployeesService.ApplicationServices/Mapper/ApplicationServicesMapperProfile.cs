using System.Collections.Generic;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.Domain.Models;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using CSharpCourse.EmployeesService.Domain.Models.Entities;

namespace CSharpCourse.EmployeesService.ApplicationServices.Mapper
{
    public class ApplicationServicesMapperProfile : Profile
    {
        public ApplicationServicesMapperProfile()
        {
            CreateConference();
            GetAllConferences();

            CreateEmployee();
            GetEmployeesByFilter();
        }

        private void CreateConference()
        {
            CreateMap<CreateConferenceCommand, Conference>(MemberList.Destination)
                .ForMember(d => d.Id, o => o.MapFrom(s => 0));
        }

        private void GetAllConferences()
        {
            CreateMap<Conference, ConferenceDto>(MemberList.Destination);
            CreateMap<IEnumerable<Conference>, ConferencesResponse>(MemberList.Destination)
                .ForMember(d => d.Items, o => o.MapFrom(s => s));
        }

        private void CreateEmployee()
        {
            CreateMap<CreateEmployeeCommand, Employee>(MemberList.Destination)
                .ForMember(d => d.Id, o => o.MapFrom(s => 0));
        }

        private void GetEmployeesByFilter()
        {
            CreateMap<GetEmployeesByFilterQuery, EmployeesFilterDto>(MemberList.Destination);
            CreateMap<FilteredEmployeesWithTotalCountDto, GetEmployeesByFilterQueryResponse>(MemberList.Destination);

            CreateMap<Employee, EmployeeDto>(MemberList.Destination)
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination);

            CreateMap<PaginationFilter, PaginationFilter>(MemberList.Destination);

            CreateMap<IEnumerable<Employee>, GetEmployeesByFilterQueryResponse>(MemberList.Destination)
                .ForMember(d => d.Items, o => o.MapFrom(s => s));
        }
    }
}
