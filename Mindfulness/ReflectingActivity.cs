using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
  // Attributes
  List<string> _prompts;
  List<string> _questions;



  // Constructors
  public ReflectingActivity()
  {
    this._name = "Reflecting";
    this._description = "This activity will help you reflect on times when you have shown strength and resilience.";

    _prompts = new List<string>
    {
      "Think of a time when you stood up for someone else.",
      "Think of a time when you did something really difficult.",
      "Think of a time when you helped someone in need.",
      "Think of a time when you did something truly selfless."
    };
    _questions = new List<string>
    {
      "Why was this experience meaningful to you?",
      "How did you feel when it was complete?",
      "What did you learn about yourself?",
      "How can you apply this experience in the future?"
    };
  }



  // Methods
  public void Run()
  {
    DisplayStartingMessage();
    DisplayPrompt();
    DisplayQuestions();
    DisplayEndingMessage();
  }


  public string GetRandomPrompt()
  {
    Random rand = new Random();
    return _prompts[rand.Next(_prompts.Count)];
  }


  public string GetRandomQuestion()
  {
    Random rand = new Random();
    return _questions[rand.Next(_questions.Count)];
  }


  public void DisplayPrompt()
  {
    Console.WriteLine();
    Console.WriteLine(GetRandomPrompt());
    ShowSpinner(5);
  }


  public void DisplayQuestions()
  {
    DateTime endtime = DateTime.Now.AddSeconds(_duration);

    while (DateTime.Now < endtime)
    {
      Console.WriteLine($"\n{GetRandomQuestion()}");
      ShowSpinner(5);
    }
  }
}