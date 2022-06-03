using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Repository
{
    public interface IProcessPensionRepository
    {
        Task<PensionDetail> GetPension(long adhaarId);
    }
}
