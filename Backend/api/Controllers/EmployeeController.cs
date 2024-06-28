using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    public EmployeeController(ApplicationDBContext context)
    {
      _context = context;
    }

    //GET: api/Employee
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>>
    {
      
    }
  }
}