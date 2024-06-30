using ApiForReact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Emp")]
public class EmployeesController : ControllerBase
{
 
    private readonly IConfiguration _configuration;

    public EmployeesController(  IConfiguration configuration)
    {
       
        _configuration = configuration;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var employees = EmployeeData.GetEmployees();
        return Ok(employees);
    }

    //[HttpPost]
    //public IActionResult Post([FromBody] Employee employee)
    //{
    //    EmployeeData.AddEmployee(employee);
    //    return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    //}


    [HttpPost,ActionName("CreateWithAttach")]
    public IActionResult CreateWithAttach([FromForm] Employee employee, List<IFormFile> attachments)
    {
        if (ModelState.IsValid)
        {
            string uploadPath = _configuration["UploadPath"];
            foreach (var file in attachments)
            {
                if (file.Length > 0)
                {
                    var fileExtension = Path.GetExtension(file.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                          file.CopyToAsync(stream);
                    }
                    if (employee.Attachments == null)
                    {
                        employee.Attachments = new List<Attachment>();
                    }
                    employee.Attachments.Add(new Attachment { Name = uniqueFileName, Url = $"/Uploads/{uniqueFileName}" });
                }
            }

            EmployeeData.AddEmployee(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        return BadRequest(ModelState);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = EmployeeData.GetEmployee(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Employee employee)
    {
        var existingEmployee = EmployeeData.GetEmployee(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }
        EmployeeData.UpdateEmployee(id, employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = EmployeeData.GetEmployee(id);
        if (employee == null)
        {
            return NotFound();
        }
        EmployeeData.DeleteEmployee(id);
        return NoContent();
    }
}
