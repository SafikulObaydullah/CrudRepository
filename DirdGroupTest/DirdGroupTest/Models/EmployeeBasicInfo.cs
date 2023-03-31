using System.ComponentModel.DataAnnotations;

namespace DirdGroupTest.Models
{
   public class EmployeeBasicInfo
   {
      [Key]
      public long EmployeeId { get; set; }
      public string EmplyeeName { get; set; }
      public string Email { get; set; }   
   }
}
