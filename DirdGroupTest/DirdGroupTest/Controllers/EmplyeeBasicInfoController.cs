using DirdGroupTest.DTO;
using DirdGroupTest.Models;
using DirdGroupTest.Service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DirdGroupTest.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EmplyeeBasicInfoController : ControllerBase
   {
      private readonly IEmployeeRepo _EmployeeRepo;
      private readonly ApplicationDbContext _context;
      public EmplyeeBasicInfoController(ApplicationDbContext context, IEmployeeRepo employeeRepo)
      {
         this._EmployeeRepo = employeeRepo;
         _context = context;
      }
      [HttpPost]
      [Route("CreateEmployeeBasicInfo")]
      public async Task<MessageHelper> CreateEmployeeBasicInfo(EmployeeBasicInfoDTO obj)
      {
         try
         {
            var data = await _EmployeeRepo.CreateEmployee(obj);
            return data;
         }
         catch (Exception ex)
         {
            throw new Exception();
         }
      }
      [HttpGet]
      [Route("GetEmployeebasicInfo")]
      public async Task<IActionResult> GetEmployee()
      {
         var data = await _EmployeeRepo.GetEmployee();
         return Ok(data);  
      }
   }
}
