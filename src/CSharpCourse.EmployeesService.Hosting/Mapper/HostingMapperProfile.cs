using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.Core.Models.DTOs;
using CSharpCourse.EmployeesService.Hosting.Models.Conferences;
using CSharpCourse.EmployeesService.Hosting.Models.Employees;

namespace CSharpCourse.EmployeesService.Hosting.Mapper
{
    public class HostingMapperProfile : Profile
    {
        public HostingMapperProfile()
        {
            CreateConference();
            GetConferences();

            CreateEmployee();
            GetEmployees();
            SendToConference();
        }

        private void CreateConference()
        {
            CreateMap<CreateConferenceInputModel, CreateConferenceCommand>(MemberList.Destination);
        }

        private void GetConferences()
        {
            CreateMap<ConferenceDto, ConferenceViewModel>(MemberList.Destination);
            CreateMap<ConferencesResponse, ConferencesViewModel>(MemberList.Destination);
        }

        private void CreateEmployee()
        {
            CreateMap<CreateEmployeeInputModel, CreateEmployeeCommand>(MemberList.Destination);
        }

        private void GetEmployees()
        {
            CreateMap<EmployeeDto, EmployeeViewModel>(MemberList.Destination);
            CreateMap<EmployeesResponse, EmployeesViewModel>(MemberList.Destination);
        }

        private void SendToConference()
        {
            CreateMap<SendToConferenceInputModel, SendEmployeeToConferenceCommand>(MemberList.Destination);
        }
    }
}
