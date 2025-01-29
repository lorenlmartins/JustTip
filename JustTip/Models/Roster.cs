namespace JustTip.Models
{
    // Represents a roster (shift) for a specific date, containing a list of employees and their worked hours
    public class Roster
    {
        // Date of the roster (shift)
        public DateTime Date { get; private set; }

        // List of employees assigned to the roster
        public List<Employee> Employees { get; private set; }

        // Initializes a new roster for a given date
        public Roster(DateTime date)
        {
            Date = date;
            Employees = new List<Employee>();
        }

        // Adds an employee to the roster
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentException("Employee cannot be null.");
            Employees.Add(employee);
        }

        // Calculates the total hours worked by all employees in the roster
        public int TotalHoursWorked()
        {
            return Employees.Sum(e => e.HoursWorked);
        }
    }
}
