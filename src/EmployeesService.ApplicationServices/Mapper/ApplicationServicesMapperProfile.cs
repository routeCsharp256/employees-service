using System.Collections.Generic;
using AutoMapper;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.ApplicationServices.Models.Queries;
using EmployeesService.Core.Models.DTOs;
using EmployeesService.Core.Models.Entities;

namespace EmployeesService.ApplicationServices.Mapper
{
    public class ApplicationServicesMapperProfile : Profile
    {
        public ApplicationServicesMapperProfile()
        {
            CreateConference();
            GetAllConferences();

            CreateEmployee();
            GetAllEmployees();
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

        private void GetAllEmployees()
        {
            CreateMap<Employee, EmployeeDto>(MemberList.Destination);
            CreateMap<IEnumerable<Employee>, EmployeesResponse>(MemberList.Destination)
                .ForMember(d => d.Items, o => o.MapFrom(s => s));
        }
    }
}