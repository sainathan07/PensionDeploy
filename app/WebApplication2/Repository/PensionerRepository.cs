using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Repository
{
    public class PensionerRepository : IPensionerRepository
    {
        private readonly DbContextClass _dbContext;

        public PensionerRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeletePensioner(long adhaarId)
        {
            var pensioner = _dbContext.Pensioner.Find(adhaarId);
            _dbContext.Pensioner.Remove(pensioner);
            Save();
        }

        public PensionerModel GetProductByID(long adhaarId)
        {
            return _dbContext.Pensioner.Find(adhaarId);
        }

        public IEnumerable<PensionerModel> GetPensioners()
        {
            return _dbContext.Pensioner.ToList();
        }

        public void InsertProduct(PensionerModel pensioner)
        {
            _dbContext.Add(pensioner);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}