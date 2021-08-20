using System;

namespace Calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      //input
      if (Input(out int input1, out int input2))
      {
        //compute
        int result1 = Add(input1, input2);
        int result2 = Subtract(input1, input2);
        int result3 = Multiply(input1, input2);
        int result4 = Divide(input1, input2);

        //output
        Print(result1, result2, result3, result4);
      }
    }

    static int Add(int input1, int input2)
    {
      // compute
      return input1 + input2;
    }

    static int Subtract(int input1, int input2)
    {
      // compute
      return input1 - input2;
    }
    static int Multiply(int input1, int input2)
    {
      // compute
      return input1 * input2;
    }
    static int Divide(int input1, int input2)
    {
      // compute
      return input1 / input2;
    }

    static void Print(params int[] results)
    {
      //output
      foreach (var result in results)
      {
        Console.WriteLine(result);
      }
    }
    static bool CustomTryParse(string s, out int result)
    {
      try
      {
        result = int.Parse(s);

        return true;
      }
      catch
      {
        result = 0;
        return false;
      }
    }
    static bool Input(out int i1, out int i2)
    {
      // input stuff
      //int input1, input2;

      if (int.TryParse(Console.ReadLine(), out i1) & int.TryParse(Console.ReadLine(), out i2))
      {
        //i1 = input1;
        //i2 = input2;

        return true;
      }
      else
      {
        //i1 = i2 = 0;

        return false;
      }


      /*try
      {
        var input1 = int.Parse(Console.ReadLine());
        var input2 = int.Parse(Console.ReadLine());

        return new int[] { input1, input2 };
      }
      catch (Exception ex)
      {
        throw new Exception("Sorry", ex);
      }
      finally
      {
        //always run
      }*/
    }
  }
}
