using JustTip.Models;

namespace JustTip.Strategies
{
    public class ProportionalTipDistributionStrategy : ITipDistributionStrategy
    {
        // Distributes tips proportionally based on the hours worked by each employee
        public void DistributeTips(Business business, decimal totalTips)
        {
            // Calculate the total hours worked by all employees
            var totalHours = business.Employees.Sum(e => e.HoursWorked);

            // Ensure there are hours worked to distribute tips proportionally
            if (totalHours == 0)
                throw new Exception("No hours worked. Cannot distribute tips proportionally.");

            // Distribute tips based on each employee's share of total hours worked
            foreach (var employee in business.Employees)
            {
                employee.TipsEarned += totalTips * employee.HoursWorked / totalHours;
            }
        }
    }
}
