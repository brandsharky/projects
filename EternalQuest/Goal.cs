using System;

public abstract class Goal
{
  // Attributes
  protected string _shortName;
  protected string _description;
  protected int _points;



  // Constructors
  public Goal(string name, string description, int points)
  {
    this._shortName = name;
    this._description = description;
    this._points = points;
  }



  // Methods
  public abstract void RecordEvent();


  public abstract bool IsComplete();


  public abstract string GetDetailsString();


  public abstract string GetStringRepresentation();


  public virtual int GetPoints()
  {
    return _points;
  }
}