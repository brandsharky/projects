using System;
using System.Collections.Generic;

class Scripture
{
  // Attributes
  private Reference _reference;
  private List<Word> _words;



  // Constructors
  public Scripture(Reference reference, string text)
  {
    this._reference = reference;
    this._words = new List<Word>();

    string[] splitWords = text.Split(" ");
    foreach (string word in splitWords)
    {
      _words.Add(new Word(word));
    }
  }



  // Methods
  public void HideRandomWords(int numberToHide)
  {
    Random random = new Random();

    List<Word> visibleWords = new List<Word>();

    foreach (Word word in _words)
    {
      if (!word.IsHidden())
      {
        visibleWords.Add(word);
      }
    }

    for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
    {
      int index = random.Next(visibleWords.Count);
      visibleWords[index].Hide();

      visibleWords.RemoveAt(index);
    }
  }


  public string GetDisplayText()
  {
    string result = _reference.GetDisplayText() + "\n\n";

    foreach (Word word in _words)
    {
      result += word.GetDisplayText() + " ";
    }

    return result.Trim();
  }

  public bool IsCompletelyHidden()
  {
    foreach (Word word in _words)
    {
      if (!word.IsHidden())
      {
        return false;
      }
    }

    return true;
  }
}