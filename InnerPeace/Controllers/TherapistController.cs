using InnerPeace.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InnerPeace.Controllers;

[Route("therapist")]
public class TherapistController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var doctors = await context.Doctors.ToListAsync();
        var languages = await context.Languages.ToListAsync();
        var educations = await context.Educations.ToListAsync();
        var specializations = await context.Specializations.ToListAsync();
        var durations = await context.SessionDurations.ToListAsync();

        TherapistViewModel model = new()
        {
            Doctor = doctors,
            Specializations = specializations,
            Durations = durations,
            Educations = educations,
            Languages = languages
        };

        return View(model);
    }
}