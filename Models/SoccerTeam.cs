namespace StrikerForge.models;

public class SoccerTeam
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Stadium { get; set; }
    public int Points { get; set; } = 0;
    public int GoalsScored { get; set; } = 0;
    public int GoalsConceded { get; set; } = 0;
}
