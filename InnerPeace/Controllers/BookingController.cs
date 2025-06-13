namespace InnerPeace.Controllers;

[Route("booking")]
public class BookingController : Controller
{
    [Route("{id:guid}")]
    public IActionResult Index()
        => View();
}