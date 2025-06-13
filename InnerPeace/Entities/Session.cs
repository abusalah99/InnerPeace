namespace InnerPeace.Entities;

public class Session : BaseEntity
{
    public double Price { get; set; }
    public DateTime DateTime { get; set; }
    public string? Prescription { get; set; }
    public string? Note { get; set; }
    public Guid DurationId { get; set; }
    public virtual SessionDuration Duration { get; set; } = null!;
    public Guid RatingId { get; set; }
    public virtual Rating? Rating { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public Guid DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } = null!;
}