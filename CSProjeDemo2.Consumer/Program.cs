using CSProjeDemo2.ClassLibrary.Managers;

namespace CSProjeDemo2.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonnelManager personnelManager = new PersonnelManager();
            personnelManager.CreatePayrolls();
        }
    }
}
