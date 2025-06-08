public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete => _isComplete;

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => _isComplete ? "[X]" : "[ ]";

    public override string Serialize()
    {
        return $"{base.Serialize()}|{_isComplete}";
    }

    public static SimpleGoal Deserialize(string[] parts)
    {
        var g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
        g._isComplete = bool.Parse(parts[4]);
        return g;
    }
}
