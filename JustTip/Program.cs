using JustTip.Controllers;

namespace JustTip
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new BusinessController("JustTip Inc");

            while (true)
            {
                Console.Clear(); // Clear the screen for better navigation
                Console.WriteLine("=== Welcome to JustTip ===");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Assign Shift");
                Console.WriteLine("3. Distribute Tips");
                Console.WriteLine("4. View Employees and Tips");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(controller);
                        break;

                    case "2":
                        AssignShift(controller);
                        break;

                    case "3":
                        DistributeTips(controller);
                        break;

                    case "4":
                        ViewEmployees(controller);
                        break;

                    case "5":
                        Console.WriteLine("Exiting... Thank you for using JustTip!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddEmployee(BusinessController controller)
        {
            Console.Clear();
            Console.WriteLine("=== Add Employee ===");
            Console.Write("Enter the employee's name: ");
            var name = Console.ReadLine();

            try
            {
                controller.AddEmployee(name);
                Console.WriteLine($"Employee '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        static void AssignShift(BusinessController controller)
        {
            Console.Clear();
            Console.WriteLine("=== Assign Shift ===");
            Console.Write("Enter the date (YYYY-MM-DD): ");
            var dateInput = Console.ReadLine();

            Console.Write("Enter the employee's name: ");
            var name = Console.ReadLine();

            Console.Write("Enter the number of hours worked: ");
            var hoursInput = Console.ReadLine();

            try
            {
                var date = DateTime.Parse(dateInput);
                var hours = int.Parse(hoursInput);
                controller.AssignShift(date, name, hours);
                Console.WriteLine($"Shift of {hours} hours assigned to '{name}' on {date.ToShortDateString()}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        static void DistributeTips(BusinessController controller)
        {
            Console.Clear();
            Console.WriteLine("=== Distribute Tips ===");
            Console.Write("Enter the total amount of tips: ");
            var tipsInput = Console.ReadLine();

            try
            {
                var tips = decimal.Parse(tipsInput);
                controller.DistributeTips(tips);
                Console.WriteLine($"Tips amounting to ${tips} distributed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        static void ViewEmployees(BusinessController controller)
        {
            Console.Clear();
            Console.WriteLine("=== Employees and Tips ===");

            var employees = controller.GetEmployees();

            if (employees.Any())
            {
                foreach (var emp in employees)
                {
                    Console.WriteLine($"Name: {emp.Name}, Tips: ${emp.TipsEarned:F2}, Hours Worked: {emp.HoursWorked}");
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
