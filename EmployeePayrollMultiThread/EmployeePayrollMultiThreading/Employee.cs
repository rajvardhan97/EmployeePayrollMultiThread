using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmployeePayrollMultiThreading
{
    public class Employee
    {
        Nlog nLog = new Nlog();
        public static string connection = @"Data Source = RAJVARDHAN;Initial Catalog = Payroll_Service;Integrated Security=SSPI";
        SqlConnection sqlConnection = new SqlConnection(connection);
        List<EmployeePayroll> employee = new List<EmployeePayroll>();
        private static Mutex mutex = new Mutex();
        public bool AddEmployee(EmployeePayroll employees)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertDetails", this.sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", employees.Name);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", employees.start_date);
                    sqlCommand.Parameters.AddWithValue("@Gender", employees.Gender);
                    sqlCommand.Parameters.AddWithValue("@Address", employees.EmployeeAddress);
                    sqlCommand.Parameters.AddWithValue("@Department", employees.Department);
                    sqlCommand.Parameters.AddWithValue("@Phone_Number", employees.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employees.BasicPay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employees.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", employees.TaxablePay);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", employees.IncomeTax);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", employees.NetPay);
                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new CustomException(CustomException.ExceptionType.Connection_Failed, "Connection Failed");
            }
            sqlConnection.Close();
            return false;
        }
        public void AddEmployeeListToEmployeePayrollDataBase(List<EmployeePayroll> employees)
        {
            employees.ForEach(employeeData =>
            {
                nLog.LogDebug("Adding of Employee: " + employeeData.Name + "with ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Employee being added: " + employeeData.Name);
                this.AddEmployee(employeeData);
                nLog.LogInfo("Employee Successfully added in Database with ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Employee added: " + employeeData.Name);
            });
            Console.WriteLine(employees.ToString());
        }
    }
}
