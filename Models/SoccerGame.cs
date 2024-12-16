namespace StrikerForge.models;

public class SoccerGame
{
    public int Id { get; set; }
    public required int HomeTeam { get; set; }
    public required int AwayTeam { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public int Matchday { get; set; }
}