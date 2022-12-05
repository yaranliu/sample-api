using ApiSampleNoAuth.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiSampleNoAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class AllController: ControllerBase
{
    private readonly Seed _seed;

    public AllController(Seed seed)
    {
        _seed = seed;
    }
    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> Get()
    {
        Thread.Sleep(1500);
        return Ok(_seed.GetPeople());    
    }
}