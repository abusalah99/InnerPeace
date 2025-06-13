using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnerPeace.Entities;

public class DoctorCountry
{
    public Guid CountryId { get; set; }
    [JsonIgnore]
    public virtual Country Country { get; set; } = null!;
    public Guid DoctorId { get; set; }
    [JsonIgnore]
    public virtual Doctor Doctor { get; set; } = null!;
}