using System;
namespace Program{
class Demo
{ 
  static void Main(string[] args){
//     Console.WriteLine("Hello World");
// }
// }

// Data Types

        // char a='s';
        // int i=89;
        // short s=56;
        // long l=4564;
        // uint ui=99;
        // float f=3.7330645f;
        // decimal d=389.5m;
        // Console.WriteLine("Char "+a);
        // Console.WriteLine("Integer "+i);
        // Console.WriteLine("short "+s);
        // Console.WriteLine("long "+l);
        // Console.WriteLine("Unsigned int "+ui);
        // Console.WriteLine("Float "+f);
        // Console.WriteLine("decimal"+d);

     //Strings Example
        // string str1 = "  Hello, World!  ";
        // string str2 = "C# Programming";

        // Console.WriteLine("Length of str1: " + str1.Length);

        // Console.WriteLine("Uppercase: " + str1.ToUpper());
        // Console.WriteLine("Lowercase: " + str2.ToLower());

        // Console.WriteLine("Trimmed str1: '" + str1.Trim() + "'");

        // Console.WriteLine("Substring of str2: " + str2.Substring(3, 11);

        // Console.WriteLine("Replace 'World' with 'C#': " + str1.Replace("World", "C#"));

        // Console.WriteLine("Index of 'Programming' :" + str2.IndexOf("Programming"));

        // Console.WriteLine("str1 contains 'Hello'? " + str1.Contains("Hello"));
        // string[] words = str2.Split(' ');
        // Console.WriteLine("Words in str2:");
        // foreach (string word in words)
        // {
        //     Console.WriteLine(word);
        // }

 //Control statements in C#

//   int num = 10;
//         if (num > 5)
//         {
//             Console.WriteLine("num is greater than 5");
//         }

 //if-else
    //    if (num % 2 == 0)
    //     {
    //         Console.WriteLine("num is even");
    //     }
    //     else
    //     {
    //         Console.WriteLine("num is odd");
    //     }
    //else-if
    //   if (num < 0)
    //     {
    //         Console.WriteLine("num is negative");
    //     }
    //     else if (num == 0)
    //     {
    //         Console.WriteLine("num is zero");
    //     }
    //     else
    //     {
    //         Console.WriteLine("num is positive");
     //   }

    //switch case
    // char grade = 'B';
    //     switch (grade)
    //     {
    //         case 'A':
    //             Console.WriteLine("Excellent!");
    //             break;
    //         case 'B':
    //             Console.WriteLine("Good!");
    //             break;
    //         case 'C':
    //             Console.WriteLine("Fair!");
    //             break;
    //         default:
    //             Console.WriteLine("Needs Improvement");
    //             break;
    //     }
     
     //loops
     // for loop
        // Console.WriteLine("Numbers 1 to 5");
        // for (int i = 1; i <= 5; i++)
        // {
        //     Console.WriteLine(i);
        // }

        // foreach loop
        // string[] fruits = { "Apple", "Banana", "Cherry" };
        // Console.WriteLine("Fruits :");
        // foreach (string fruit in fruits)
        // {
        //     Console.WriteLine(fruit);
        // }

        // while loop
        // int count = 3;
        // Console.WriteLine("while loop:");
        // while (count > 0)
        // {
        //     Console.WriteLine("Count = " + count);
        //     count--;
        // }

        // do-while loop
        // int n = 1;
        // Console.WriteLine("do-while loop:");
        // do
        // {
        //     Console.WriteLine("n = " + n);
        //     n++;
        // } while (n <= 3);

     //Array
      int[] numbers = { 10, 20, 30, 40, 50 };
        Console.WriteLine("First element: " + numbers[0]);  
        Console.WriteLine("Third element: " + numbers[2]);

        foreach(int i in numbers){
            Console.WriteLine(i);
        } 
     }
  }
}