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
    public class PensionerController : Controller
    {
        
        private readonly IPensionerRepository _pensionerRepository;
        public PensionerController(IPensionerRepository pensionerRepository)
        {
            _pensionerRepository = pensionerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pensioners =  _pensionerRepository.GetPensioners();
            return new OkObjectResult(pensioners);
        }

        [HttpGet("{adhaarId}")]
        public async Task<IActionResult> Get(long adhaarId)
        {
            var pensioner = _pensionerRepository.GetProductByID(adhaarId);
            return new OkObjectResult(pensioner);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PensionerModel pensioner)
        {
            using (var scope = new TransactionScope())
            {
                _pensionerRepository.InsertProduct(pensioner);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = pensioner.AdhaarId }, pensioner);
            }
        }
    }
}
