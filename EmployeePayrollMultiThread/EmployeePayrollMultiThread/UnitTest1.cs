using NUnit.Framework;
using EmployeePayrollMultiThreading;
using System;
using System.Collections.Generic;

namespace EmployeePayrollMultiThreading
{
    public class Tests
    {
        Employee employee;
        [SetUp]
        public void Setup()
        {
            employee = new Employee();
        }

        [Test]
        public void AddingMultipleData_WithoutThreads_GettingTime()
        {
            List<EmployeePayroll> employeeList = new List<EmployeePayroll>();
            employeeList.Add(new EmployeePayroll { Name = "Mukesh", start_date = new System.DateTime(2021 - 08 - 12), Gender = "M", EmployeeAddress = "Lucknow", Department = "Sales", PhoneNumber = "7894586954",BasicPay = 10000, Deductions = 500, TaxablePay = 500, IncomeTax = 500, NetPay = 11500 });
            employeeList.Add(new EmployeePayroll { Name = "Rajesh", start_date = new System.DateTime(2022 - 04 - 22), Gender = "M", EmployeeAddress = "Delhi", Department = "Delivery", PhoneNumber = "8547253695",BasicPay = 11000, Deductions = 500, TaxablePay = 500, IncomeTax = 500, NetPay = 12500 });
            employeeList.Add(new EmployeePayroll { Name = "Pooja", start_date = new System.DateTime(2021 - 12 - 11), Gender = "F", EmployeeAddress = "Mumbai", Department = "HR", PhoneNumber = "9856320124",BasicPay = 12000, Deductions = 500, TaxablePay = 500, IncomeTax = 500, NetPay = 13500 });
            employeeList.Add(new EmployeePayroll { Name = "Aman", start_date = new System.DateTime(2022 - 05 - 08), Gender = "M", EmployeeAddress = "Bangalore", Department = "Operations", PhoneNumber = "7855496315",BasicPay = 9000, Deductions = 500, TaxablePay = 500, IncomeTax = 500, NetPay = 10500 });
            employeeList.Add(new EmployeePayroll { Name = "Rahul", start_date = new System.DateTime(2022 - 06 - 17), Gender = "M", EmployeeAddress = "Jaipur", Department = "Sales", PhoneNumber = "8456903257",BasicPay = 10000, Deductions = 500, TaxablePay = 500, IncomeTax = 500, NetPay = 11500 });

            DateTime startTime = DateTime.Now;
            employee.AddEmployeeListToEmployeePayrollDataBase(employeeList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (endTime - startTime));
        }
    }
}