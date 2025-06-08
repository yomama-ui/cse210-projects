using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract bool IsComplete { get; }
    public abstract int RecordEvent(); // returns points earned
    public abstract string GetStatus(); // e.g., "[X]" or "[ ]"

    public virtual string Details()
    {
        return $"{GetStatus()} {Name} ({Description})";
    }

    public virtual string Serialize()
    {
        return $"{GetType().Name}|{Name}|{Description}|{Points}";
    }
}
