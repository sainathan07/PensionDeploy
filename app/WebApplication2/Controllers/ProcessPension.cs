using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessPension : Controller
    {
        private readonly IProcessPensionRepository _processPensionRepository;
        public ProcessPension(IProcessPensionRepository processPensionRepository)
        {
            _processPensionRepository = processPensionRepository;
        }

        [HttpGet("{adhaarId}")]
        public async Task<IActionResult> Get(long adhaarId)
        {
            var pensioner =  await _processPensionRepository.GetPension(adhaarId);
            return new OkObjectResult(pensioner);
        }
    }
}
