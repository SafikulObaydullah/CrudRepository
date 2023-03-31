using DirdGroupTest.DTO;
using DirdGroupTest.Models;
using DirdGroupTest.Service.Interface.Manager;
using DirdGroupTest.Service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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
      EmployeeManager _employeeManager;
      public EmplyeeBasicInfoController(ApplicationDbContext context,IEmployeeRepo employeeRepo)
      {
         
         //this._employeeManager = new EmployeeManager(context);
         this._EmployeeRepo= employeeRepo;   
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
      //[HttpPost]
      //[Route("CreateEmployeeBasicInfo")]
      //public EmployeeBasicInfo CreateEmployeeBasicInfo(EmployeeBasicInfo obj)
      //{
      //   try
      //   {
      //      //var data = await _EmployeeRepo.CreateEmployee(obj);
      //      bool isSaved = _employeeManager.Add(obj);
      //      _context.SaveChanges();
      //      if (isSaved)
      //      {
      //         return obj;
      //      }
      //      return null;
      //   }
      //   catch (Exception ex)
      //   {
      //      throw new Exception();
      //   }
      //}
      [HttpGet]
      [Route("GetEmployee")]
      public async Task<List<EmployeeBasicInfoDTO>> GetEmployee()
      {
         var data = await _EmployeeRepo.GetEmployee();
         //var data =  _employeeManager.GetAll().ToList();
         return data;  
      }
      [HttpGet]
      [Route("DeleteEmployee")]
      public async Task<MessageHelper> DeleteEmployee(long Id)
      {
         var data = await _EmployeeRepo.DeleteEmployee(Id);
         return data;
      }
      [HttpGet]
      [Route("GetEmployeeById")]
      public async Task<List<EmployeeBasicInfoDTO>> GetEmployeeById(long EmployeeId)
      {
         var data = await _EmployeeRepo.GetEmployeeById(EmployeeId);
         return data;
      }
      [HttpPut]
      [Route("UpdateEmployee")]
      public async Task<MessageHelper> UpdateEmployee(EmployeeBasicInfoDTO obj)
      {
         var data = await _EmployeeRepo.UpdateEmployee(obj);
         return data;
      }
   }
}
