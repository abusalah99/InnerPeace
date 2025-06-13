namespace InnerPeace.Controllers;

[Route("find-therapist")]
public class FindTherapistController : Controller
{
    public IActionResult Index()
        => View();
}