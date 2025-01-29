using JustTip.Factories;
using JustTip.Models;
using JustTip.Strategies;

namespace JustTip.Controllers
{
    public class BusinessController
    {
        private readonly Business _business;
        private ITipDistributionStrategy _tipDistributionStrategy;

        // Constructor that initializes the business with a name and sets the default tip distribution strategy
        public BusinessController(string businessName)
        {
            if (string.IsNullOrWhiteSpace(businessName))
                throw new ArgumentException("Business name cannot be empty or whitespace.");

            _business = new Business(businessName);
            _tipDistributionStrategy = new ProportionalTipDistributionStrategy();
        }

        // Method to change the tip distribution strategy
        public void SetTipDistributionStrategy(ITipDistributionStrategy strategy)
        {
            _tipDistributionStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        // Adds a new employee to the business if the name doesn't already exist
        public void AddEmployee(string name)
        {
            var employee = EmployeeFactory.CreateEmployee(name);

            if (_business.Employees.Any(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"An employee with the name '{name}' already exists.");

            _business.Employees.Add(employee);
        }

        // Assigns a shift to an employee for a specific date and hours worked
        public void AssignShift(DateTime date, string employeeName, int hours)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                throw new ArgumentException("Employee name cannot be empty or whitespace.");
            if (hours <= 0)
                throw new ArgumentException("Hours worked must be greater than zero.");

            var employee = _business.Employees.FirstOrDefault(e => e.Name.Equals(employeeName, StringComparison.OrdinalIgnoreCase));
            if (employee == null)
                throw new Exception($"Employee '{employeeName}' not found.");

            var roster = _business.Rosters.FirstOrDefault(r => r.Date.Date == date.Date)
                         ?? _business.CreateRoster(date);

            if (!roster.Employees.Contains(employee))
                roster.AddEmployee(employee);

            employee.AddHours(hours);
        }

        // Distributes tips among employees based on the defined strategy
        public void DistributeTips(decimal totalTips)
        {
            if (totalTips <= 0)
                throw new ArgumentException("Total tips must be greater than zero.");

            if (!_business.Employees.Any())
                throw new Exception("No employees to distribute tips.");

            _tipDistributionStrategy.DistributeTips(_business, totalTips);
        }

        // Returns the list of employees in the business
        public IEnumerable<Employee> GetEmployees()
        {
            return _business.Employees;
        }
    }
}
