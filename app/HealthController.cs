using Microsoft.AspNetCore.Mvc;

namespace Homework03;

[Route("api/health")]
[ApiController]
public class HealthController
{
    [HttpGet]
    public IActionResult Health()
    {
        return new OkResult();
    }
}