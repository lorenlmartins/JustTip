namespace JustTip.Models
{
    // Represents an employee in the business with hours worked and tips earned
    public class Employee
    {
        // Name of the employee
        public string Name { get; private set; }

        // Total hours worked by the employee
        public int HoursWorked { get; private set; }

        // Total tips earned by the employee
        public decimal TipsEarned { get; set; }

        // Initializes a new employee with a given name
        public Employee(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Employee name cannot be empty or whitespace.");

            Name = name;
            HoursWorked = 0;
            TipsEarned = 0;
        }

        // Adds the specified number of hours worked by the employee
        public void AddHours(int hours)
        {
            if (hours < 0)
                throw new ArgumentException("Hours cannot be negative.");

            HoursWorked += hours;
        }
    }
}
