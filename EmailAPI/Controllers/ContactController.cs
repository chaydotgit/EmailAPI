using Microsoft.AspNetCore.Mvc;
namespace EmailAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IConfiguration _config;
    public ContactController(IConfiguration config)
    {
        _config= config;
    }

    [HttpGet("email")] // api/contact/email
    public ActionResult<EmailResponse> GetEmailAddress()
    {
        return new EmailResponse() { Email = _config["Email"] };
    }
}

public class EmailResponse
{
    public string Email { get; set; } = string.Empty;

    public DateTime LastUpdatedDate { get; set; } = new DateTime(2023, 1, 30, 0, 0, 0, DateTimeKind.Utc);
}