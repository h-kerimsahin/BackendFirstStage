using BackendFirstStage.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BackendFirstStage.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorTestController : ControllerBase
{
    // NotFoundException test etmek için
    [HttpGet("not-found")]
    public ActionResult TestNotFoundException()
    {
        throw new NotFoundException("Test için oluşturulmuş NotFoundException");
    }

    // ValidationException test etmek için
    [HttpGet("validation-error")]
    public ActionResult TestValidationException()
    {
        throw new ValidationException("Test için oluşturulmuş ValidationException");
    }

    // Genel Exception test etmek için
    [HttpGet("general-error")]
    public ActionResult TestGeneralException()
    {
        throw new Exception("Test için oluşturulmuş genel Exception");
    }

    // DivideByZeroException test etmek için
    [HttpGet("divide-by-zero")]
    public ActionResult TestDivideByZeroException()
    {
        int x = 10,y = 0;
        int result = x / y; // Bu exception fırlatacak
        return Ok(result);
    }

    // ArgumentNullException test etmek için
    [HttpGet("argument-null")]
    public ActionResult TestArgumentNullException()
    {
        string? testString = null;
        if (testString == null)
        {
            throw new ArgumentNullException(nameof(testString), "Test için oluşturulmuş ArgumentNullException");
        }
        return Ok(testString);
    }
}
