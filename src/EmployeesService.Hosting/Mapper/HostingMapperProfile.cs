using AutoMapper;
using EmployeesService.ApplicationServices.Models.Queries;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.Core.Models.DTOs;
using EmployeesService.Hosting.Models.Employees;

namespace EmployeesService.Hosting.Mapper
{
    public class HostingMapperProfile : Profile
    {
        public HostingMapperProfile()
        {
            CreateEmployee();
            GetEmployees();
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
    }
}
