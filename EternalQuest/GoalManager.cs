using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
  // Attributes
  private List<Goal> _goals = new List<Goal>();
  private int _score;
  private int _totalEvents;



  // Constructors
  public GoalManager()
  {

  }



  // Methods
  public void Start()
  {
    int choice = -1;

    while (choice != 6)
    {
      DisplayPlayerInfo();

      Console.WriteLine("\nMenu Options:");
      Console.WriteLine("1. Create New Goal");
      Console.WriteLine("2. List Goals");
      Console.WriteLine("3. Save Goals");
      Console.WriteLine("4. Load Goals");
      Console.WriteLine("5. Record Event");
      Console.WriteLine("6. Quit");

      Console.Write("Select a choice: ");
      choice = int.Parse(Console.ReadLine());

      switch (choice)
      {
        case 1: CreateGoal(); break;
        case 2: ListGoalDetails(); break;
        case 3: SaveGoals(); break;
        case 4: LoadGoals(); break;
        case 5: RecordEvent(); break;
      }
    }
  }


  public void DisplayPlayerInfo()
  {
    int level = _score / 1000 + 1;
    string rank = GetRank(level);

    Console.WriteLine($"\nScore: {_score} | Level: {level} | Rank: {rank}");
  }


  private string GetRank(int level)
  {
    if (level >= 50) return "Servant";
    if (level >= 20) return "Master";
    if (level >= 10) return "Legend";
    if (level >= 5) return "Champion";
    if (level >= 3) return "Disciple";
    return "Novice";

  }


  public void ListGoalName()
  {

  }


  public void ListGoalDetails()
  {
    Console.WriteLine("\nGoals:");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
  }


  public void CreateGoal()
  {
    Console.WriteLine("\n1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");

    Console.Write("Select type: ");
    int type = int.Parse(Console.ReadLine());

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Description: ");
    string description = Console.ReadLine();

    Console.Write("Points: ");
    int points = int.Parse(Console.ReadLine());

    if (type == 1)
    {
      _goals.Add(new SimpleGoal(name, description, points));
    }
    else if (type == 2)
    {
      _goals.Add(new EternalGoal(name, description, points));
    }
    else
    {
      Console.Write("Target count: ");
      int target = int.Parse(Console.ReadLine());

      Console.Write("Bonus points: ");
      int bonus = int.Parse(Console.ReadLine());

      _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
    }
  }


  public void RecordEvent()
  {
    ListGoalDetails();

    Console.Write("Which goal did you accomplish? ");
    int index = int.Parse(Console.ReadLine()) - 1;

    Goal selectedGoal = _goals[index];

    int levelBefore = _score / 1000;

    selectedGoal.RecordEvent();
    _totalEvents++;

    int pointsEarned = selectedGoal.GetPoints();

    if (selectedGoal is SimpleGoal simple && simple.IsComplete())
    {
      pointsEarned = simple.GetPoints();
    }

    if (selectedGoal is ChecklistGoal checklist)
    {
      if (checklist.GetAmountCompleted() == checklist.GetTarget())
      {
        pointsEarned += checklist.GetBonus();
        Console.WriteLine("🎉 Checklist goal fully completed! Bonus awarded!");
      }
    }

    if (_totalEvents % 5 == 0)
    {
      pointsEarned += 100;
      Console.WriteLine("Milestone Bonus! +100 points!");
    }

    _score += pointsEarned;

    int levelAfter = _score / 1000;

    Console.WriteLine($"You earned {pointsEarned} points!");

    if (levelAfter > levelBefore)
    {
      Console.WriteLine("LEVEL UP!");
    }
  }


  public void SaveGoals()
  {
    using (StreamWriter writer = new StreamWriter("goals.txt"))
    {
      writer.WriteLine(_score);
      writer.WriteLine(_totalEvents);

      foreach (Goal goal in _goals)
      {
        writer.WriteLine(goal.GetStringRepresentation());
      }
    }

    Console.WriteLine("Goals saved.");
  }


  public void LoadGoals()
  {
    if (!File.Exists("goals.txt"))
    {
      Console.WriteLine("No save file found.");
      return;
    }

    string[] lines = File.ReadAllLines("goals.txt");

    _goals.Clear();

    _score = int.Parse(lines[0]);
    _totalEvents = int.Parse(lines[1]);

    for (int i = 2; i < lines.Length; i++)
    {
      string[] parts = lines[i].Split("|");

      if (parts[0] == "SimpleGoal")
      {
        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
      }
      else if (parts[0] == "EternalGoal")
      {
      _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
      }
      else if (parts[0] == "ChecklistGoal")
      {
        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])));
      }
    }

    Console.WriteLine("Goals loaded.");
  }
}