using System.Text.Json.Serialization;

namespace InnerPeace.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? ImagePath { get; set; } 
    public string Phone { get; set; } = null!;
    public DateTime Birthday { get; set; } 
    public bool IsMale { get; set; }
    public virtual ICollection<MoodTracking>? Moods { get; set; }
    public virtual ICollection<Rating>? Ratings { get; set; }
    [JsonIgnore]
    public virtual ICollection<Session>? Sessions { get; set; }
}