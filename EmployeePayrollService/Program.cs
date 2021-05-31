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
            employee.EmployeeName = "JACKSON";
            employee.Department = "offshore";
            employee.PhoneNumber = "6304525678";
            employee.Address = "05-JABALPUR";
            employee.Gender = 'M';
            employee.BasicPay = 200000.00;
            employee.Deductions = 15000;
            employee.StartDate = Convert.ToDateTime("2020-01-03");
            repo.Retreive_EmployeInDateRange();
            repo.Find_SumAverageMinMax();
            repo.Update_Terrisa();
            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");
            repo.InsertEmployeeRecord(employee);
            repo.GetAllEmployee();
            Console.ReadKey();
        }
    }
}
