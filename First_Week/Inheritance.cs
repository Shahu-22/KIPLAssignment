using System;
//Properties of static member and instance member
// class Circle{
//    static float PI=3.14F;
//     int redius;
// public Circle(int redius){
//     this.redius=redius;
// }    
// public float CalculateArea(){
//     return Circle.PI*this.redius*this.redius;
// }
// }


//Inheritance
// public class Employee{
//    public string FirstName;
//    public string LastName;
//    public string Email;
    
//     public void printName(){
//         Console.WriteLine(FirstName+" "+LastName);
//     }
// }
// public class FullTimeEmp:Employee{
//     public float YearlySalary;
//     public void printName(){
//         base.printName();
//         Console.WriteLine("Salary :"+YearlySalary);
//     }
// }
// public class PartTimeEmp:Employee{
//     public float HourlyRate;
// }
// public class Inheritance
// {
//     public static void Main(string[] args)
//     {
//        FullTimeEmp FTE=new FullTimeEmp();
//        FTE.FirstName="Rajiv";
//        FTE.LastName="Kumar";
//        FTE.YearlySalary=500000;
//        FTE.printName();
       
//           PartTimeEmp PTE=new PartTimeEmp();
//        PTE.FirstName="Rajiv";
//        PTE.LastName="Kumar";
//        PTE.HourlyRate=5000;
       PTE.printName();
    }
}

//Class And Structure
// using System;
// public class Student{
//     public string name;
//     public int age;
// }
// public struct Point{
//     public int x;
//     public int y;
// }
// public class program{
//     public static void Main(string[] args){
//         Student s=new Student();
//         s.name="venkat";
//         s.age=22;
//         //mcopy object by reference
//         Student s1=s;
//         s1.age=21;
        
//         Point p=new Point();
//         p.x=22;
//         Point p1=p;
//         p1.x=25;
//         Console.WriteLine("Name : "+s.name+" Age : "+s.age);
//           Console.WriteLine("X : "+p.x);
        
//     }
// }

//pllymorphism
// using System;
// public class Employee{
//    public string FirstName="FN";
//    public string LastName="LN";
   
//     public virtual void printName(){
//         Console.WriteLine(FirstName+" "+LastName);
//     }
// }
// public class FullTimeEmp:Employee{
//     public float YearlySalary=500000F;
//      public FullTimeEmp(string FirstName,string LastName,float YearlySalary){
//          this.FirstName=FirstName;
//          this.LastName=LastName;
//          this.YearlySalary=YearlySalary;
//      }
//     public override void printName(){
//         base.printName();
//         Console.WriteLine("Salary :"+YearlySalary);
//     }
// }
// public class PartTimeEmp:Employee{
//     public float HourlyRate=5000F;
//     public override void printName(){
//         base.printName();
//         Console.WriteLine("Charges :"+HourlyRate);
//     }
// }
public class Inheritance
{
    public static void Main(string[] args)
    {
       Employee[] employees=new Employee[6];
       employees[0]=new Employee();
       employees[1]=new FullTimeEmp("john","Doe",600000);
       employees[2]=new PartTimeEmp();
       employees[3]=new FullTimeEmp("Mark","luies",400000);
       employees[4]=new PartTimeEmp();
       employees[5]=new FullTimeEmp("Rajiv","Kumar",500000);
       
       foreach(Employee e in employees){
           e.printName();
       }
    }
}