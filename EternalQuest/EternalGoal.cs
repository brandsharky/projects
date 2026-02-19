using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
  // Attributes



  // Constructors
  public EternalGoal(string name, string description, int points) : base(name, description, points)
  {

  }



  // Methods
  public override void RecordEvent()
  {
    // Never Completes
  }


  public override bool IsComplete()
  {
    return false;
  }


  public override string GetDetailsString()
  {
    return $"[ ] {_shortName} ({_description})";
  }


  public override string GetStringRepresentation()
  {
    return $"EternalGoal|{_shortName}|{_description}|{_points}";
  }
}