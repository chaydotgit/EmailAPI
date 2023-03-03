using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
    [HttpGet("email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmailResponse> GetEmailAddress()
    {
        return new EmailResponse() { Email = _config["Email"]! };
    }

    /// <summary>
    /// Returns Chayanne's cell phone number and date the email address was last updated.
    /// </summary>
    /// <returns>Cell phone number and last updated date</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/contact/cell
    ///     {
    ///         "Email": "000-000-000",
    ///         "LastUpdatedDate": "date"
    ///     }
    ///     
    /// </remarks>
    /// <response code="200">Returns cell phone number and updated date</response>
    [HttpGet("cell")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<CellResponse> GetCellNumber()
    {
        return new CellResponse() { CellNumber = _config["Cell"]! };
    }
}

public class EmailResponse
{
    public string Email { get; set; } = string.Empty;

    public DateTime LastUpdatedDate { get; set; } = new DateTime(2023, 1, 30, 0, 0, 0, DateTimeKind.Utc);
}

public class CellResponse
{
    public string CellNumber { get; set; } = string.Empty;

    public DateTime LastUpdatedDate { get; set; } = new DateTime(2021, 3, 3, 0, 0, 0, DateTimeKind.Utc);
}