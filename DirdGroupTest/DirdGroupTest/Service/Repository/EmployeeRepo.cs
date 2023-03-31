using DirdGroupTest.DTO;
using DirdGroupTest.Models;
using DirdGroupTest.Service.Interface.Manager;
using Microsoft.EntityFrameworkCore;

namespace DirdGroupTest.Service.ServiceRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MessageHelper> CreateEmployee(EmployeeBasicInfoDTO obj)
        {
            try
            {
                EmployeeBasicInfo model = new EmployeeBasicInfo()
                {
                    EmplyeeName = obj.EmplyeeName,
                    Email = obj.Email,
                };
                _context.Employees.Add(model);
                await _context.SaveChangesAsync();
                var msg = new MessageHelper();
                msg.Message = "Created Successfully";
                msg.StatusCode = 200;
                return msg;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<MessageHelper> DeleteEmployee(long Id)
        {
            var data = await _context.Employees.Where(x => x.EmployeeId == Id).FirstOrDefaultAsync();
            //_context.Employees.Remove(_context.Employees.FirstOrDefault());
             _context.Employees.Remove(data);
             await _context.SaveChangesAsync();
            return new MessageHelper()
            {
                Message = "Deleted Successfully",
                StatusCode = 200,
            };
        }

        public async Task<List<EmployeeBasicInfoDTO>> GetEmployee()
        {
            List<EmployeeBasicInfoDTO> data = await (from emp in _context.Employees
                                                     select new EmployeeBasicInfoDTO
                                                     {
                                                         EmplyeeName = emp.EmplyeeName,
                                                         Email = emp.Email,
                                                     }).ToListAsync();
            return data;
        }

        public async Task<List<EmployeeBasicInfoDTO>> GetEmployeeById(long EmployeeId)
        {
            List<EmployeeBasicInfoDTO> data = await (from emp in _context.Employees
                                                     where emp.EmployeeId == EmployeeId
                                                     select new EmployeeBasicInfoDTO
                                                     {
                                                         EmplyeeName = emp.EmplyeeName,
                                                         Email = emp.Email,
                                                     }).ToListAsync();
            return data;
        }

        public async Task<MessageHelper> UpdateEmployee(EmployeeBasicInfoDTO obj)
        {
            var updata = await _context.Employees.Where(x => x.EmployeeId == obj.EmployeeId).FirstOrDefaultAsync();
            EmployeeBasicInfo employeeBasicInfo = new EmployeeBasicInfo()
            {
                EmplyeeName = obj.EmplyeeName,
                Email = obj.Email,
            };
            _context.Employees.Update(employeeBasicInfo);
            _context.SaveChangesAsync();
            return new MessageHelper()
            {
                Message = "Updated Successfully",
                StatusCode = 200,
            };

        }
    }
}
