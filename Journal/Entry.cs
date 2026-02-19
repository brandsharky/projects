using System;

public class Entry
{
  public string _date;
  public string _promptText;
  public string _entryText;
  public string _mood;
  public int _wordCount;


  public Entry(string date, string promptText, string entryText, string mood)
  {
    this._date = date;
    this._promptText = promptText;
    this._entryText = entryText;
    this._mood = mood;
    this._wordCount = entryText.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
  }


  public void Display()
  {
    Console.WriteLine($"Date: {_date}");
    Console.WriteLine($"Mood: {_mood}");
    Console.WriteLine($"Prompt: {_promptText}");
    Console.WriteLine($"Entry: {_entryText}");
    Console.WriteLine($"Word Count: {_wordCount}");
  }

  public string toFileString()
  {
    return $"{_date}|{_mood}|{_wordCount}|{_promptText}|{_entryText}";
  }

  public static Entry fromFileString(string line)
  {
    string[] parts = line.Split("|");

    return new Entry(parts[0], parts[3], parts[4], parts[1]);
  }
}


