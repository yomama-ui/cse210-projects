using System;

class Program
{
    static void Main()
    {
        var manager = new GoalManager();
        const string saveFile = "goals.txt";
        manager.Load(saveFile);

        while (true)
        {
            Console.WriteLine($"\nScore: {manager.TotalScore}  Level: {manager.Level}");
            Console.WriteLine("1. Create Goal  2. List Goals  3. Record Event  4. Save & Quit");
            Console.Write("Choice: ");
            switch (Console.ReadLine())
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.ListGoals();
                    Console.Write("Which goal to record? ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                        manager.Record(idx - 1);
                    break;
                case "4":
                    manager.Save(saveFile);
                    return;
            }
        }
    }

    static void CreateGoal(GoalManager mgr)
    {
        Console.Write("Type (simple, eternal, checklist): ");
        string type = Console.ReadLine()?.ToLower();
        Console.Write("Name: "); var name = Console.ReadLine();
        Console.Write("Description: "); var desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "simple":
                mgr.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "eternal":
                mgr.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "checklist":
                Console.Write("Target count: "); int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: "); int bonus = int.Parse(Console.ReadLine());
                mgr.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Unknown type.");
                break;
        }
    }
}
