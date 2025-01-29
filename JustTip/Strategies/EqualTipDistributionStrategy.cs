using JustTip.Models;

namespace JustTip.Strategies
{
    public class EqualTipDistributionStrategy : ITipDistributionStrategy
    {
        // Distributes tips equally among all employees
        public void DistributeTips(Business business, decimal totalTips)
        {
            var employeeCount = business.Employees.Count;

            // Ensure there are employees to distribute tips to
            if (employeeCount == 0)
                throw new Exception("No employees to distribute tips.");

            // Calculate the equal share of tips per employee
            var share = totalTips / employeeCount;

            // Distribute the calculated share to each employee
            foreach (var employee in business.Employees)
            {
                employee.TipsEarned += share;
            }
        }
    }
}
