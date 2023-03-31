using DirdGroupTest.Models;
using DirdGroupTest.Service.Interface.Manager;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace DirdGroupTest.Service.Repository
{
   public class EmployeeManager : CommonManager<EmployeeBasicInfo>, IEmployeeManager
   {
      public EmployeeManager(ApplicationDbContext dbContext) : base(new EmployeeRepository(dbContext))
      {
      }
   }
}
 