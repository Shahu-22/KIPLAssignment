using System;
class Methods{
    static void Main(string[] args){
        checkEven(20);
        int i=0;
        number(i);
        Console.WriteLine(i);
        num1( ref i);
        Console.WriteLine(i);
        
        int sum=0,product=0;
        calculate(10,20,out sum,out product);
        Console.WriteLine("sum :"+sum+" product :"+product);
        
        int[] nums={10,20,30,40,50};
        Display(nums);
    }
    public static void checkEven(int num){
        if(num%2==0){
            Console.WriteLine("Even Number");
        }
        else{
            Console.WriteLine("Odd Number");
        }
    }
    //Changing value by value parameter
      public static void number(int j){
          j=101;
          
        }
       //Changing value by reference parameter 
         public static void num1(ref int j){
          j=101;
          
        }
        
    // using out parameter when want more one value return 
    public static void calculate(int a,int b,out int sum,out int product){
        sum=a+b;
        product=a*b;
    }
    // Pasing parameter array
    public static void Display(params int[] arr){
        foreach(int i in arr){
            Console.WriteLine(i);
        }
    }
}