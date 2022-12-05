using ApiSampleNoAuth.Data;
using ApiSampleNoAuth.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleNoAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class InfiniteController : ControllerBase
{
    private readonly Seed _seed;

    public InfiniteController(Seed seed)
    {
        _seed = seed;
    }
    
    [HttpGet(Name = "GetInfinite")]
    public async Task<IActionResult> Get([FromQuery] int take, [FromQuery] bool after, [FromQuery] string? identifierValue, [FromQuery] string? search)
    {

        List<Person> searched;
        if (string.IsNullOrWhiteSpace(search))
        {
            searched = _seed.GetPeople();
        }
        else
        {
            searched = _seed.GetPeople().FindAll(p => p.FirstName.ToLower().StartsWith(search.ToLower()));
        }

        List<Person> people;

        if (string.IsNullOrWhiteSpace(identifierValue))
        {
            people = searched;
        }
        else
        {
            people = after ? searched.Where(p => string.CompareOrdinal(p.Id, identifierValue) > 0).ToList() 
                : searched.Where(p => string.CompareOrdinal(p.Id, identifierValue) < 0).ToList();    
        }
        
        var sorted = after ? people.OrderBy(p => p.Id).ToList() : people.OrderByDescending(p => p.Id).ToList();
        
        var slice = sorted.Count > 0 ? sorted.Take(Math.Min(take, sorted.Count)).ToList() : new List<Person>();
            
        var response = new ContinuousPaginationResponseSchema<List<Person>>(slice, "id", after);
        return Ok(response);

    }
    
}