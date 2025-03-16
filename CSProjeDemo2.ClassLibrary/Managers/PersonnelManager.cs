using CSProjeDemo2.ClassLibrary.Entities.Abstracts;
using CSProjeDemo2.ClassLibrary.Helpers;
using CSProjeDemo2.ClassLibrary.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSProjeDemo2.ClassLibrary.Managers
{
    public class PersonnelManager
    {
        public List<Personnel> PersonnelList { get; set; }

        public PersonnelManager()
        {
            PersonnelList = new List<Personnel>();
        }

        public void CreatePayrolls()
        {
            string filePath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Lists", "Personnel.json");

            PersonnelManager personnelManager = new PersonnelManager();
            personnelManager.ReadPersonnelFile(filePath);

            foreach (var personnel in personnelManager.PersonnelList)
            {
                while (true)
                {
                    Console.Write($"Please enter monthly working hours of {personnel.Name} {personnel.Surname} - {personnel.Title}: ");
                    var workingHoursInput = Console.ReadLine();

                    if (int.TryParse(workingHoursInput, out int workingHours))
                    {
                        if (workingHours <= 10)
                        {
                            var absenceReport = new AbsenceReport
                            {
                                PersonnelName = personnel.Name + " " + personnel.Surname,
                                ReportDate = DateTime.Now.ToString("yyyyMMdd"),
                                HoursWorked = workingHours
                            };
                            WriteAbsenceReportAsJson(absenceReport);
                            Console.WriteLine("Absence report has been successfully created and saved to the designated folder.");
                        }
                        else
                        {
                            var payroll = personnel.CalculateSalary(workingHours);
                            personnelManager.WritePayrollAsJson(payroll);
                            Console.WriteLine("The payroll has been successfully created and saved to the designated folder.");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                }
            }
        }

        private void ReadPersonnelFile(string localFileAddress)
        {
            try
            {
                string jsonContent = File.ReadAllText(localFileAddress);
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters.Add(new PersonnelConverter());

                PersonnelList = JsonConvert.DeserializeObject<List<Personnel>>(jsonContent, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void WritePayrollAsJson(Payroll payroll)
        {
            string currentYearMonthFolder = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Payrolls", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
            Directory.CreateDirectory(currentYearMonthFolder);
            string personnelFolder = Path.Combine(currentYearMonthFolder, payroll.PersonnelName);
            Directory.CreateDirectory(personnelFolder);

            string dateString = DateTime.Now.ToString("yyyyMMdd");
            string payrollFileName = $"{payroll.PersonnelName}_{dateString}_payroll.json";
            string payrollFilePath = Path.Combine(personnelFolder, payrollFileName);
            string payrollJson = JsonConvert.SerializeObject(payroll, Formatting.Indented);
            string finalJson = $"Payroll, {DateTime.Now.ToString("MMMM yyyy").ToUpper()}\n{payrollJson}";

            File.WriteAllText(payrollFilePath, finalJson);
        }




        private void WriteAbsenceReportAsJson(AbsenceReport absenceReport)
        {
            string currentYearMonthFolder = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "AbsenceReports", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString("00"));
            Directory.CreateDirectory(currentYearMonthFolder);
            string personnelFolder = Path.Combine(currentYearMonthFolder, absenceReport.PersonnelName);
            Directory.CreateDirectory(personnelFolder);

            string dateString = DateTime.Now.ToString("yyyyMMdd");
            string absenceReportFileName = $"{absenceReport.PersonnelName}_{dateString}_absence_report.json";
            string absenceReportFilePath = Path.Combine(personnelFolder, absenceReportFileName);
            string absenceReportJson = JsonConvert.SerializeObject(absenceReport, Formatting.Indented);
            string finalJson = $"Absence Report, {DateTime.Now.ToString("MMMM yyyy").ToUpper()}\n{absenceReportJson}";

            File.WriteAllText(absenceReportFilePath, finalJson);
        }

    }
}
