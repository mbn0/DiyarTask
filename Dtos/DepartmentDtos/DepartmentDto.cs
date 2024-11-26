using task1.Dtos.EmployeeDtos;
namespace task1.Dtos.DepartmentDtos;

public class DepartmentDto
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public List<EmployeeDto?> Employees { get; set; }
}

