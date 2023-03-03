using Microsoft.AspNetCore.Mvc;
namespace EmailAPI.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IConfiguration _config;
    public ContactController(IConfiguration config)
    {
        _config= config;
    }

    /// <summary>
    /// Returns Chayanne's email address and date the email address was last updated.
    /// </summary>
    /// <returns>An email address and last updated date</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/contact/email
    ///     {
    ///         "Email": "example@gmail.com",
    ///         "LastUpdatedDate": "date"
    ///     }
    ///     
    /// </remarks>
    /// <response code="200">Returns an email address and updated date</response>
    [HttpGet("email")] // api/contact/email
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmailResponse> GetEmailAddress()
    {
        return new EmailResponse() { Email = _config["Email"]! };
    }
}

public class EmailResponse
{
    public string Email { get; set; } = string.Empty;

    public DateTime LastUpdatedDate { get; set; } = new DateTime(2023, 1, 30, 0, 0, 0, DateTimeKind.Utc);
}