/*
Eternal Quest Program

Brandon Arroyo
2/12/2026


Exceeding Requirements: For the goal parent class, I added a method to get the points of the user. In addition, for a checklist goal, I added bonus points if the user does a goal a specific number of times. This is also present in the eternal goal, which also gives a bonus if the user completes a spcific number of a goals.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}