using WebApplication2.Models;
using System;
using System.Collections.Generic;

namespace WebApplication2.Repository
{
    public interface IPensionerRepository
    {
        IEnumerable<PensionerModel> GetPensioners();
        PensionerModel GetProductByID(long adhaarId);
        void InsertProduct(PensionerModel pensioner);
        void DeletePensioner(long adhaarId);
        void Save();
    }
}