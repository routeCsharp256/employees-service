using AutoMapper;
using CSharpCourse.Core.Lib.Enums;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Enums;
using CSharpCourse.EmployeesService.Domain.Models;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;

namespace CSharpCourse.EmployeesService.Hosting.Mapper
{
    public class HostingMapperProfile : Profile
    {
        public HostingMapperProfile()
        {
            CreateMap<PresentationModels.Enums.ClothingSize, ClothingSize>(MemberList.Destination)
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination);
            CreateMap<PresentationModels.Enums.EmployeeInConferenceType, EmployeeInConferenceType>(MemberList.Destination)
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination);

            CreateConference();
            GetConferences();

            CreateEmployee();
            SendToConference();
            GetByFilter();
        }

        private void CreateConference()
        {
            CreateMap<PresentationModels.Conferences.CreateConferenceInputModel, CreateConferenceCommand>(MemberList.Destination);
        }

        private void GetConferences()
        {
            CreateMap<ConferenceDto, PresentationModels.Conferences.ConferenceViewModel>(MemberList.Destination);
            CreateMap<ConferencesResponse, PresentationModels.Conferences.ConferencesViewModel>(MemberList.Destination);
        }

        private void CreateEmployee()
        {
            CreateMap<PresentationModels.Employees.CreateEmployeeInputModel, CreateEmployeeCommand>(MemberList.Destination);
        }

        private void SendToConference()
        {
            CreateMap<PresentationModels.Employees.SendToConferenceInputModel, SendEmployeeToConferenceCommand>(MemberList.Destination);
        }

        public void GetByFilter()
        {
            CreateMap<PresentationModels.Employees.EmployeesByFilterInputModel, GetEmployeesByFilterQuery>(MemberList
                .Destination);
            CreateMap<GetEmployeesByFilterQueryResponse, PresentationModels.Employees.EmployeesViewModel>(MemberList
                .Destination);

            CreateMap<EmployeeDto, PresentationModels.Employees.EmployeeViewModel>(MemberList.Destination);

            CreateMap<PresentationModels.PaginationFilter, PaginationFilter>(MemberList.Destination)
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination);
        }
    }
}
