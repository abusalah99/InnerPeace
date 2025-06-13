using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnerPeace.Entities;

public class Education : BaseEntity
{
    public string Degree { get; set; } = null!;
    public string University { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    [JsonIgnore]
    public virtual ICollection<Doctor>? Doctors { get; set; }
}