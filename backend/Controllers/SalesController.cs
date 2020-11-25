using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Database;

using System.Data.SqlClient;
using System.Text;


namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {

        [HttpGet]
        public List<Sales> Get()
        {
            SalesOperations ops = new SalesOperations();
            var results = ops.GetSales();
            return results;
        }

        [HttpPost]
        public string Post(List<Sales> salesData)
        {
            SalesOperations ops = new SalesOperations();
            ops.CreateSales(salesData);
            return "Ok";
        }

        [HttpPost]
        [Route("reset")]
        public string Reset(){
            SalesOperations ops = new SalesOperations();
            ops.ResetData();
            return "Resetting";
        }

        

    }
}