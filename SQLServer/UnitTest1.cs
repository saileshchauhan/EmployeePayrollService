using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SQLServer
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    EmployeeRepo repo = new EmployeeRepo();
        //    EmployeeModel employee = new EmployeeModel();
        //    employee.EmployeeName = "Mohan";
        //    employee.Department = "Tech1";
        //    employee.PhoneNumber = "6302907678";
        //    employee.Address = "02-Patna";
        //    employee.Gender = 'M';
        //    employee.BasicPay = 10000.00;
        //    employee.Deductions = 1500;
        //    employee.StartDate = Convert.ToDateTime("2020-11-03");
        //    //Mock<EmployeeRepo> mockObj = new Mock<EmployeeRepo>();
        //   // mockObj.Setup(t=>t.AddEmployee(It.IsIn<EmployeeModel>)).return (true);
        //    var result = repo.AddEmployee(employee);
        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void GetAllEmployeeShouldReturnListOfRecords()
        //{
        //    EmployeeRepo repo = new EmployeeRepo();
        //    var result = repo.GetAllEmployee();
        //    Assert.IsTrue(result);
        //}
        [TestMethod]
        public void Given_TransactionTSql_usingMultithreading_ShouldReturn_Differnt_execution_Time()
        {
            EmployeeRepo employee = new EmployeeRepo();
            EmployeeModel employeeDetails = new EmployeeModel();
            employeeDetails.EmployeeName = "OBAMA";
            employeeDetails.Department = "PRESIDENT";
            employeeDetails.PhoneNumber = "6304525678";
            employeeDetails.Address = "05-U S";
            employeeDetails.Gender = 'M';
            employeeDetails.BasicPay = 200000.00;
            employeeDetails.Deductions = 15000;
            employeeDetails.StartDate = Convert.ToDateTime("2020-01-03");
            DateTime startTime = DateTime.Now;
            employee.AddEmployee(employeeDetails);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duartion Without Thread "+(stopTime-startTime));
            TimeSpan spanWithoutThread = stopTime - startTime;


            DateTime startTimeWithThread = DateTime.Now;
            employee.Method_For_MultiThreading();
            DateTime stopTimeWithThread = DateTime.Now;
            Console.WriteLine("Duration with Thread "+(stopTimeWithThread-startTimeWithThread));
            TimeSpan spanWithThread = stopTimeWithThread - startTimeWithThread;

            Assert.AreNotEqual(spanWithoutThread, spanWithThread);
        }

    }


}
