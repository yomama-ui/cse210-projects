using System;

public class Entry
{
    public string Id { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response)
    {
        Id = Guid.NewGuid().ToString();
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public string GetDisplayText()
    {
        return $"[{Date}] ({Id})\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string GetSaveText()
    {
        return $"{Id}|{Date}|{Prompt}|{Response}";
    }

    public static Entry FromSavedText(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[2], parts[3])
        {
            Id = parts[0],
            Date = parts[1]
        };
    }
}
