"""
taskforce_one.py

Brandon Arroyo
11/28/2025
"""

import csv
import os
import random
from datetime import date, datetime
from typing import List, Dict

FILENAME = "tasks.csv"
HEADERS = ["Date", "Time", "Task", "Duration"] # CSV column order



# -------------------------
# MAIN PROGRAM
# -------------------------
def main():
  """
  Main Program/Interactive Loop
  """
  ensure_file_has_header(FILENAME)

  print("\n|=======================================================|")
  print("|==================== Taskforce One ====================|")
  print("|==================== Daily Planner ====================|")
  print("|=======================================================|\n\n")


  print(f"Today is {format_date_for_display(date.today())}")
  print("Today's tasks:")
  todays_tasks = check_date(date.today().month, date.today().day, date.today().year, FILENAME)
  for task in todays_tasks:
    print(task)


  while True:
    print("\n\nWhat would you like to do?\n")
    print("1) View all tasks")
    print("2) Add a task")
    print("3) Edit tasks")
    print("4) Remove a task")
    print("5) Check a date for tasks")
    print("6) Exit")

    try:
      user_choice = ask_int("Enter choice (1-6): ", 1, 6)
    except KeyboardInterrupt:
      print("\nInterrupted. Exiting.")
      break

    print()
    if user_choice == 1:
      print("Showing taks for this year and next year:")
      tasks = see_all_tasks(FILENAME)
      for task in tasks:
        print(task)


    elif user_choice == 2:
      month, day, year = ask_date_components()
      time_n = ask_time_string()
      duration = ask_duration_minutes()
      task_text = input("Enter task: ").strip()

      try:
        add_task(month, day, year, time_n, duration, task_text, FILENAME)
        print("Task added!")
      except Exception as error:
        print("Failed to add task: ", error)


    elif user_choice == 3:
      rows = read_all_rows(FILENAME)
      if not rows:
        print("Not tasks to edit.")
        continue

      print("Showing tasks:")
      for index, row in enumerate(rows, start=1):
        print(f"{index}: @ {row.get("Time")}: {row.get("Task")} on {row.get("Date")} ({row.get("Duration")})")

        which = ask_int("Which task would you like to change (number): ", 1, len(rows))
        print("Enter the NEW values for the selected task: ")
        month, day, year = ask_date_components()
        time_n = ask_time_string()
        duration = ask_duration_minutes()
        task_text = input("Enter new task: ").strip()

        success = edit_task(which, month, day, year, time_n, duration, task_text, FILENAME)
        if success:
          print("Task has sucessfully been changed.")
        else:
          print("Failed to edit task. Please check the index and try again.")


    elif user_choice == 4:
      rows = read_all_rows(FILENAME)
      if not rows:
        print("No tasks to delete.")
        continue

      print("Showing tasks:")
      for index, row in enumerate(rows, start=1):
        print(f"{index}: @ {row.get("Time")}: {row.get("Task")} on {row.get("Date")} ({row.get("Duration")})")

      which = ask_int("Which task would you like to delete (enter number): ", 1, len(rows))

      success = delete_task(which - 1, FILENAME)
      if success:
        print("Task deleted.")
      else:
        print("Failed to delete task. Please check the index and try again.")


    elif user_choice == 5:
      print("Please enter the date you want to check:")
      month = ask_int("Month: ", 1, 12)
      day = ask_int("Day: ", 1, 31)
      year = ask_int("Year: ", 1, 9999)

      try:
        results = check_date(month, day, year, FILENAME)
        for result in results:
          print(result)
      except ValueError:
        print("That date is invalid.")


    elif user_choice == 6:
      break
  end_message()



# -------------------------
# HELPER FUNCTIONS
# -------------------------

def ensure_file_has_header(filename:str=FILENAME):
  """
  Ensures the CSV file exists and has a header row.
  Creates the file and writes headers if it needs it.

  :param filename: name of file we are checking
  :type filename: str
  """
  if not os.path.exists(filename) or os.path.getsize(filename) == 0:
    with open(filename, "w", newline="") as file:
      writer = csv.writer(file)
      writer.writerow(HEADERS)


def format_date_for_display(date:date):
  """
  Accepts today's date and changes it from YYYY-MM-DD to MM/DD/YYYY

  :param date: accepts a date in default format
  :type date: date
  """
  return f"{date.month}/{date.day}/{date.year}"


def parse_date_from_components(month:int, day:int, year:int):
  """
  Accpets values month, day, and year as integers and then return them formatted in a date object as YYYY-MM-DD

  :param month: integer of month
  :type month: int
  :param day: integer of day
  :type day: int
  :param year: integer of year
  :type year: int
  """
  return date(year, month, day)


def read_all_rows(filename:str):
  """
  Read the CSV file and returns a list of dictionaries (one per row).
  If the file is empty or doesn't exist, then it just returns an empty list.
  """
  if not os.path.exists(filename) or os.path.getsize(filename) == 0:
    return []

  with open(filename, "r", newline="") as file:
    reader = csv.DictReader(file)
    return list(reader)


def parse_time_string(time_str:str):
  """
  Parse user-provided time strings (like '7:30 pm', '7pm', '19:20') and return a normalized display string in the form 'h:mm AM/PM' (e.g. '7:30 PM').
  Accepts:
    - 12-hour with AM/PM (various whitespace/casing)
    - 24-hour 'HH:MM'
  Raises ValueError if parsing fails.

  :param time_str: Description
  :type time_str: str
  """
  time = time_str.strip()

  # try 12-hour formats
  twelve_hour_formats = ["%I:%M %p", "%I %p", "%I:%M%p", "%I%p"]
  for format in twelve_hour_formats:
    try:
      t = datetime.strptime(time.upper(), format)
      return t.strftime("%I:%M %p").lstrip("0") # e.g. '07:05 PM' -> '7:05 PM'

    except ValueError:
      continue

  try:
    t = datetime.strptime(time, "%H:%M")
    return t.strftime("%I:%M %p").lstrip("0")
  except ValueError:
    raise ValueError(f"Time '{time_str} is not in a recognized format.")



  # try 24-hour formats


def minutes_to_duration_str(total_minutes:int):
  """
  Converts minutes(int) into a clearer string (X hr(s) Y min(s))

  :param total_minutes: The total minutes of the task
  :type total_minutes: int
  """
  hrs = total_minutes // 60
  mins = total_minutes % 60
  return f"{hrs} hr(s) {mins} min(s)"


def write_all_rows(filename:str, rows:List[Dict[str, str]]):
  """
  Overwrite the CSV with the provided rows and ensure that there are headers.

  :param filename: "tasks.csv"
  :type filename: str
  :param rows: list of rows and all their respective values
  :type rows: List[Dict[str, str]]
  """
  ensure_file_has_header(filename)
  with open(filename, "w", newline="") as file:
    writer = csv.DictWriter(file, fieldnames=HEADERS)
    writer.writeheader()
    writer.writerows(rows)



# -------------------------
# Core functions of program
# -------------------------
# user_choice == 1
def see_all_tasks(filename:str=FILENAME):
  """
  Returns a list of task strings for tasks whose date starts with this year or next year.

  :param filename: "tasks.csv"
  :type filename: str
  """
  today = date.today()
  this_year = str(today.year)
  next_year = str(today.year + 1)

  tasks_to_display = []
  rows = read_all_rows(filename)

  for row in rows:
    task_date = row.get("Date", "")

    if task_date.startswith(this_year) or task_date.startswith(next_year):
      tasks_to_display.append(f"{row.get("Date")} @ {row.get("Time")}: {row.get("Task")} ({row.get("Duration")})")

  if not tasks_to_display:
    tasks_to_display.append("No tasks found!")

  return tasks_to_display


# user_choice == 2
def add_task(month:int, day:int, year:int, time_str:str, duration_mins:int, task_text:str, filename:str=FILENAME):
  """
  Adds a new task to the CSV file. Validates and makes clear date/time/duration. Stores the Date as 'YYYY-MM-DD' and ISO format as 'H:MM AM/PM' and time as to make them clear to understand.

  :param month: Month to add to row
  :type month: int
  :param day: Day to add to row
  :type day: int
  :param year: Year to add to row
  :type year: int
  :param time_str: user's desired time of task
  :type time_str: str
  :param duration_mins: duration of task in minutes
  :type duration_mins: int
  :param task_text: Task description
  :type task_text: str
  :param filename: file to add row to
  :type filename: str
  """
  date = parse_date_from_components(month, day, year)
  normal_date = date.isoformat() # YYYY-MM-DD
  normal_time = parse_time_string(time_str)
  duration_str = minutes_to_duration_str(duration_mins)
  task_text = task_text.strip()

  ensure_file_has_header(filename)
  with open(filename, "a", newline="") as file:
    writer = csv.DictWriter(file, fieldnames=HEADERS)
    writer.writerow({
      "Date": normal_date,
      "Time": normal_time,
      "Task": task_text,
      "Duration": duration_str,
    })


# user_choice == 3
def edit_task(user_row_index_1:int, month:int, day:int, year:int, time_str:str, duration_mins:int, task_text:str, filename:str=FILENAME):
  """
  Edit a specific row and return True if the edit was successful and False if otherwise

  :param user_row_index_1: User's choice of what row to change
  :type user_row_index_1: int
  :param month: Month to be changed to
  :type month: int
  :param day: Day to be changed to
  :type day: int
  :param year: Year to be changed to
  :type year: int
  :param time_str: Time to be changed to
  :type time_str: str
  :param duration_mins: Minutes to be changed to
  :type duration_mins: int
  :param task_text: New task description
  :type task_text: str
  :param filename: default filename which is "tasks.csv"
  :type filename: str
  """
  rows = read_all_rows(FILENAME)
  if not rows:
    return False

  index = user_row_index_1 - 1
  if index < 0 or index > len(rows):
    return False

  date = parse_date_from_components(month, day, year) # turn date componenents into date
  rows[index] = {
    "Date": date.isoformat(),
    "Time": parse_time_string(time_str),
    "Task": task_text.strip(),
    "Duration": minutes_to_duration_str(duration_mins)
  }

  write_all_rows(filename, rows)
  return True


# user_choice == 4
def delete_task(index:int, filename:str=FILENAME):
  """
  Delete a row and return true if successful and false if index is invalid.

  :param index: index of the row that the user wants to delete.
  :type index: int
  :param filename: "tasks.csv"
  :type filename: str
  """
  rows = read_all_rows(FILENAME)
  if not rows:
    return False

  if index < 0 or index >= len(rows):
    return False

  del rows[index]
  write_all_rows(filename, rows)
  return True


# user_choice == 5
def check_date(month:int, day:int, year:int, filename:str=FILENAME):
  """
  returns a list of all the tasks for a specific date (month, day, year)

  :param month: Month of date wanted to be checked
  :type month: int
  :param day: Day of date wanted to be checked
  :type day: int
  :param year: Year of date wanted to be checked
  :type year: int
  :param filename: CSV file program uses with is set to default to "tasks.csv"
  :type filename: str
  """
  date = parse_date_from_components(month, day, year)
  default_date_format = date.isoformat()
  rows = read_all_rows(filename)
  matched = []

  for row in rows:
    if row.get("Date") == default_date_format:
      matched.append(f"@ {row.get("Time")}: {row.get("Task")} ({row.get("Duration")})")

  if not matched:
    matched.append("No tasks found!")

  return matched


# user_choice == 6
def end_message():
  quotes = {
    "Mahatma Gandhi": "Live as if you were to die tomorrow. Learn as if you were to live forever.",
    "Thomas A Edison": "I have not failed. I've just found 10,000 ways that won't work.",
    "Pablo Picasso": "Everything you can imagine is real.",
    "Theodore Roosevelt": "Do what you can, with what you have, where you are.",
    "Winston Chuchill": "Success is not final, failure is not fatal: it is the courage to continue that counts.",
    "Walt Disney": "All our dreams can come true if we have the courage to pursue them.",
    "Helen Keller": "Never bend your head. Always hold it high. Look the world straight in the eye.",
    "Marilyn Monroe": "Imperfection is beauty, madness is genius and it’s better to be absolutely ridiculous than absolutely boring.",
    "Eleanor Roosevelt": "Remember always that you have not only the right to be an individual; you have an obligation to be one. You cannot make any useful contribution in life unless you do this.",
    "Queen Elizabeth II": "It is often the small steps, not the giant leaps, that bring about the most lasting change."
  }
  author = random.choice(list(quotes))
  quote = quotes[author]

  print("\nThank you for using Taskforce One: Daily Planner. Remember:\n")
  print(f'"{quote}"')
  print(f"- {author}")
  print("\nHave a nice day!")



# -------------------------
# User input/validation
# -------------------------
def ask_int(prompt:str, min_val:int=None, max_val:int=None):
  """
  Creates an infinite loop that asks the user for an integer until they enter a valid one. Not required but it can make sure the number is within some bounds.

  :param prompt: The question that the program wants the user to enter.
  :type prompt: str
  :param min_val: The optional min value
  :type min_val: int
  :param max_val: The optional max value
  :type max_val: int
  """
  while True:
    answer = input(prompt).strip()

    try:
      value = int(answer)
    except ValueError:
      print("Please enter a valid number.")
      continue

    if (min_val is not None and value < min_val) or (max_val is not None and value > max_val):
      print(f"Please enter a number between {min_val} and {max_val}.")
      continue

    return value


def ask_date_components():
  """
  Ask user for month, day, year and return them as integers. Keeps prompting prompting until a valid date is provided.
  """
  while True:
    try:
      month = ask_int("Enter month of task: ", 1, 12)
      day = ask_int("Enter day of task: ", 1, 31)
      year = ask_int("Enter year of task: ", 1, 9999)

      # validates by trying to turn input into a date object
      parse_date_from_components(month, day, year)
      return month, day, year

    except ValueError:
      print("That date is not valid. Please try again.")


def ask_time_string():
  """
  Repeatedly ask the user for a time string and return the time in a clear format. It retries until it is able.
  """
  while True:
    time = input("Enter the time of task (ex: 7:30 pm or 19:30): ").strip()
    try:
      return parse_time_string(time)
    except ValueError as error:
      print(str(error))
      print("Please try again.")


def ask_duration_minutes():
  """
  Prompts the user for a duration in minutes (integer >= 0)
  """
  return ask_int("Enter task duration (minutes): ", 0, None)



if __name__ == "__main__": main()