namespace InnerPeace.Controllers;

[Route("appointment")]
public class AppointmentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}