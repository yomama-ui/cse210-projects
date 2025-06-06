using System;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessTracker tracker = new MindfulnessTracker();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breath = new BreathingActivity();
                breath.Run();
                tracker.Increment("Breathing");
            }
            else if (choice == "2")
            {
                ReflectionActivity reflect = new ReflectionActivity();
                reflect.Run();
                tracker.Increment("Reflection");
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                tracker.Increment("Listing");
            }
            else if (choice == "4")
            {
                tracker.ShowSummary();
                break;
            }
        }
    }
}
