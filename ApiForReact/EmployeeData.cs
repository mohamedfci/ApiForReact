
using System.Collections.Generic;

namespace ApiForReact
{
 
    public static class EmployeeData
    {
        public static List<Employee> Employees { get; } = new List<Employee>(){
    new Employee { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Department = "HR" },
    new Employee { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Department = "IT" },
    new Employee { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Department = "Marketing" }
};
        public static void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public static List<Employee> GetEmployees()
        {
            return Employees;
        }

        public static Employee GetEmployee(int id)
        {
            return Employees.Find(emp => emp.Id == id);
        }

        public static void UpdateEmployee(int id, Employee updatedEmployee)
        {
            var index = Employees.FindIndex(emp => emp.Id == id);
            if (index != -1)
            {
                Employees[index] = updatedEmployee;
            }
        }

        public static void DeleteEmployee(int id)
        {
            Employees.RemoveAll(emp => emp.Id == id);
        }
    }

}
