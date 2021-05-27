using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll!");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Krishna";
            employee.Department = "Tech7";
            employee.PhoneNumber = "63045907678";
            employee.Address = "02-Bhopal";
            employee.Gender = 'M';
            employee.BasicPay = 10000.00M;
            employee.Deductions = 1500;
            employee.StartDate = Convert.ToDateTime("2020-11-03");
            repo.Retreive_EmployeInDateRange();
            repo.Find_SumAverageMinMax();
            repo.Update_Terrisa();
            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");
            repo.GetAllEmployee();
            Console.ReadKey();
        }
    }
}
