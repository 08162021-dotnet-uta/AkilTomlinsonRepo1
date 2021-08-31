using System;

namespace _4_MethodsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //1
      string name = GetName();
      GreetFriend(name);

      //2
      double result1 = GetNumber();
      double result2 = GetNumber();
      int action1 = GetAction();
      double result3 = DoAction(result1, result2, action1);

      System.Console.WriteLine($"The result of your mathematical operation is {result3}.");
    }

    public static string GetName()
    {
      //throw new NotImplementedException("GetName() is not implemented yet0");
      string name = Console.ReadLine();
      return name;

    }

    public static string GreetFriend(string name)
    {
      //throw new NotImplementedException("GreetFriend() is not implemented yet");
      return ($"Hello, {name}. You are my friend.");
    }

    public static double GetNumber()
    {
      //throw new NotImplementedException("GetNumber() is not implemented yet");
      string s = Console.ReadLine();
      double number;
      bool b = double.TryParse(s, out number);
      return number;
    }

    public static int GetAction()
    {
      //throw new NotImplementedException("GetAction() is not implemented yet");
      int selection;
      Console.WriteLine("Choose a mathematical operator: ");
      Console.WriteLine("1. Add \n 2. Subtract \n 3. Multiply \n 4. Divide");
    }

    public static double DoAction(double x, double y, int action)
    {
      throw new NotImplementedException("DoAction() is not implemented yet");
    }
  }
}
