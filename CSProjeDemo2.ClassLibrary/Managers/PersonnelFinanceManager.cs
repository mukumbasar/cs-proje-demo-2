using CSProjeDemo2.ClassLibrary.Entities.Abstracts;
using CSProjeDemo2.ClassLibrary.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSProjeDemo2.ClassLibrary.Managers
{
    public class PersonnelFinanceManager
    {
        public List<Personnel> PersonnelList { get; set; }

        public PersonnelFinanceManager()
        {
            PersonnelList = new List<Personnel>();
        }

        public void ReadPersonnelFile(string localFileAddress)
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
    }
}
