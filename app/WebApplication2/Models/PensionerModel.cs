using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class PensionerModel
    {
        [Key]
        public long AdhaarId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Pan { get; set; }
        public decimal LastSalary { get; set; }
        public decimal Allowance { get; set; }
        public bool PensionClassification { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string BankType { get; set; }


    }
}
