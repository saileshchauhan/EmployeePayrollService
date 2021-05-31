using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=PayRoll_Service13;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        EmployeeModel employeeModel = new EmployeeModel();
        public bool GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = "spSelectAl";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.Salary = (double)dr.GetDecimal(2);
                            employeeModel.BasicPay = (double)dr.GetDecimal(7);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.Address = dr.GetString(5);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.Deductions = (int)dr.GetDecimal(8);
                            employeeModel.NetPay = (double)dr.GetDecimal(9);
                            Console.WriteLine(employeeModel.EmployeeName + " " + employeeModel.Salary + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.Address + " " + employeeModel.Department + " "+employeeModel.BasicPay+" " + employeeModel.Deductions + " " + employeeModel.NetPay);
                            Console.WriteLine("\n");
                        }
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                        return false;
                    }
                    
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        

        public bool AddEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
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
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
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
                connection.Close();
            }
            return true;
        }
        public void Method_For_MultiThreading()
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                employee.EmployeeName = "JACKSON";
                employee.Department = "offshore";
                employee.PhoneNumber = "6304525678";
                employee.Address = "05-JABALPUR";
                employee.Gender = 'M';
                employee.BasicPay = 200000.00;
                employee.Deductions = 15000;
                employee.StartDate = Convert.ToDateTime("2020-01-03");
                Task thread = new Task(() =>
                {
                    // Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                    this.AddEmployee(employee);
                    // Console.WriteLine("Employee added: " + employeeData.EmployeeName);
                });
                thread.Start();
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
         
        }
        public void Update_Terrisa()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try 
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdatEntry", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@salary", 20000);
                    command.Parameters.AddWithValue("@name", "terrisa");
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
            finally
            {
                connection.Close();
            }
        }
        public void Retreive_EmployeInDateRange()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = "spSelectEmplyInDateRange";
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
            finally
            {
                connection.Close();
            }
        }
        public void Find_SumAverageMinMax()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string querySum = "spManyQueryExecution";
                    string queryAverage = "Select AVG(salary),gender from employee_payroll1 group by gender";
                    string queryMInimumSalary = "Select MIN(salary),gender from employee_payroll1 group by gender";
                    string queryMaximumSalary = "Select MAX(salary),gender from employee_payroll1 group by gender";

                    SqlCommand command = new SqlCommand(querySum, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            decimal Sum = reader.GetDecimal(0);
                            employeeModel.Gender = Convert.ToChar(reader.GetString(1));
                            Console.WriteLine("Sum of Salary "+Sum+" Gender "+employeeModel.Gender);
                        }
                        connection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No Data to read");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void InsertEmployeeRecord(EmployeeModel employee)
        {
            employee.Deductions = Convert.ToInt32(0.2 * employee.BasicPay);
            employee.TaxablePay = employee.BasicPay - employee.Deductions;
            employee.Tax = Convert.ToInt32(0.1 * employee.TaxablePay);
            employee.NetPay = employee.BasicPay - employee.Tax;
            SqlConnection connection = new SqlConnection(connectionString);


            string storedProcedure = "spInsertEmployeeDetails";
            string storedProcedurePayroll = "spInsertPayrollDeatils";
            using (connection)
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Insert Employee Transaction");
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(storedProcedure, connection, transaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@start_Date", employee.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Name", employee.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
                    SqlParameter outPutVal = new SqlParameter("@scopeIdentifier", SqlDbType.Int);
                    outPutVal.Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(outPutVal);

                    sqlCommand.ExecuteNonQuery();
                    SqlCommand sqlCommand1 = new SqlCommand(storedProcedurePayroll, connection, transaction);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.AddWithValue("@ID", outPutVal.Value);
                    sqlCommand1.Parameters.AddWithValue("@Basic_Pay", employee.BasicPay);
                    sqlCommand1.Parameters.AddWithValue("@Deductions", employee.Deductions);
                    sqlCommand1.Parameters.AddWithValue("@Taxable_Pay", employee.TaxablePay);
                    sqlCommand1.Parameters.AddWithValue("@Taxes", employee.Tax);
                    sqlCommand1.Parameters.AddWithValue("@Net_Pay", employee.NetPay);
                    sqlCommand1.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    Console.WriteLine("Transaction completed successfully");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transataion Rolled Back");
                    }
                    catch (Exception exceptionDuringRollback)
                    {

                        Console.WriteLine(exceptionDuringRollback.Message);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

        }

    }

}
