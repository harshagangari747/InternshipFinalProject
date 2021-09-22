using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PensionerDetail.Entities;
using PensionerDetail.DbContexts;

namespace PensionerDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailsController : ControllerBase
    {
        /*private readonly PensionerDetailDbContext context;
        public PensionerDetailsController(PensionerDetailDbContext _context)
        {
            context = _context;
        }*/

        List<PensionerDetails> pensioners = new List<PensionerDetails>();

        public PensionerDetailsController()
        {
            pensioners.Add(new PensionerDetails() {Name="bunk seenu",dateOfBirth = new DateTime(1990,01,02) ,PAN = "ABCD12351E",salaryEarned=45000,
            allowances=500,pensionType=PensionerDetails.PensionType.family,bankName = "SBI",accountNumber="SBI00001BS",bankType=PensionerDetails.BankType.publicbank});
        }

        [Route("getById")]
        [HttpGet]
        public ActionResult Get(string aadharID)
        {
            PensionerDetails findPensioner = pensioners.Find(x => x.PAN.Equals(aadharID));
            if(findPensioner!=null)
            {
                return Ok(findPensioner);
            }
            return BadRequest("No user found. Check Details please");
        }
    }
}
