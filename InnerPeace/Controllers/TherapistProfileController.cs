namespace InnerPeace.Controllers;

[Route("therapist-profile")]
public class TherapistProfileController : Controller
{
    [Route("{id:guid}")]
    public IActionResult Index(Guid id)
        => View();
}