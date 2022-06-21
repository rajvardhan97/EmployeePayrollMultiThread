using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime start_date { get; set; }
        public string Gender { get; set; }
        public string EmployeeAddress { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetPay { get; set; }
    }
}
