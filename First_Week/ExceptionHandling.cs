using System;
//Exception Handling
class ExceptionHandling{

    public class InvalidAgeException:Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
            
        }
    }
    public void AgeInput(){
        Console.Write("Enter Age : ");
        int age=int.Parse(Console.ReadLine());
        try
        {
            if (age < 0)
            {
                throw new InvalidAgeException("Age must be positive");
            }
            Console.WriteLine("Entered age : "+age);
        }
        catch(InvalidAgeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    //Throwing Exception
    // public void throwingExp(){
    //     Console.Write("Enter Age : ");
    //     int age=int.Parse(Console.ReadLine());
    //     if(age<0){
    //         throw new ArgumentException("Age cannot negative.");
    //     }
    //     Console.WriteLine("Entered age : "+age);
    // }
 public void Division(){
  try
  {
    Console.Write("Enter a number: ");
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine(100 / num);
  }
   catch (FormatException)
 {
    Console.WriteLine("Please enter a valid number.");
 }
  catch (DivideByZeroException)
 {
    Console.WriteLine("Number cannot be zero.");
 }
  catch (Exception ex)
 {
    Console.WriteLine("Unexpected error: " + ex.Message);
 }
   finally
 {
    Console.WriteLine("Program finished.");
 }

}
//Inner Exception Example
 public void ReadAge()
    {
        try
        {
            int age = int.Parse("ABC");
        }
        catch (FormatException ex)
        {
            throw new ArgumentException("Invalid age entered", ex);
        }
    }
// Index outOfRange Exception
public void indexExp(){
    try
{
    int[] numbers = { 1, 2, 3 };
    Console.WriteLine(numbers[5]);
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Index is outside the array bounds.");
}

}
//Overflow exception
public void overflow(){
    try
{
    int num = int.Parse("999999999999");
}
catch (OverflowException)
{
    Console.WriteLine("Number is too large.");
}

}
//main function
 public static void Main(){
        ExceptionHandling e=new ExceptionHandling();
        e.AgeInput();
        e.Division();
              try
        {
            e.ReadAge();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Outer Exception: " + ex.Message);

            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
      
  }
  e.indexExp();
  e.overflow();
}
}