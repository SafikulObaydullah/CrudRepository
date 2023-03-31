using DirdGroupTest.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace DirdGroupTest.Service.Repository
{
   public class EmployeeRepository : CommonRepository<EmployeeBasicInfo>, IEmployeeRepository
   {
      public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
      {
      }
   }
}
