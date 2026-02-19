using System;

public class SimpleGoal : Goal
{
  // Attributes
  private bool _isComplete;



  // Constructors
  public SimpleGoal(string name, string description, int points, bool isComplete=false) : base(name, description, points)
  {
    this._isComplete = isComplete;
  }



  // Methods
  public override void RecordEvent()
  {
    if (!_isComplete)
    {
      _isComplete = true;
    }
  }


  public override bool IsComplete()
  {
    return _isComplete;
  }


  public override string GetDetailsString()
  {
    string checkBox = _isComplete ? "[X]" : "[ ]";
    return $"{checkBox} {_shortName} ({_description})";
  }


  public override string GetStringRepresentation()
  {
    return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
  }
}