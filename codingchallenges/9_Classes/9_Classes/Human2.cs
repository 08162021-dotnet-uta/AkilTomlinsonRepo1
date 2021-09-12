using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
  internal class Human2
  {
    private string lastName = "Smyth";
    private string firstName = "Pat";

    private string eyeColor;
    private int age;
    private int size;

    public Human2()
    {

    }


    public Human2(string firstName, string lastName)
    {
      this.firstName = firstName;
      this.lastName = lastName;
    }

    public Human2(string firstName, string lastName, string eyeColor, int age)
    {
      this.firstName = firstName;
      this.lastName = lastName;
      this.eyeColor = eyeColor;
      this.age = age;
    }

    public Human2(string firstName, string lastName, int age)
    {
      this.firstName = firstName;
      this.lastName = lastName;
      this.age = age;
    }

    public Human2(string firstName, string lastName, string eyeColor)
    {
      this.firstName = firstName;
      this.lastName = lastName;
      this.eyeColor = eyeColor;
    }

    public string AboutMe()
    {
      return $"My name is {this.firstName} {this.lastName}.";
    }

    public string AboutMe2()
    {
      if (eyeColor == null && age == 0)
      {
        return $"My name is {this.firstName} {this.lastName}.";
      }
      else if (this.age == 0)
      {
        return $"My name is {this.firstName} {this.lastName}. My eye color is {this.eyeColor}.";
      }
      else if (this.eyeColor == null)
      {
        return $"My name is {this.firstName} {this.lastName}. My age is {this.age}.";
      }
      else
      {
        return $"My name is {this.firstName} {this.lastName}. My age is {this.age}. My eye color is {this.eyeColor}.";
      }
    }

    public int Weight
    {
      get
      {
        return size;
      }
      set
      {
        if (value < 0 || value > 400)
        {
          size = 0;
        }
        else size = value;
      }
    }

  }//EoC
}//EoF