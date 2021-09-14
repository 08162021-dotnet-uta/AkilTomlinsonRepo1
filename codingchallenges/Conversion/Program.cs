using System;

namespace Conversion
{
  class Program
  {
    static void Main(string[] args)
    {
      //Casting
      //Does not round up or recognize anu numbers after the 
      int cast = (int)99.99f;
      Console.WriteLine(cast);

      //Implicit Conversion
      int convertInt = 26;
      float newFloat = convertInt;
      Console.WriteLine(newFloat);

      //Convert 
      //Converts one data type to another
      string date = "2021";
      int convertDate = Convert.ToInt32(date);
      Console.WriteLine(convertDate);

      //Parse
      //Takes strings
      //Throws exception if null
      //No support for customer types 
      int parseDate = int.Parse(date);
      Console.WriteLine(parseDate);


    }
  }
}
