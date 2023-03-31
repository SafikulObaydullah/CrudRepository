using DirdGroupTest.DTO;

namespace DirdGroupTest.Service.Repository
{
   public interface IEmployeeRepo
   {
      Task<MessageHelper> CreateEmployee(EmployeeBasicInfoDTO obj);
      Task<MessageHelper> UpdateEmployee(EmployeeBasicInfoDTO obj);
      Task<MessageHelper> DeleteEmployee(long Id);
      Task<List<EmployeeBasicInfoDTO>> GetEmployeeById(long EmployeeId);
      Task<List<EmployeeBasicInfoDTO>> GetEmployee();
   }
}
