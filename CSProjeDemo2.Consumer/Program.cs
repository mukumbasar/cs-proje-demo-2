using CSProjeDemo2.ClassLibrary.Managers;

namespace CSProjeDemo2.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Lists", "Personnel.json");

            PersonnelFinanceManager personnelFinanceManager = new PersonnelFinanceManager();
            personnelFinanceManager.ReadPersonnelFile(filePath);

            foreach (var personnel in personnelFinanceManager.PersonnelList)
            {
                var workingHoursInput = Console.ReadLine();
                if (int.TryParse(workingHoursInput, out int workingHours))
                {
                    var payroll = personnel.CalculateSalary(workingHours);
                    Console.WriteLine($"Personnel Name: {payroll.PersonnelName}");
                    Console.WriteLine($"Working Hours: {payroll.WorkingHours}");
                    Console.WriteLine($"Overtime Payment: {payroll.OvertimePayment}");
                    Console.WriteLine($"Monthly Bonus: {payroll.MonthlyBonus}");
                    Console.WriteLine($"Total Payment: {payroll.TotalPayment}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.ReadLine();
            }
       
            //manager.CreatePayrolls();
        }
    }
}
