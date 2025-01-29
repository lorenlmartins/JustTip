using JustTip.Models;
using System;

namespace JustTip.Factories
{
    public static class EmployeeFactory
    {
        // Creates a new employee, ensuring the name is not empty or whitespace
        public static Employee CreateEmployee(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Employee name cannot be empty or whitespace.");

            return new Employee(name);
        }
    }
}
