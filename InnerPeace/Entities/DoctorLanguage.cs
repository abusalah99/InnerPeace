using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnerPeace.Entities;

public class DoctorLanguage
{
    public Guid LanguageId { get; set; }
    [JsonIgnore]
    public virtual Language Language { get; set; } = null!;
    public Guid DoctorId { get; set; }
    [JsonIgnore]
    public virtual Doctor Doctor { get; set; } = null!;
}