using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
  // Attributes
  private int _count;
  private List<string> _prompts;



  // Constructors
  public ListingActivity()
  {
    _name = "Listing";
    _description = "This activity will help you reflect on the good things in your life by listing items.";
    _prompts = new List<string>
    {
      "What are the people you are thankful for?",
      "What are personal strengths of yours?",
      "Who are some people who have helped you this week?",
      "Who are some of your heroes?",
      "What are some things you find funny?",
      "What are some subjects you find interesting?"
    };
  }



  // Methods
  public void Run()
  {
    DisplayStartingMessage();
    GetRandomPrompt();

    Console.WriteLine("\nYou may begin in...");
    ShowCountDown(5);

    List<string> items = GetListFromUser();
    _count = items.Count;

    Console.WriteLine($"\nYou listed {_count} items!");
    DisplayEndingMessage();
  }


  public void GetRandomPrompt()
  {
    Random rand = new Random();
    Console.WriteLine();
    Console.WriteLine(_prompts[rand.Next(_prompts.Count())]);
  }


  public List<string> GetListFromUser()
  {
    List<string> items = new List<string>();
    DateTime endtime = DateTime.Now.AddSeconds(_duration);

    Console.WriteLine("\nStart listing items:");

    while (DateTime.Now < endtime)
    {
      Console.Write("> ");
      items.Add(Console.ReadLine());
    }

    return items;
  }
}