public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override bool IsComplete => false;

    public override int RecordEvent() => Points;

    public override string GetStatus() => "[∞]";

    public override string Serialize() => base.Serialize();

    public static EternalGoal Deserialize(string[] parts)
    {
        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}
