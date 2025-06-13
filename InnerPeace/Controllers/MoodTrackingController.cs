namespace InnerPeace.Controllers;

[Route("mood-tracking")]
public class MoodTrackingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}