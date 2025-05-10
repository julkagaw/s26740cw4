using Microsoft.AspNetCore.Mvc;
using s26740cw4.Models;

namespace s26740cw4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Database.Animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    [HttpGet("search")]
    public IActionResult SearchByName([FromQuery] string name)
    {
        var animals = Database.Animals.Where(a => a.Name.ToLower().Contains(name.ToLower())).ToList();
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Animal animal)
    {
        Database.Animals.Add(animal);
        return Created($"/api/animals/{animal.Id}", animal);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Animal updated)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        animal.Name = updated.Name;
        animal.Category = updated.Category;
        animal.Weight = updated.Weight;
        animal.FurColor = updated.FurColor;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        Database.Animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id}/visits")]
    public IActionResult GetVisitsForAnimal(int id)
    {
        var visits = Database.Visits.Where(v => v.AnimalId == id).ToList();
        return Ok(visits);
    }
}