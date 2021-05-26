using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=PayRoll_Service13;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        readonly SqlConnection connection = new SqlConnection(connectionString);
        readonly EmployeeModel employeeModel = new EmployeeModel();
        public void GetAllEmployee()
        {
            try
            {
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll1;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.Salary = dr.GetDecimal(2);
                            employeeModel.BasicPay = dr.GetDecimal(7);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.Address = dr.GetString(5);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.Deductions = dr.GetDecimal(8);
                            employeeModel.NetPay = dr.GetDecimal(9);
                            Console.WriteLine(employeeModel.EmployeeName + " " + employeeModel.Salary + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.Address + " " + employeeModel.Department + " "+employeeModel.BasicPay+" " + employeeModel.Deductions + " " + employeeModel.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    //var qury=values()
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    //command.Parameters.AddWithValue("@City", model.City);
                    //command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public void Update_Terrisa()
        {
            try 
            {
                using (connection)
                {
                    string query = "UPDATE employee_payroll1 SET salary=3000000 WHERE name='terissa'";
                    SqlCommand command = new SqlCommand(query,connection);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if(result!=0)
                        Console.WriteLine("Records of Terrisa Updated");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Retreive_EmployeInDateRange()
        {
            try
            {
                using (connection)
                {
                    string query = "SELECT * from employee_payroll1 where start between '2019-01-01' and GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeModel.EmployeeName = reader.GetString(1);
                            employeeModel.StartDate = reader.GetDateTime(3);
                            Console.WriteLine("Employe Name "+ employeeModel.EmployeeName+" Start Date "+ employeeModel.StartDate);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
