using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
  public List<Entry> _entries;


  public Journal()
  {
    this._entries = new List<Entry>();
  }


  public void AddEntry(Entry entry)
  {
    _entries.Add(entry);
  }

  public void DisplayEntries()
  {
    foreach (Entry entry in _entries)
    {
      entry.Display();
      Console.WriteLine();
    }
  }

  public void SaveToFile(string filename)
  {
    using (StreamWriter writer = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        writer.WriteLine(entry.toFileString());
      }
    }
  }

  public void LoadFromFile(string filename)
  {
    _entries.Clear();

    string[] lines = File.ReadAllLines(filename);
    foreach (string line in lines)
    {
      _entries.Add(Entry.fromFileString(line));
    }
  }
}


