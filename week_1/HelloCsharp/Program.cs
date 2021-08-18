using System;

namespace HelloCsharp
{
  class Program
  {
    // Build a simple calculator using 5 methods: Add, Multiply, Subtract, Divide, Print


    static void Main(string[] args)
    {
      double number1;
      double number2;
      Scanner user = new Scanner(System.in);
      //checked online on how to set up operator selection - geeksforgeeks
      System.out.println("Enter the operator you would like to use (+,-,*,/)");
      char operation = user.next().charAt(0);

      System.out.println("Enter two numbers");
      number1 = user.nextDouble();
      number2 = user.nextDouble();

      double calculation = 0;

      switch (operation)
      {

        case '+':

          calculation = number1 + number2;
          break;
        case '-':

          calculation = number1 - number2;
          break;
        case '*':

          calculation = number1 * number2;
          break;
        case '/':

          calculation = number1 / number2;
          break;

        default:
          System.out.println("Please enter one of the following (+,-,*,/)");
      }

      System.out.println(calculation);





      Console.WriteLine("Hello World");
      Console.ReadLine();
    }
  }
}
