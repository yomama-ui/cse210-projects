public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _targetCount = target;
        _currentCount = 0;
        _bonusPoints = bonus;
    }

    public override bool IsComplete => _currentCount >= _targetCount;

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (IsComplete)
                return Points + _bonusPoints;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] ({_currentCount}/{_targetCount})" : $"[ ] ({_currentCount}/{_targetCount})";
    }

    public override string Details()
    {
        return $"{GetStatus()} {Name} ({Description}) -- Bonus: {_bonusPoints}";
    }

    public override string Serialize()
    {
        return $"{base.Serialize()}|{_currentCount}|{_targetCount}|{_bonusPoints}";
    }

    public static ChecklistGoal Deserialize(string[] parts)
    {
        var g = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                  int.Parse(parts[5]), int.Parse(parts[6]));
        g._currentCount = int.Parse(parts[4]);
        return g;
    }
}
