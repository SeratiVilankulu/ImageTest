using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
    {
      return await _context.Employees.ToListAsync();
    }

    //GET : api/Employee
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
    {
      var employeeModel = await _context.Employees.FindAsync(id);

      if (employeeModel == null)
      {
        return NotFound();
      }

      return employeeModel;
    }

    //PUT: api/Employee
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployeeModel(int id, EmployeeModel employeeModel)
    {
      if (id != employeeModel.EmployeeID)
      {
        return BadRequest();
      }

      _context.Entry(employeeModel).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EmployeeModelExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    //Post: api/Employee
    [HttpPost]
    public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(EmployeeModel employeeModel)
    {
      _context.Employees.Add(employeeModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetEmoployeeModel", new { id = employeeModel.EmployeeID }, employeeModel);
    }

    //Delete: api/Employee
    [HttpDelete("{id}")]
    public async Task<ActionResult<EmployeeModel>> DeleteEmployeModel(int id)
    {
      var employeeModel = await _context.Employees.FindAsync(id);
      if (employeeModel == null)
      {
        return NotFound();
      }

      _context.Employees.Remove(employeeModel);
      await _context.SaveChangesAsync();

      return employeeModel;
    }

    private bool EmployeeModelExists(int id)
    {
      return _context.Employees.Any(e => e.EmployeeID == id);
    }
  }
}
