namespace InnerPeace.ApiController;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] AppointmentStatus Tab)
    {
        return Ok(new List<object>
        {
            new
            {
                Id = 1,
                Type = "consultations",
                TherapistName = "Dr Bahaa mahmoud",
                TherapistTitle = "Psychiatrist",
                Date = "2025-03-06",
                Time = "04:57 PM",
                Duration = "60 Min",
                Status = "Completed",
                Image = "bahaa.webp",
                Prescription = "Antidepressants - Take once daily before bed",
                Notes = "Follow-up required in 2 weeks"
            }
        });
    }
}

public enum AppointmentStatus
{
    Current = 0,
    Previous = 1
}