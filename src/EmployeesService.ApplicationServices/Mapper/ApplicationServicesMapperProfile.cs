using System.Collections;
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
            CreateEmployee();
            GetAllEmployees();
        }

        private void CreateConference()
        {
            CreateMap<CreateConferenceCommand, Conference>(MemberList.Destination)
                .ForMember(d => d.Id, o => o.MapFrom(s => 0));
        }

        private void CreateEmployee()
        {
            CreateMap<CreateEmployeeCommand, Employee>(MemberList.Destination)
                .ForMember(d => d.Id, o => o.MapFrom(s => 0));
        }

        private void GetAllEmployees()
        {
            CreateMap<Employee, EmployeeDto>(MemberList.Destination);
            CreateMap<IEnumerable<Employee>, EmployeesResponse>(MemberList.Destination);
        }
    }
}
