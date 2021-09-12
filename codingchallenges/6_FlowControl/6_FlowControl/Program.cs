using System;

namespace _6_FlowControl
{
  public class Program
  {
    static void Main(string[] args)
    {
    }

    /// <summary>
    /// This method gets a valid temperature between -40 asnd 135 inclusive 
    /// and returns the valid int. 
    /// </summary>
    /// <returns></returns>
    public static int GetValidTemperature()
    {
      //throw new NotImplementedException($"GetValidTemperature() has not been implemented.");
      int temp = -41;
      do
      {
        Console.WriteLine("Enter a temperature: ");
        string input = Console.ReadLine();

        while (!int.TryParse(input, out temp) || temp > 135 || temp < -40)
        {
          System.Console.WriteLine("Please enter a valid temperature:");
          input = Console.ReadLine();
        }
      } while (temp < -40 || temp > 135);

      return temp;




    }

    /// <summary>
    /// This method has one int parameter
    /// It prints outdoor activity advice and temperature opinion to the console 
    /// based on 20 degree increments starting at -20 and ending at 135 
    /// n < -20, Console.Write("hella cold");
    /// -20 <= n < 0, Console.Write("pretty cold");
    ///  0 <= n < 20, Console.Write("cold");
    /// 20 <= n < 40, Console.Write("thawed out");
    /// 40 <= n < 60, Console.Write("feels like Autumn");
    /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
    /// 80 <= n < 90, Console.Write("niiice");
    /// 90 <= n < 100, Console.Write("hella hot");
    /// 100 <= n < 135, Console.Write("hottest");
    /// </summary>
    /// <param name="temp"></param>
    public static void GiveActivityAdvice(int temp)
    {
      //throw new NotImplementedException($"GiveActivityAdvice() has not been implemented.");
      switch (temp)
      {
        case int n when (n < -20):
          Console.Write("hella cold");
          break;
        case int n when (n < 0):
          Console.Write("pretty cold");
          break;
        case int n when (n < 20):
          Console.Write("cold");
          break;
        case int n when (n < 40):
          Console.Write("thawed out");
          break;
        case int n when (n < 60):
          Console.Write("feels like Autumn");
          break;
        case int n when (n < 80):
          Console.Write("perfect outdoor workout temperature");
          break;

        case int n when (n < 90):
          Console.Write("niiice");
          break;

        case int n when (n < 100):
          Console.Write("hella hot");
          break;

        case int n when (n < 135):
          Console.Write("hottest");
          break;
      }

    }

    /// <summary>
    /// This method gets a username and password from the user
    /// and stores that data in the global variables of the 
    /// names in the method.
    /// </summary>
    public static void Register()
    {
      throw new NotImplementedException($"Register() has not been implemented.");

    }

    /// <summary>
    /// This method gets username and password from the user and
    /// compares them with the username and password names provided in Register().
    /// If the password and username match, the method returns true. 
    /// If they do not match, the user is reprompted for the username and password
    /// until the exact matches are inputted.
    /// </summary>
    /// <returns></returns>
    public static bool Login()
    {
      throw new NotImplementedException($"Login() has not been implemented.");
    }

    /// <summary>
    /// This method has one int parameter.
    /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
    /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
    /// or > 78, Console.WriteLine($"{temp} is too hot!");
    /// For each temperature range, a different advice is given. 
    /// </summary>
    /// <param name="temp"></param>
    public static void GetTemperatureTernary(int temp)
    {
      throw new NotImplementedException($"GetTemperatureTernary() has not been implemented.");
    }
  }//EoP
}//EoN
