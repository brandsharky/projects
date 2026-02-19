using System;
using System.Threading;


public class Activity
{
  // Attributes
  protected string _name;
  protected string _description;
  protected int _duration;



  // Constructors
  public Activity()
  {
    this._name = "";
    this._description = "";
    this._duration = 0;
  }



  // Methods
  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Welcome to the {_name} Activity.");
    Console.WriteLine();
    Console.WriteLine(_description);
    Console.WriteLine();
    Console.Write("Enter the duration in seconds: ");
    _duration = int.Parse(Console.ReadLine());

    Console.WriteLine("\nPrepare to begin...");
    ShowSpinner(3);
  }


  public void DisplayEndingMessage()
  {
    Console.WriteLine("\nWell done!");
    ShowSpinner(2);
    Console.WriteLine($"You completed the {_name} Activity for {_duration} seconds.");
    ShowSpinner(3);
  }


  public void ShowSpinner(int seconds)
  {
    DateTime endtime = DateTime.Now.AddSeconds(seconds);
    string[] spinner = {"|", "/", "-", "\\"};
    int index = 0;

    while (DateTime.Now < endtime)
    {
      Console.Write(spinner[index]);
      Thread.Sleep(250);
      Console.Write("\b \b");
      index = (index + 1) % spinner.Length;
    }
  }


  public void ShowCountDown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write(i);
      Thread.Sleep(1000);
      Console.Write("\b \b");
    }
  }
}