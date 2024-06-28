using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Employee
  {
    [Key]
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string Occupation { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
  }
}