using System;
using System.Collections.Generic;

class MindfulnessTracker
{
    private Dictionary<string, int> _sessions = new Dictionary<string, int>();

    public void Increment(string activityName)
    {
        if (_sessions.ContainsKey(activityName))
        {
            _sessions[activityName]++;
        }
        else
        {
            _sessions[activityName] = 1;
        }
    }

    public void ShowSummary()
    {
        Console.WriteLine("Session Summary:");
        foreach (var entry in _sessions)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
    }
}
