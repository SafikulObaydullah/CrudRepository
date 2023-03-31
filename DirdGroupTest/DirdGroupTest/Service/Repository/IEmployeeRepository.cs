using DirdGroupTest.Models;
using EF.Core.Repository.Interface.Repository;

namespace DirdGroupTest.Service.Repository
{
   public interface IEmployeeRepository:ICommonRepository<EmployeeBasicInfo>
   {
   }
}
