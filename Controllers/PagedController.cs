using ApiSampleNoAuth.Data;
using ApiSampleNoAuth.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleNoAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class PagedController : ControllerBase
{
    private readonly Seed _seed;

    public PagedController(Seed seed)
    {
        _seed = seed;
    }
    [HttpGet(Name = "GetPaged")]
    public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int perPage)
    {
        var people = _seed.GetPeople();
        var slice = _seed.GetPeople().Skip((page - 1) * perPage).Take(perPage).ToList();
        var pagesCount = people.Count / perPage;
        var response = new FixedPaginationResponseSchema<List<Person>>(slice, page, pagesCount, perPage, 100);
        return Ok(response);    
    }
}