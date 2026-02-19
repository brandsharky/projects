using System;

public class BreathingActivity : Activity
{
  // Attributes



  // Constructors
  public BreathingActivity()
  {
    this._name = "Breathing";
    this._description = "This activity will help you relax by walking you through breathing in and out slowly.";
  }



  // Methods
  public void Run()
  {
    DisplayStartingMessage();

    DateTime endtime = DateTime.Now.AddSeconds(_duration);

    while (DateTime.Now < endtime)
    {
      Console.Write("\nBreathe in... ");
      ShowCountDown(4);

      Console.Write("\nBreathe out... ");
      ShowCountDown(6);
    }

    DisplayEndingMessage();
  }
}