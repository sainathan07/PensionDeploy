using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Repository
{
    public class ProcessPensionRepository:IProcessPensionRepository
    {
        private readonly DbContextClass db;
        public ProcessPensionRepository(DbContextClass dbContext)
        {
            db = dbContext;
        }
        public async Task<PensionDetail> GetPension(long adhaarId)
        {
            var pensioner = await db.Pensioner.FindAsync(adhaarId);
            if (pensioner != null)
            {
                bool type = pensioner.PensionClassification;
                string Name = pensioner.Name;
                string Pan = pensioner.Pan;
                decimal salary = pensioner.LastSalary;
                decimal allowance = pensioner.Allowance;
                string BankType = pensioner.BankType;
                decimal PensionAmount;
                decimal ServiceCharge;
                if (pensioner.PensionClassification is true)
                    PensionAmount = pensioner.LastSalary * 80 / 100;
                else
                    PensionAmount = pensioner.LastSalary * 50 / 100;

                if (pensioner.BankType == "Public")
                    ServiceCharge = 500;
                else
                    ServiceCharge = 550;
                var result = new PensionDetail();
                result.PensionAmount = PensionAmount;
                result.adhaarId = adhaarId;
                result.BankCharge = ServiceCharge;
                return result;
            }
            return null;
        }
    }
}
