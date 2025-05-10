using Microsoft.AspNetCore.Mvc;
using s26740cw4.Models;

namespace s26740cw4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    [HttpPost]
    public IActionResult Add([FromBody] Visit visit)
    {
        Database.Visits.Add(visit);
        return Created($"/api/visits/{visit.Id}", visit);
    }
}