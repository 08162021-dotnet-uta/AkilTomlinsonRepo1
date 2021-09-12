using System;

namespace _9_ClassesChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Human john = new Human();
      Human kate = new Human("Kate", "Mara");

      john.AboutMe();
      kate.AboutMe();

      Human2 jack = new Human2("Jack", "Ryan", "Blue");
      Human2 jason = new Human2("Jason", "Bourne", 32);
      Human2 jimmy = new Human2("Jimmy", "Johns", "Green", 70);

      jack.AboutMe2();
      jason.AboutMe2();
      jimmy.AboutMe2();

      jimmy.Weight = 180;
      jimmy.Weight = 1000;


    }
  }
}
