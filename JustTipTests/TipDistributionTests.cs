using JustTip.Models;
using Xunit;

namespace JustTipTests
{
    // Unit tests for tip distribution functionality
    public class TipDistributionTests
    {
        // Test that tips are distributed correctly based on hours worked
        [Fact]
        public void Test_DistributeTips_Correctly()
        {
            var business = new Business("Test Business");
            var emp1 = business.CreateEmployee("Alice");
            var emp2 = business.CreateEmployee("Bob");

            // Create a roster for today and assign employees
            var roster = business.CreateRoster(DateTime.Today);
            roster.AddEmployee(emp1);
            roster.AddEmployee(emp2);

            // Add hours worked by employees
            emp1.AddHours(5);
            emp2.AddHours(3);

            // Distribute tips
            business.DistributeTips(80);

            // Assert that tips are distributed proportionally to hours worked
            Assert.Equal(50, emp1.TipsEarned); // (5/8)*80
            Assert.Equal(30, emp2.TipsEarned); // (3/8)*80
        }

        // Test that no tips are distributed when no hours are worked
        [Fact]
        public void Test_NoHours_NoTips()
        {
            var business = new Business("Test Business");
            var emp1 = business.CreateEmployee("Alice");

            // Create a roster for today and assign the employee
            var roster = business.CreateRoster(DateTime.Today);
            roster.AddEmployee(emp1);

            // Distribute tips
            business.DistributeTips(80);

            // Assert that no tips are earned if no hours were worked
            Assert.Equal(0, emp1.TipsEarned);
        }
    }
}
