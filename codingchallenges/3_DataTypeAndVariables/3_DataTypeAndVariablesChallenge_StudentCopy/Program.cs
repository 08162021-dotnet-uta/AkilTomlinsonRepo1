using System;

namespace _3_DataTypeAndVariablesChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //
      //
      // Insert code here.
      //
      //
    }

    /// <summary>
    /// This method has an 'object' type parameter. 
    /// 1. Create a switch statement that evaluates for the data type of the parameter
    /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
    /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
    /// 4. For example, an 'int' data type will return ,"Data type => int",
    /// 5. A 'ulong' data type will return "Data type => ulong",
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string PrintValues(object obj)
    {
      //throw new NotImplementedException($"PrintValues() has not been implemented");

      switch (obj)
      {
        case int aInt:
          return "Data type => int";

        case byte aByte:
          return "Data type => byte";

        case sbyte aSByte:
          return "Data type => sbyte";

        case uint aUInt:
          return "Data type => uint";

        case short aShort:
          return "Data type => short";

        case ushort aUShort:
          return "Data type => ushort";

        case float aFloat:
          return "Data type => float";

        case double aDouble:
          return "Data type => double";

        case char aChar:
          return "Data type => char";

        case string aString:
          return "Data type => string";

        case decimal aDecimal:
          return "Data type => decimal";

        case long aLong:
          return "Data type => long";

        case ulong aULong:
          return "Data type => ulong";

        default:
          return "this is the default case";
      }
    }

    /// <summary>
    /// THis method has a string parameter.
    /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
    /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
    /// 3. If the string cannot be converted to a integer, return 'null'. 
    /// 4. Investigate how to use '?' to make non-nullable types nullable.
    /// </summary>
    /// <param name="numString"></param>
    /// <returns></returns>
    public static int? StringToInt(string numString)
    {
      //throw new NotImplementedException($"StringToInt() has not been implemented");
      bool result = Int32.TryParse(numString, out int intValue);
      if (result == false)
      {
        return null;
      }
      else
      {
        return intValue;
      }
    }
  }// end of class
}// End of Namespace
