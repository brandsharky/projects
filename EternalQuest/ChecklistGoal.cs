using System;

public class ChecklistGoal : Goal
{
  // Attributes
  private int _amountCompleted;
  private int _target;
  private int _bonus;



  // Constructors
  public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted=0) : base(name, description, points)
  {
    this._target = target;
    this._bonus = bonus;
    this._amountCompleted = amountCompleted;
  }



  // Methods
  public override void RecordEvent()
  {
    if (_amountCompleted < _target)
    {
      _amountCompleted++;
    }
  }


  public override bool IsComplete()
  {
    return _amountCompleted >= _target;
  }


  public override string GetDetailsString()
  {
    string checkBox = IsComplete() ? "[X]" : "[ ]";
    return $"{checkBox} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
  }


  public override string GetStringRepresentation()
  {
    return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
  }


  public int GetBonus()
  {
    return _bonus;
  }


  public int GetAmountCompleted()
  {
    return _amountCompleted;
  }


  public int GetTarget()
  {
    return _target;
  }
}