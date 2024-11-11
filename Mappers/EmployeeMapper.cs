using task1.Dtos.EmployeeDtos;
using task1.Models;


namespace task1.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this Employee emp)
        {
            return new EmployeeDto
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                Email = emp.Email,
                DepartmentId = emp.DepartmentId,
                Salary = emp.Salary,
                MobileNo = emp.MobileNo,
                JoiningDate = emp.JoiningDate
            };
        }

        // here we do not need to find the entry, so we turn the dto into the entry.
        public static Employee ToEmployeeFromAddDto(this AddEmployeeDto empDto)
        {
            return new Employee
            {
                EmployeeName = empDto.EmployeeName,
                Email = empDto.Email,
                DepartmentId = empDto.DepartmentId,
                Salary = empDto.Salary,
                MobileNo = empDto.MobileNo
            };

        }

        //public static Employee ToEmployeeFromUpdateDto(this UpdateEmployeeDto empDto)
        
        //We dont need this because we do not add the UpdateEmployeeDto object to the EF, 
        //we find the entry using find by id, then we transfer the data into the entry.
        // WE NEED TO FIND THE ENTRY, SO WE CAN NOT TURN THIS INTO THE ENTRY.
    }
}
