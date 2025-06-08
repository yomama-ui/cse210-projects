using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _totalScore = 0;
    private int _level = 1;

    public int TotalScore => _totalScore;
    public int Level => _level;

    public void AddGoal(Goal g) => _goals.Add(g);

    public void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].Details()}");
    }

    public void Record(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _totalScore += earned;
        Console.WriteLine($"Earned {earned} points! Total: {_totalScore}");

        int needed = Level * 500;
        if (_totalScore >= needed)
        {
            _level++;
            Console.WriteLine($"🎉 Level up! You are now level {_level}!");
        }
    }

    public void Save(string path)
    {
        using StreamWriter writer = new(path);
        writer.WriteLine(_totalScore);
        writer.WriteLine(_level);
        foreach (var g in _goals)
            writer.WriteLine(g.Serialize());
    }

    public void Load(string path)
    {
        if (!File.Exists(path)) return;
        _goals.Clear();
        var lines = File.ReadAllLines(path);
        _totalScore = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        for (int i = 2; i < lines.Length; i++)
        {
            var parts = lines[i].Split('|');
            Goal g = parts[0] switch
            {
                nameof(SimpleGoal) => SimpleGoal.Deserialize(parts),
                nameof(EternalGoal) => EternalGoal.Deserialize(parts),
                nameof(ChecklistGoal) => ChecklistGoal.Deserialize(parts),
                _ => null
            };
            if (g != null) _goals.Add(g);
        }
    }
}
