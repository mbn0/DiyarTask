using task1.Dtos.DepartmentDtos;
using task1.Models;


namespace task1.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentDto ToDepartmentDto(this Department dep)
        {
            return new DepartmentDto
            {
                DepartmentId = dep.DepartmentId,
                DepartmentName = dep.DepartmentName,
                Employees = dep.Employees.Select(e => e.ToEmployeeDto()).ToList()
            };

        }

        public static Department ToDepartmentFromAddDto(this AddDepartmentDto dep)
        {
            return new Department
            {
                DepartmentName = dep.DepartmentName,
            };
        }

    }
}

