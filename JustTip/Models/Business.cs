namespace JustTip.Models
{
    // Represents a business that manages employees, shifts, and tips distribution
    public class Business
    {
        // Name of the business
        public string Name { get; private set; }

        // List of employees working at the business
        public List<Employee> Employees { get; private set; }

        // List of rosters (shifts) for the business
        public List<Roster> Rosters { get; private set; }

        // Initializes a new instance of a business with a given name
        public Business(string name)
        {
            Name = name;
            Employees = new List<Employee>();
            Rosters = new List<Roster>();
        }

        // Creates and adds a new employee to the business
        public Employee CreateEmployee(string name)
        {
            var employee = new Employee(name);
            Employees.Add(employee);
            return employee;
        }

        // Creates and adds a new roster (shift) for a specific date
        public Roster CreateRoster(DateTime date)
        {
            var roster = new Roster(date);
            Rosters.Add(roster);
            return roster;
        }

        // Distributes tips proportionally based on hours worked across all rosters
        public void DistributeTips(decimal totalTips)
        {
            if (totalTips < 0)
                throw new ArgumentException("Total tips cannot be negative.");

            foreach (var roster in Rosters)
            {
                var totalHours = roster.TotalHoursWorked();
                if (totalHours == 0) continue;

                // Distributes tips based on hours worked by each employee in the roster
                foreach (var employee in roster.Employees)
                {
                    employee.TipsEarned += totalTips * employee.HoursWorked / totalHours;
                }
            }
        }
    }
}
